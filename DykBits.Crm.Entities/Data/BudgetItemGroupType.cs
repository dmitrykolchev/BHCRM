using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class BudgetItemGroupType: DataItemView
    {
        public const int ProjectsGroup = 1;
        public const int OperationsGroup = 2;
        public const int MiscGroup = 3;

        public override string DataItemClass
        {
            get { return "BudgetItemGroupType"; }
        }

        public static BudgetItemGroupType ProjectsGroupItem = new BudgetItemGroupType { Id = ProjectsGroup, FileAs = "Проектная деятельность" };
        public static BudgetItemGroupType OperationsGroupItem = new BudgetItemGroupType { Id = OperationsGroup, FileAs = "Операционная деятельность" };
        public static BudgetItemGroupType MiscGroupItem = new BudgetItemGroupType { Id = MiscGroup, FileAs = "Прочее" };
    }
}
