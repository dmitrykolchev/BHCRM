using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class BudgetItemGroupTypeDataAdapterProxy: ViewDataAdapterProxy<BudgetItemGroupType, EmptyFilter>
    {
        protected override IList<BudgetItemGroupType> BrowseOverride(System.Xml.Linq.XElement filter)
        {
            return new BudgetItemGroupType[] { BudgetItemGroupType.ProjectsGroupItem, BudgetItemGroupType.OperationsGroupItem, BudgetItemGroupType.MiscGroupItem };         
        }
        protected override IList<BudgetItemGroupType> GetListOverride(System.Xml.Linq.XElement filter)
        {
            return new BudgetItemGroupType[] { BudgetItemGroupType.ProjectsGroupItem, BudgetItemGroupType.OperationsGroupItem, BudgetItemGroupType.MiscGroupItem };         
        }
    }
}
