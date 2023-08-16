using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NToastNotify;
using SAPWebPortal.AppServices;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Extensions.DependencyInjection;
using Serenity.Localization;
using Serenity.Navigation;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data.Common;
using System.IO;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using System.Linq;
using Sentry.Protocol;
using SAPWebPortal.Web.DependencyInjections;
using SAPWebPortal.Web.Modules.SAPApp;
using System.Threading;
using System.Data;
using SAPWebPortal.Web.Modules.ARInvoiceToAPInvoiceIntegration;

namespace SAPWebPortal
{
    public partial class Startup
    {
        public static bool isTest = false ;
        public static string basePath  ;
        public static string connectionString
        {
            get
            {
                return Startup.getConfigValue("Data:Default:ConnectionString");
            }
        }
        public static string getConfigValue(string Id)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            return config.GetValue<string>(Id);
        }
        public static string getHeartBeat
        {
            get
            {
                return Startup.getConfigValue("HeartBeat");
            }
        }
        public static IConfiguration _Configuration { get; private set; }
        public Startup(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            basePath = hostEnvironment.ContentRootPath;
            _Configuration = configuration;
            Configuration = configuration;
            HostEnvironment = hostEnvironment;
            SqlSettings.AutoQuotedIdentifiers = true;
            RegisterDataProviders();
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment HostEnvironment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ITypeSource>(new DefaultTypeSource(new[]
            {
                typeof(LocalTextRegistry).Assembly,
                typeof(ISqlConnections).Assembly,
                typeof(IRow).Assembly,
                typeof(SaveRequestHandler<>).Assembly,
                typeof(IDynamicScriptManager).Assembly,
                typeof(Startup).Assembly,
                typeof(Serenity.Extensions.EnvironmentSettings).Assembly,
            }));
            
            services.Configure<ConnectionStringOptions>(Configuration.GetSection(ConnectionStringOptions.SectionKey));
            services.Configure<CssBundlingOptions>(Configuration.GetSection(CssBundlingOptions.SectionKey));
            services.Configure<LocalTextPackages>(Configuration.GetSection(LocalTextPackages.SectionKey));
            services.Configure<ScriptBundlingOptions>(Configuration.GetSection(ScriptBundlingOptions.SectionKey));
            services.Configure<UploadSettings>(Configuration.GetSection(UploadSettings.SectionKey));
            services.Configure<Serenity.Extensions.EnvironmentSettings>(Configuration.GetSection(Serenity.Extensions.EnvironmentSettings.SectionKey));
            var dataProtectionKeysFolder = Configuration?["DataProtectionKeysFolder"];
            if (!string.IsNullOrEmpty(dataProtectionKeysFolder))
            {
                dataProtectionKeysFolder = Path.Combine(HostEnvironment.ContentRootPath, dataProtectionKeysFolder);
                if (Directory.Exists(dataProtectionKeysFolder))
                    services.AddDataProtection()
                        .PersistKeysToFileSystem(new DirectoryInfo(dataProtectionKeysFolder));
            }


            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-CSRF-TOKEN";
            });

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            var builder = services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(AutoValidateAntiforgeryTokenAttribute));
                options.Filters.Add(typeof(AntiforgeryCookieResultFilterAttribute));
                options.ModelBinderProviders.Insert(0, new ServiceEndpointModelBinderProvider());
                options.Conventions.Add(new ServiceEndpointActionModelConvention());
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            if (HostEnvironment.IsDevelopment())
                builder.AddRazorRuntimeCompilation();
            builder.Services.AddRazorPages().AddNToastNotifyNoty(new NotyOptions
            {
                ProgressBar = false,
                Timeout = 5000
            });
            builder.Services.AddNotyf(config =>
            {
                config.DurationInSeconds = 5;
                config.IsDismissable = true;
                config.Position = NotyfPosition.TopCenter;
            });
            services.AddAuthentication(o =>
            {
                o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(o =>
            {
                o.Cookie.Name = ".AspNetAuth";
                o.LoginPath = new PathString("/Account/Login/");
                o.AccessDeniedPath = new PathString("/Account/AccessDenied");
                o.ExpireTimeSpan = TimeSpan.FromHours(5);
                o.SlidingExpiration = true;
            });

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IReportRegistry, ReportRegistry>();
            services.AddExcelExporter();
            services.AddSingleton<IDataMigrations, DataMigrations>();
            services.AddSingleton<Serenity.Extensions.IEmailSender, Serenity.Extensions.EmailSender>();
            services.AddServiceHandlers();
            services.AddDynamicScripts();
            services.AddCssBundling();
            services.AddScriptBundling();
            services.AddUploadStorage();
            //services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromHours(10);
            });
            // Add framework services.
            services.AddMvc();
            //services.AddMvc(option => option.EnableEndpointRouting = false);
            //services.AddDistributedMemoryCache();
            services.AddSingleton<Administration.IUserPasswordValidator, Administration.UserPasswordValidator>();
            services.AddSingleton<IHttpContextItemsAccessor, HttpContextItemsAccessor>();
            services.AddSingleton<IUserAccessor, Administration.UserAccessor>();
            services.AddSingleton<IUserRetrieveService, Administration.UserRetrieveService>();
            services.AddSingleton<IPermissionService, Administration.PermissionService>();
            services.AddSingleton<INavigationModelFactory, Common.NavigationModelFactory>();
            services.AddSingleton<IB1ServiceLayer, B1ServiceLayer>();
            services.AddSingleton<ISharpShopify, SharpShopify>();
            services.AddSingleton<ILog, Logger>();
            services.AddSingleton<IARInvoiceToAPInvoiceIntegration, ARInvoiceToAPInvoiceIntegration>();
            services.AddScoped<IDbConnection>(provider =>
            {
                var connectionString = Configuration.GetSection("Data:Default:ConnectionString");
                return new SqlConnection(connectionString.Value);
            });
            services.AddScoped<IChangeTracking, ChangeTracking>();

        }

        public static void InitializeLocalTexts(IServiceProvider services)
        {
            var env = services.GetRequiredService<IWebHostEnvironment>();

            services.AddAllTexts(new[]
            {
                Path.Combine(env.WebRootPath, "Scripts", "serenity", "texts"),
                Path.Combine(env.WebRootPath, "Scripts", "site", "texts"),
                Path.Combine(env.ContentRootPath, "App_Data", "texts")
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            RowFieldsProvider.SetDefaultFrom(app.ApplicationServices);
            InitializeLocalTexts(app.ApplicationServices);

            var reqLocOpt = new RequestLocalizationOptions
            {
                SupportedUICultures = UserCultureProvider.SupportedCultures,
                SupportedCultures = UserCultureProvider.SupportedCultures
            };
            reqLocOpt.RequestCultureProviders.Clear();
            reqLocOpt.RequestCultureProviders.Add(new UserCultureProvider());
            app.UseRequestLocalization(reqLocOpt);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseDynamicScripts();
            app.UseNToastNotify();
            //app.UseNotyf();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.ApplicationServices.GetRequiredService<IDataMigrations>().Initialize();


            var scope = app.ApplicationServices.CreateScope();
            scope.ServiceProvider.GetService<IChangeTracking>().Initialize();
            var serverAddressesFeature = app.ServerFeatures.Get<IServerAddressesFeature>();
            var address = serverAddressesFeature.Addresses.FirstOrDefault();
            if (address != null)
            {
                port = int.Parse(address.Split(':').Last());
                http_protocol = address.Split(':').FirstOrDefault();
            }
            else
            {
                port =Convert.ToInt32( getConfigValue("DeploymentServer:Port").ToString());
                http_protocol = getConfigValue("DeploymentServer:Protocol").ToString();

            }
            var serviceProvider = app.ApplicationServices;
            var myService = serviceProvider.GetRequiredService<IARInvoiceToAPInvoiceIntegration>();



            Thread ARtoAPThread = new Thread(new ThreadStart(myService.IterationFunc));
            ARtoAPThread.IsBackground = true;
            ARtoAPThread.Name = "ARtoAPThreadFunc";
            ARtoAPThread.Start();

            /* var serviceProvider = app.ApplicationServices;
             var myService = serviceProvider.GetRequiredService<ISAPtoShopifyController>();


             myService.SAPToShopifyGetItemsFunc2();

             Thread SAPToShopifyGetItemsThread = new Thread(new ThreadStart(myService.SAPToShopifyGetItemsFunc));
             SAPToShopifyGetItemsThread.IsBackground = true;
             SAPToShopifyGetItemsThread.Name = "SAPToShopifyGetItemsThread";
             SAPToShopifyGetItemsThread.Start();
             //myService.SAPToShopifyIterationFunc();
             Thread SAPToShopifyItemThread = new Thread(new ThreadStart(myService.SAPToShopifyIterationItemFunc));
             SAPToShopifyItemThread.IsBackground = true;
             SAPToShopifyItemThread.Name = "SAPToShopifyItemThread";
             SAPToShopifyItemThread.Start();


             Thread SAPToShopifyStockThread = new Thread(new ThreadStart(myService.SAPToShopifyIterationStockFunc));
             SAPToShopifyStockThread.IsBackground = true;
             SAPToShopifyStockThread.Name = "SAPToShopifyStockThread";
             SAPToShopifyStockThread.Start();


             Thread SAPToShopifyItemPricesThread = new Thread(new ThreadStart(myService.SAPToShopifyIterationItemPricesFunc));
             SAPToShopifyItemPricesThread.IsBackground = true;
             SAPToShopifyItemPricesThread.Name = "SAPToShopifyItemPricesThread";
             SAPToShopifyItemPricesThread.Start();*/


        }
        static int port = -1;

        static string http_protocol = "http";
        public static string Port { get { return port.ToString(); } }
        public static string Http_Protocol
        {
            get { return http_protocol; }
        }
        public static void RegisterDataProviders()
        {
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
            DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", SqlClientFactory.Instance);
            DbProviderFactories.RegisterFactory("Microsoft.Data.Sqlite", Microsoft.Data.Sqlite.SqliteFactory.Instance);

            // to enable FIREBIRD: add FirebirdSql.Data.FirebirdClient reference, set connections, and uncomment line below
            // DbProviderFactories.RegisterFactory("FirebirdSql.Data.FirebirdClient", FirebirdSql.Data.FirebirdClient.FirebirdClientFactory.Instance);

            // to enable MYSQL: add MySql.Data reference, set connections, and uncomment line below
            // DbProviderFactories.RegisterFactory("MySql.Data.MySqlClient", MySql.Data.MySqlClient.MySqlClientFactory.Instance);

            // to enable POSTGRES: add Npgsql reference, set connections, and uncomment line below
            // DbProviderFactories.RegisterFactory("Npgsql", Npgsql.NpgsqlFactory.Instance);
        }
    }
}
