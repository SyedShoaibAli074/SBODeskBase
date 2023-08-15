
//namespace SAPWebPortal.Default.Pages
//{
//    using Serenity;
//    using Serenity.Data;
//    using System;
//    using System.Data.SqlClient;
//    using Default;
//    using System.Data;
//    using System.Linq;
//    using System.Web;
//    using System.Collections.Generic;
//    using Extensions;
//    using Microsoft.AspNetCore.Mvc;
//    using SAPWebPortal.Administration;
//    using System.IO;
//    using SAPWebPortal.Administration.Entities;
//    using SAPWebPortal.Administration.Endpoints;

//    [Route("Default/ReportPage/[action]")]
////    [RoutePrefix("Default/ReportPage"), Route("{action=index}")]
//    [Serenity.Web.PageAuthorize(PermissionKeys.General)]
//    public class ReportPageController : Controller
//    {
//        //public Dictionary<int,string> Reports = new Dictionary<int, string>();
//        public static string ReportId;
//        SapCredential Credent = new SapCredential();
//        private void SetDBLogonForReport(CrystalDecisions.Shared.ConnectionInfo connectionInfo, CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument)
//        {
//            CrystalDecisions.CrystalReports.Engine.Tables tables = reportDocument.Database.Tables;

//            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
//            {
//                CrystalDecisions.Shared.TableLogOnInfo tableLogonInfo = table.LogOnInfo;

//                tableLogonInfo.ConnectionInfo = connectionInfo;
//                table.ApplyLogOnInfo(tableLogonInfo);
//            }
//        }
//        public static string[] Split(this string str, string splitter)
//        {
//            try
//            {
//                return str.Split(new[] { splitter }, StringSplitOptions.None);
//            }
//            catch
//            {
//            }
//            return null;
//        }
//        void LoadReport(ReportDocument rd)
//        {
//            getSAPreportCredential(ReportId);
//            ConnectionInfo crConnectionInfo = new ConnectionInfo();
//            crConnectionInfo.ServerName = Credent.sapdbsn; 
//            crConnectionInfo.DatabaseName = Credent.sapcdb;
//            crConnectionInfo.UserID = Credent.sapdbun;
//            crConnectionInfo.Password = Credent.sapdbpass;
//            //crConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings["servername"];// "WIN-1F32IOK02S5";
//            //crConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings["dbname"];// "SBODemoGB1";
//            //crConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings["dbuser"];
//            //crConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings["dbpass"];
//            //Session[_crConnectionInfo] = crConnectionInfo;
//            Session["crConnectionInfo"] = crConnectionInfo;
//            SetDBLogonForReport(crConnectionInfo, rd);
//            // rd.Load(Session["filepath"].ToString());
//            //rd.Load(filepath, OpenReportMethod.OpenReportByDefault);
//            var parameters = rd.ParameterFields.ToArray();
//            var rptname = rd.Name;
//            for (int i = 0; i < parameters.Count(); i++)
//            {
//                var param = ((CrystalDecisions.Shared.ParameterField)(parameters[i]));

//                if (rptname != param.ReportName) continue;
//                var value = Request.Form[param.Name];
//                if (param.Name == "PrintByUserName@")
//                {
                    
//                    rd.SetParameterValue(param.Name, Context.User.Identity.Name);
//                }
//                //  if (!param.EnableAllowMultipleValue || ())
//                if (!(param.EnableAllowMultipleValue))
//                {
//                    if (param.ParameterValueType == ParameterValueKind.DateParameter || param.ParameterValueType == ParameterValueKind.DateTimeParameter)
//                    {
//                        //var date = DateTime.ParseExact(value, "yyyy-MM-dd", null);
//                        if (!string.IsNullOrEmpty(value))
//                        {
//                            if (value.Contains(",")) 
//                                value.Replace(",", "");
//                            rd.SetParameterValue(param.Name, value);
//                        }
//                    }
//                    else
//                    {
//                        try
//                        {
//                            rd.SetParameterValue(param.Name, value);
//                        }
//                        catch (System.Exception ex)
//                        {
//                            Console.WriteLine(ex.Message);
//                        }
//                    }
//                }
//                else
//                {

