using Serenity.ComponentModel;
using System.ComponentModel;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.BusinessPartnerGroup")]
    [BasedOnRow(typeof(BusinessPartnerGroupRow), CheckNames = true)]
    public class BusinessPartnerGroupColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public System.Int32 Code { get; set; }
        public System.String Name { get; set; }
        public SAPB1.BoBusinessPartnerGroupTypes Type { get; set; }
    }
}