using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class BalanceSheetLine: XmlSerializableDataItem
    {
        public const int MoneyNonCashAsset = 1;
        public const int MoneyCashAsset = 2;
        public const int AdvanceAsset = 3;
        public const int CreditLiability = 4;
        public const int ProductsInStock = 5;
        public const int ProjectPurchase = 6;
        public const int OperatingPurchase = 7;
        public const int OtherPurchase = 8;
        public const int CustomersAsset = 9;
        public int LineId { get; set; }
        public Nullable<decimal> AssetValue { get; set; }
        public Nullable<decimal> LiabilityValue { get; set; }
    }
}