//                    //   rd.SetParameterValue(param.Name, value);
//                    System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
//                    if (!string.IsNullOrEmpty(value) && value.ToString().Contains(','))
//                    {
//                        var arr = value.ToString().Split(",");
//                        rd.SetParameterValue(param.Name, arr);
//                    }
//                    //Select for multipul values
//                }
//                Session.Remove(param.Name);
//            }
//            Session["report"] = rd;
//            Session.Remove("filepath");
//        }

//        [HttpPost]

//        [ValidateAntiForgeryToken]
//        public ActionResult Index()
//        {
//            var rd = (ReportDocument)Session["report"];
            
//            LoadReport(rd);
//            return Redirect(string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~")) + "AspNetForms/aspnetgeneric.aspx");

//        }
//        [HttpGet]
//        public ActionResult Index(String id)
//        {
//            ReportId = id;
//            var rd = new ReportDocument();
//            var reportname = Server.UrlDecode(Request.Params["id"]);
//            using (var connection = new SqlConnection(Startup.connectionString))
//            {
//                var Report = connection.List <ReportsRow>().FirstOrDefault(x => x.RptName.ToString() == reportname);
//                var user = connection.List<UserRow>().First(x => x.UserId == Convert.ToInt32(Serenity.Authorization.UserId));
//                string path = Path.Combine(Startup.basePath, Path.Combine(@"App_Data\upload", Report.RptByteArray));
            
            
//            rd.Load(path);
//            var rptname = rd.Name;
//            ViewBag.Title = "Report View";
//            ViewBag.Description = rd.SummaryInfo.ReportTitle;
//            var parameters = rd.ParameterFields.ToArray();
//            System.Collections.Generic.List<ParameterElement> obj = new System.Collections.Generic.List<ParameterElement>();
//            if (rd.ParameterFields.Count > 0)
//            {
//                #region make Controls for parameters
//                for (int i = 0; i < parameters.Count(); i++)
//                {
//                    var param = ((CrystalDecisions.Shared.ParameterField)(parameters[i]));
//                    if (rptname != param.ReportName ) continue;
//                        if (param.Name == "PrintByUserName@") continue;
//                    var lableName = param.PromptText;
//                    if (!(param.EnableAllowMultipleValue || param.Name.Contains("_multi@")))
//                    {
//                        if (!param.isSQL())
//                        {
//                            if (param.DefaultValues.Count > 0)
//                            {

//                                DataTable dt = new DataTable();
//                                dt.Columns.Add("Code", typeof(string));
//                                dt.Columns.Add("Name", typeof(string));
//                                for (int j = 0; j < param.DefaultValues.Count; j++)
//                                {
//                                    dt.Rows.Add((param.DefaultValues.ToArray()[j] as ParameterDiscreteValue).Value, (param.DefaultValues.ToArray()[j] as ParameterDiscreteValue).Value);
//                                }
//                                obj.Add(new ParameterElement() { ismultiple = false, PromptText = param.PromptText, Name = lableName, Data = dt, DataType = typeof(DataTable) });
//                            }
//                            else
//                                if (param.ParameterValueType == ParameterValueKind.DateParameter || param.ParameterValueType == ParameterValueKind.DateTimeParameter)
//                            {
//                                obj.Add(new ParameterElement() { ismultiple = false, PromptText = param.PromptText, Name = param.Name, DataType = typeof(DateTime) });

//                            }
//                            else if (param.ParameterValueType == ParameterValueKind.NumberParameter)
//                            {
//                                obj.Add(new ParameterElement() { ismultiple = false, PromptText = param.PromptText, Name = param.Name, DataType = typeof(int) });

//                            }
//                            else
//                            {
//                                obj.Add(new ParameterElement() { ismultiple = false, PromptText = param.PromptText, Name = param.Name, DataType = typeof(string) });
//                            }
//                        }
//                        else
//                        {
//                            db. = AES.DecryptString(db.SapDatabase.DBPassword);                           
//                            // var connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["conntion"].ConnectionString;
//                            var connectionstring = string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};Integrated Security={4}", db.SapDatabase.ServerName, db.SapDatabase.CompanyDB, db.SapDatabase.DBUserName, db.SapDatabase.DBPassword, "False");
//                            var sqlcon = new SqlConnection(connectionstring);
//                            DataTable dt = new DataTable();
//                            try
//                            {
//                                var query = dc.AB_User1Details.First(x => x.ParameterName == param.Name).ParameterQuery;
//                                var da = new SqlDataAdapter(query, sqlcon);
//                                da.Fill(dt);
//                            }
//                            catch(Exception Ex)
//                            {
//                                ExceptionsController.Log(Ex);
//                            }

