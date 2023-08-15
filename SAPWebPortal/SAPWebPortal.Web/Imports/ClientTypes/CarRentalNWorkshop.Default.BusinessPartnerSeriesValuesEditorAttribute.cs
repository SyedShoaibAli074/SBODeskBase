using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CarRentalNWorkshop.Default
{
    public partial class BusinessPartnerSeriesValuesEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "CarRentalNWorkshop.Default.BusinessPartnerSeriesValuesEditor";

        public BusinessPartnerSeriesValuesEditorAttribute()
            : base(Key)
        {
        }
    }
}
