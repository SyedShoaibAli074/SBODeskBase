﻿using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.QuotationsLine.DocumentLineRow>;
using MyRow = SAPWebPortal.QuotationsLine.DocumentLineRow;

namespace SAPWebPortal.QuotationsLine
{
    public interface IDocumentLineListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class DocumentLineListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IDocumentLineListHandler
    {
        public DocumentLineListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}