//                            obj.Add(new ParameterElement() { ismultiple = false, PromptText = param.PromptText, Name = param.Name, Data = dt, DataType = typeof(DataTable) });

//                        }
//                    }
//                    else
//                    {
//                        DataTable dt = new DataTable();

//                        if (param.isSQL())
//                        {
//                            var connectionstring = Startup.connectionString
//                            var sqlcon = new SqlConnection(connectionstring);
//                            try
//                            {
//                                //var query = parameterdetail.First(x => x.ParameterName == param.Name).ParameterQuery;
//                                var query = dc.AB_User1Details.First(x => x.ParameterName == param.Name).ParameterQuery;
//                                var da = new SqlDataAdapter(query , sqlcon);
//                                da.Fill(dt);
//                            }
//                            catch
//                            { }
//                            #region Remove Data according to B1 Filter Tables
//                            //var sql = param.getSQL();
//                            //if (sql.ToLower().Contains("oprj"))
//                            //{
//                            //    // dt.Clear();

//                            //    dt = new DataTable();
//                            //    // data table should come from @AB_USER2
//                            //    var query = string.Format("Select b.\"U_PrjCode\",b.\"U_PrjName\" from \"@AB_USER2\" b inner join \"@AB_USER\" a on a.\"DocEntry\" = b.\"DocEntry\" where a.\"U_E_Name\"='{0}' and \"Status\" = 'O' ", Session["user"]);
//                            //    var da = new SqlDataAdapter(query, sqlcon);
//                            //    da.Fill(dt);
//                            //}
//                            //if (sql.ToLower().Contains("ocrd"))
//                            //{
//                            //    //  dt.Clear();
//                            //    dt = new DataTable();
//                            //    var query = string.Format("Select b.\"U_CardCode\",b.\"U_CardName\" from \"@AB_USER3\" b inner join \"@AB_USER\" a on a.\"DocEntry\" = b.\"DocEntry\" where a.\"U_E_Name\"='{0}' and \"Status\" = 'O'", Session["user"]);
//                            //    var da = new SqlDataAdapter(query, sqlcon);
//                            //    da.Fill(dt);
//                            //    // data table should come from @AB_USER3
//                            //}
//                            #endregion

//                            obj.Add(new ParameterElement() { ismultiple = true, PromptText = param.PromptText, Name = param.Name, Data = dt, DataType = typeof(DataTable) });

//                        }
//                    }


//                }
//                #endregion

//            }
//            Session["parameters"] = obj;
//            Session["report"] = rd;
//            }
//            try { ViewBag.Report.Dispose(); } catch { }
//            ViewBag.Report = rd;

//            ViewBag.ReportName = rd.SummaryInfo.ReportTitle;
            
//            return View(MVC.Views.Default.ReportPage.ReportPageIndex);
//        }
//        public bool getSAPreportCredential(string RDOCid)
//        {
//            bool res;
//            using (var connection = new SqlConnection(Startup.connectionString))
//            {
//                var Reports = connection.List<ReportsRow>().FirstOrDefault(x => x.Rdocid.ToString() == RDOCid);
//                var sapdb = connection.List<SapDatabasesRow>().FirstOrDefault(x => x.CompanyDb.ToString() == Reports.DB_Name);
//                if (sapdb != null)
//                {
//                    res = true;
//                    Credent.sapdbsn = sapdb.ServerName;
//                    Credent.sapcdb = sapdb.CompanyDb;
//                    Credent.sapdbun = sapdb.DbUserName;
//                    Credent.sapdbpass = AES.DecryptString(sapdb.DbPassword);
//                }
//                else
//                {
//                    res = false;
//                }
//                ReportId = "";
//            }
//            return res;
//        }
//    }
//    public class ParameterElement
//    {
//        public bool ismultiple;
//        public String Name;
//        public Object Data;
//        public Type DataType;
//        public String PromptText;
//    }
//    public class SapCredential
//    {
//        public string sapdbsn;
//        public string sapcdb;
//        public string sapdbun;
//        public string sapdbpass;
//    }
//}
