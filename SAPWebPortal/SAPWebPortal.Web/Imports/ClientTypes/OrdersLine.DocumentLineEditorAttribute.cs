﻿using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.OrdersLine
{
    public partial class DocumentLineEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.OrdersLine.DocumentLineEditor";

        public DocumentLineEditorAttribute()
            : base(Key)
        {
        }
    }
}
