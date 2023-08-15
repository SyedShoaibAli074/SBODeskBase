namespace SAPWebPortal.Helpers {
    export class DocTotalHelper {
        constructor(form?: Serenity.PrefixedContext, service?: string) {
            this.CalculateDocTotal(form);
        }
        public CalculateDocTotal(Form): void {
                var HeaderForm = Form;
                var DocumentLines = HeaderForm.DocumentLines.getItems();
                var LineSum = 0.0;
            var VatSum = 0.0;
            var GrossTotal = 0.0;
            var VatDiscount = 0.0;

                for (let i = 0; i < DocumentLines.length; i++)
                {
                    if (DocumentLines[i].TaxTotal == null)
                    {
                        DocumentLines[i].TaxTotal = 0;
                    }
                    if (DocumentLines[i].LineTotal == null)
                    {
                        DocumentLines[i].LineTotal = 0;
                    }
                    if (DocumentLines[i].DiscountPercent == null)
                    {
                        DocumentLines[i].DiscountPercent = 0;
                    }
                    GrossTotal = GrossTotal + DocumentLines[i].GrossTotal;
                    VatDiscount = VatDiscount + (VatSum * ((DocumentLines[i].DiscountPercent)/100));
                    VatSum = VatSum + DocumentLines[i].TaxTotal  ;                 
                    LineSum = LineSum + DocumentLines[i].LineTotal;
                }

                HeaderForm.VatSum.value =  GrossTotal - LineSum;
                HeaderForm.DocTotal.value = GrossTotal;
            
                if (HeaderForm.DiscountPercent.value != 0)
                {

                    HeaderForm.TotalDiscount.value = (GrossTotal / 100) * HeaderForm.DiscountPercent.value;
                    HeaderForm.VatSum.value = (VatSum - (VatSum * (HeaderForm.DiscountPercent.value / 100)));
                    HeaderForm.DocTotal.value = (GrossTotal) - (GrossTotal * (HeaderForm.DiscountPercent.value / 100));
                                    
                }
        }
    }
}