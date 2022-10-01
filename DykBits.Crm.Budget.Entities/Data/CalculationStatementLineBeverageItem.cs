using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class CalculationStatementLineBeverageItem: CalculationStatementLineItem
    {
        public CalculationStatementLineBeverageItem(CalculationStatementSectionItem sectionItem, CalculationStatementLine line): base(sectionItem, line)
        {
        }
        private BeverageView _beverageItem;
        internal BeverageView BeverageItem
        {
            get
            {
                if (Product == null)
                    return null;
                if (Product.ProductClass != ProductClass.ProductClassBeverage)
                    return null;
                if (this._beverageItem == null)
                {
                    this._beverageItem = ListManager.GetItem<BeverageView>(Line.ProductId.Value);
                }
                return this._beverageItem;
            }
        }
        public int? BeverageTypeId
        {
            get
            {
                if (BeverageItem != null)
                    return BeverageItem.BeverageTypeId;
                return null;
            }
        }
        public int? BeverageSubtypeId
        {
            get
            {
                if (BeverageItem != null)
                    return BeverageItem.BeverageSubtypeId;
                return null;
            }
        }
        public int? CountryId
        {
            get
            {
                if (BeverageItem != null)
                    return BeverageItem.CountryId;
                return null;
            }
        }
        public int? SupplierId
        {
            get
            {
                if (BeverageItem != null)
                    return BeverageItem.SupplierId;
                return null;
            }
        }
        public decimal? Volume
        {
            get
            {
                if (BeverageItem != null)
                    return BeverageItem.Volume;
                return null;
            }
        }
        public int? BeveragePackId
        {
            get
            {
                if (BeverageItem != null)
                    return BeverageItem.BeveragePackId;
                return null;
            }
        }

        protected override decimal CalculateAmountPerGuest()
        {
            if(this.Parent.AmountOfGuests.HasValue)
                return (this.Amount.Value * this.Volume.GetValueOrDefault() * 1000m) / this.Parent.AmountOfGuests.Value;
            return 0;
        }

        protected override decimal CalculateAmount()
        {
            if (this.Volume.HasValue)
                return Math.Ceiling((this.Parent.AmountOfGuests.GetValueOrDefault() * this.AmountPerGuest.GetValueOrDefault()) / (this.Volume.GetValueOrDefault() * 1000m));
            return 0;
        }

    }
}
