using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Grid;

namespace DykBits.Crm.UI
{
    public class StandardTableView: TableView
    {
        public StandardTableView()
        {
                //<dxg:TableView AllowMoveColumnToDropArea="True" AllowEditing="False" AutoWidth="True" ShowGroupedColumns="True" ShowTotalSummary="True" MultiSelectMode="Row" 
                //               GroupValueTemplate="{StaticResource customGroupValueTemplate}" GroupSummaryItemTemplateSelector="{StaticResource hiddenSummaryTemplateSelector}"
                //               ShowGroupFooters="True" />
            this.AllowMoveColumnToDropArea = true;
            this.AllowEditing = false;
            this.AutoWidth = true;
            this.ShowGroupedColumns = true;
            this.UseAnimationWhenExpanding = false;
            this.GroupValueTemplate = StandardResources.Get<DataTemplate>("customGroupValueTemplate");
            this.GroupSummaryItemTemplateSelector = new HiddenSummaryTemplateSelector();
        }
    }
}
