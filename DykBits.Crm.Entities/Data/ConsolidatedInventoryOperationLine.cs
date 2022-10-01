using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class ConsolidatedInventoryOperationLine: XmlSerializableDataItem
    {
        [XmlAttribute]
        public Nullable<int> ProductId { get; set; }
        [XmlIgnore]
        public string FileAs
        {
            get
            {
                return ListManager.GetItem<ProductView>(ProductId.Value).FileAs;
            }
        }
        [XmlAttribute]
        public Nullable<int> ProductCategoryId { get; set; }
        [XmlAttribute]
        public Nullable<int> ProductSubcategoryId { get; set; }
        [XmlAttribute]
        public Nullable<int> ProductTypeId { get; set; }
        [XmlAttribute]
        public Nullable<int> ProductClass { get; set; }
        [XmlAttribute]
        public Nullable<decimal> StartAmount { get; set; }
        [XmlAttribute]
        public Nullable<decimal> StartCost { get; set; }
        [XmlAttribute]
        public Nullable<decimal> PurchaseAmount { get; set; }
        [XmlAttribute]
        public Nullable<decimal> PurchaseCost { get; set; }
        [XmlAttribute]
        public Nullable<decimal> SalesAmount { get; set; }
        [XmlAttribute]
        public Nullable<decimal> SalesCost { get; set; }
        [XmlAttribute]
        public Nullable<decimal> WriteoffAmount { get; set; }
        [XmlAttribute]
        public Nullable<decimal> WriteoffCost { get; set; }
        [XmlAttribute]
        public Nullable<decimal> ReturnsAmount { get; set; }
        [XmlAttribute]
        public Nullable<decimal> ReturnsCost { get; set; }
        [XmlIgnore]
        public Nullable<decimal> TotalAmount
        {
            get
            {
                return StartAmount.GetValueOrDefault() + PurchaseAmount.GetValueOrDefault() - SalesAmount.GetValueOrDefault() - WriteoffAmount.GetValueOrDefault() + ReturnsAmount.GetValueOrDefault();
            }
        }
        [XmlIgnore]
        public Nullable<decimal> TotalCost
        {
            get
            {
                return StartCost.GetValueOrDefault() + PurchaseCost.GetValueOrDefault() - SalesCost.GetValueOrDefault() - WriteoffCost.GetValueOrDefault() + ReturnsCost.GetValueOrDefault();
            }
        }
    }
}
