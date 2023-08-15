using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.InventoryTransferRequest
{
    public partial class StockTransferLineEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.InventoryTransferRequest.StockTransferLineEditor";

        public StockTransferLineEditorAttribute()
            : base(Key)
        {
        }
    }
}
