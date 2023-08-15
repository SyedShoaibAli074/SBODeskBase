using Microsoft.AspNetCore.Mvc;
using SAPWebPortal.Web.DependencyInjections;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using ShopifySharp;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using MyRow = SAPWebPortal.Default.ShopifyWebkookSettingsRow;

namespace SAPWebPortal.Default.Endpoints
{
    [Route("Services/Default/ShopifyWebkookSettings/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class ShopifyWebkookSettingsController : ServiceEndpoint
    {
        ISharpShopify _shopify;
        public ShopifyWebkookSettingsController(ISharpShopify shopify)
        {
            _shopify=shopify;   
        }
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IShopifyWebkookSettingsSaveHandler handler)
        {
            var settings = request.Entity;
            var stores = settings.ShopifyStore;
            var storerow = uow.Connection.List<ShopifySettingsRow>().Where(x => x.Id == Convert.ToInt64(stores)).FirstOrDefault();
            var response=_shopify.RegisterWebhook(settings, storerow.StoreName);

            request.Entity.WebhookId = response.Id.ToString();
            request.Entity.CreateDate = DateTime.Now;
            request.Entity.CreatedBy=Context.User.GetIdentifier();
            return handler.Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IShopifyWebkookSettingsSaveHandler handler)
        {
            var settings = request.Entity;
            var stores = settings.ShopifyStore;
            var storerow = uow.Connection.List<ShopifySettingsRow>().Where(x => x.Id == Convert.ToInt32(stores)).FirstOrDefault();
            var webhookId = uow.Connection.List<MyRow>().Where(x => x.Id == Convert.ToInt64(settings.Id)).FirstOrDefault();
            if (!String.IsNullOrEmpty(webhookId.WebhookId))
            {
                var response = _shopify.UpdateWebhook(Convert.ToInt64(webhookId.WebhookId), settings, storerow.StoreName);
            }
            else
            {
                var response = _shopify.RegisterWebhook(settings, storerow.StoreName);
                request.Entity.WebhookId = response.Id.ToString();
                request.Entity.CreateDate = DateTime.Now;
                request.Entity.CreatedBy = Context.User.GetIdentifier();
            }

            return handler.Update(uow, request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IShopifyWebkookSettingsDeleteHandler handler)
        {
            var id = request.EntityId;
            var webhook = uow.Connection.List<MyRow>().Where(x => x.Id == Convert.ToInt64(id)).FirstOrDefault();

            var storerow = uow.Connection.List<ShopifySettingsRow>().Where(x => x.Id == Convert.ToInt64(webhook.ShopifyStore)).FirstOrDefault();
            if (!String.IsNullOrEmpty(webhook.WebhookId))
            {
                _shopify.DeleteWebhook(Convert.ToInt64(webhook.WebhookId), storerow.StoreName);

            }
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IShopifyWebkookSettingsRetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IShopifyWebkookSettingsListHandler handler)
        {
            return handler.List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IShopifyWebkookSettingsListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.ShopifyWebkookSettingsColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "ShopifyWebkookSettingsList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
    }
}