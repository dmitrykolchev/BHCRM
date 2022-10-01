using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class CalculationStatementLineMenuItem: CalculationStatementLineItem
    {
        public CalculationStatementLineMenuItem(CalculationStatementSectionItem sectionItem, CalculationStatementLine line): base(sectionItem, line)
        {
        }
        private MasterMenuView _masterMenuItem;
        internal MasterMenuView MasterMenuItem
        {
            get
            {
                if (Product == null)
                    return null;
                if (Product.ProductClass != ProductClass.ProductClassMasterMenu)
                    return null;
                if (this._masterMenuItem == null)
                {
                    this._masterMenuItem = ListManager.GetItem<MasterMenuView>(Line.ProductId.Value);
                }
                return this._masterMenuItem;
            }
        }
        public Nullable<decimal> ServingAmount
        {
            get
            {
                if (this.Product != null)
                    return this.MasterMenuItem.ServingAmount;
                return null;
            }
        }
        protected override void OnAmountPerGuestChanged()
        {
            base.OnAmountPerGuestChanged();
            InvokePropertyChanged(AmountUomProperty);
            InvokePropertyChanged(WeightPerGuestProperty);
            InvokePropertyChanged(TotalWeightProperty);
        }
        public Nullable<decimal> AmountUom
        {
            get
            {
                if (UnitOfMeasureId == 1) // kg
                    return TotalWeight / 1000;
                else if (UnitOfMeasureId == 2) // g
                    return TotalWeight;
                else
                    return Amount;
            }
        }
        public override Nullable<decimal> TotalWeight
        {
            get
            {
                if (this.ServingAmount.HasValue)
                    return this.Amount * this.ServingAmount.Value;
                return null;
            }
        }
        public override Nullable<decimal> WeightPerGuest
        {
            get
            {
                if (this.ServingAmount.HasValue)
                    return this.AmountPerGuest * this.ServingAmount.Value;
                return null;
            }
        }
    }
}
