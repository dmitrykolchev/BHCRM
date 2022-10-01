using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Grid;
namespace DykBits.Crm.UI
{
    public class StandardCount : GridSummaryItem
    {
        public StandardCount()
        {
            this.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.DisplayFormat = "[{0:#,##0}]";
        }
    }
    public class StandardSum: GridSummaryItem
    {
        public StandardSum()
        {
        }

        public string Field
        {
            get { return this.FieldName; }

            set
            {
                if (this.Field != value)
                {
                    if(!string.IsNullOrEmpty(value))
                    {
                        if(!value.StartsWith("RowData.Row."))
                        {
                            value = "RowData.Row." + value;
                        }
                    }
                    this.FieldName = value;
                    this.ShowInColumn = value;
                    this.ShowInGroupColumnFooter = value;
                    this.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    this.DisplayFormat = "Σ {0:#,##0.00}";
                }
            }
        }
    }
}
