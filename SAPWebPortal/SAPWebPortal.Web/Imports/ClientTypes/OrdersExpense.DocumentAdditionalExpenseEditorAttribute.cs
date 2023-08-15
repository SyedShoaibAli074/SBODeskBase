using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.OrdersExpense
{
    public partial class DocumentAdditionalExpenseEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.OrdersExpense.DocumentAdditionalExpenseEditor";

        public DocumentAdditionalExpenseEditorAttribute()
            : base(Key)
        {
        }
    }
}
