using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class BalanceItemDataAdapterProxy : XmlViewDataAdapterBase<BalanceItem, BalanceSheetFilter>
    {
        protected override IList<BalanceItem> BrowseOverride(System.Xml.Linq.XElement filter)
        {
            var balanceSheetDataAdapter = new BalanceSheetLineDataAdapterProxy();
            var balanceLines = balanceSheetDataAdapter.Browse(filter);

            var factory = new BalanceItemFactory();
            var customersGroup = factory.CreateInstance("Покупатели");
            var customersItem = factory.CreateInstance("Покупатели", customersGroup); customersItem.Level = 3;
            var purchaseGroup = factory.CreateInstance("Поставщики");
            var projPurchaseItem = factory.CreateInstance("Поcтавщики по ПРС", purchaseGroup); projPurchaseItem.Level = 3;
            var operPurchaseItem = factory.CreateInstance("Поcтавщики по операционным расходам", purchaseGroup); operPurchaseItem.Level = 3;
            var otherPurchaseItem = factory.CreateInstance("Поcтавщики склад", purchaseGroup); otherPurchaseItem.Level = 3;
            var stockGroup = factory.CreateInstance("Склад");
            var productsInStockItem = factory.CreateInstance("Остатки на складе", stockGroup); productsInStockItem.Level = 3;
            var moneyGroup = factory.CreateInstance("Денежные средства");
            var nonCashItem = factory.CreateInstance("Расчетный счет", moneyGroup); nonCashItem.Level = 3;
            var cashItem = factory.CreateInstance("Касса", moneyGroup); cashItem.Level = 3;
            var advanceItem = factory.CreateInstance("Денежные средства выданные под отчет", moneyGroup); advanceItem.Level = 3;
            var creditItem = factory.CreateInstance("Обязательства по кредитам", moneyGroup); creditItem.Level = 3;
            var profitItem = factory.CreateInstance("Прибыль/убыток");
            var totalItem = factory.CreateInstance("Итого");

            foreach (var balanceLine in balanceLines)
            {
                BalanceItem item = null;
                switch (balanceLine.LineId)
                {
                    case BalanceSheetLine.MoneyCashAsset:
                        item = cashItem;
                        item.AssetValue = balanceLine.AssetValue;
                        item.LiabilityValue = balanceLine.LiabilityValue;
                        break;
                    case BalanceSheetLine.MoneyNonCashAsset:
                        item = nonCashItem;
                        item.AssetValue = balanceLine.AssetValue;
                        item.LiabilityValue = balanceLine.LiabilityValue;
                        break;
                    case BalanceSheetLine.AdvanceAsset:
                        item = advanceItem;
                        item.AssetValue = balanceLine.AssetValue;
                        item.LiabilityValue = balanceLine.LiabilityValue;
                        break;
                    case BalanceSheetLine.CreditLiability:
                        item = creditItem;
                        item.AssetValue = balanceLine.AssetValue;
                        item.LiabilityValue = balanceLine.LiabilityValue;
                        break;
                    case BalanceSheetLine.ProductsInStock:
                        item = productsInStockItem;
                        item.AssetValue = balanceLine.AssetValue;
                        item.LiabilityValue = balanceLine.LiabilityValue;
                        break;
                    case BalanceSheetLine.ProjectPurchase:
                        item = projPurchaseItem;
                        item.AssetValue = balanceLine.AssetValue;
                        item.LiabilityValue = balanceLine.LiabilityValue;
                        break;
                    case BalanceSheetLine.OperatingPurchase:
                        item = operPurchaseItem;
                        item.AssetValue = balanceLine.AssetValue;
                        item.LiabilityValue = balanceLine.LiabilityValue;
                        break;
                    case BalanceSheetLine.OtherPurchase:
                        item = otherPurchaseItem;
                        item.AssetValue = balanceLine.AssetValue;
                        item.LiabilityValue = balanceLine.LiabilityValue;
                        break;
                    case BalanceSheetLine.CustomersAsset:
                        item = customersItem;
                        item.AssetValue = balanceLine.AssetValue;
                        item.LiabilityValue = balanceLine.LiabilityValue;
                        break;
                }
                if (item != null)
                {
                    item.Parent.AssetValue = item.Parent.AssetValue.Add(item.AssetValue);
                    item.Parent.LiabilityValue = item.Parent.LiabilityValue.Add(item.LiabilityValue);
                    totalItem.AssetValue = totalItem.AssetValue.Add(item.AssetValue);
                    totalItem.LiabilityValue = totalItem.LiabilityValue.Add(item.LiabilityValue);
                }
            }
            
            if (totalItem.AssetValue.GetValueOrDefault() != totalItem.LiabilityValue.GetValueOrDefault())
            {
                decimal profit = totalItem.AssetValue.GetValueOrDefault() - totalItem.LiabilityValue.GetValueOrDefault();
                //if (profit > 0)
                    profitItem.LiabilityValue = profit;
                //else if (profit < 0)
                //    profitItem.AssetValue = profit;
                totalItem.AssetValue = totalItem.AssetValue.Add(profitItem.AssetValue);
                totalItem.LiabilityValue = totalItem.LiabilityValue.Add(profitItem.LiabilityValue);
            }
            return factory.List;
        }
    }
}
