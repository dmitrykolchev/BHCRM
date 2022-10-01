using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Dynamic;
using DykBits.Crm.Data;
using DykBits.Crm.UI;

namespace DykBits.Crm.UI.Operations
{
    /// <summary>
    /// Interaction logic for OperatingBudgetGridControl.xaml
    /// </summary>
    public partial class OperatingBudgetGridControl : DataGridControlBase
    {
        public OperatingBudgetGridControl()
        {
            InitializeComponent();
        }

        protected override void CreateItem()
        {
            dynamic data = new ExpandoObject();

            data.DocumentDate = DateTime.Today;
            IEmployeeInfo employee = SecurityManager.GetCurrentEmployee();
            data.OrganizationId = employee.OrganizationId;

            ModalWindow dialog = ModalWindow.Create("Создать бюджет операционных расходов", new OperatingBudgetCreateControl(), data, ParentWindow);
            try
            {
                if (dialog.ShowDialog() == true)
                {
                    OperatingBudget document = CreateOperatingBudget(data);

                    WindowManager.OpenDocument(document);
                }
            }
            finally
            {
                dialog.Close();
            }
        }

        private OperatingBudget CreateOperatingBudget(dynamic data)
        {
            OperatingBudgetDataAdapterProxy dataAdapter = new OperatingBudgetDataAdapterProxy();
            var document = dataAdapter.CreateItem(null);
            document.OrganizationId = data.OrganizationId;
            document.DocumentDate = data.DocumentDate;
            return dataAdapter.Save(document);
        }
    }
}
