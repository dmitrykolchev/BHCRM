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

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for BudgetGridControl.xaml
    /// </summary>
    public partial class BudgetGridControl : DataGridControlBase
    {
        public BudgetGridControl()
        {
            InitializeComponent();
        }

        protected override void CreateItem()
        {
            dynamic data = new ExpandoObject();
            data.BudgetTemplate = null;
            if (this.DataContext is ServiceRequest)
                data.ServiceRequestId = ((ServiceRequest)this.DataContext).Id;
            else
                data.ServiceRequestId = null;
            ModalWindow dialog = ModalWindow.Create("Выберите шаблон ПРС", new BudgetTemplateSelectorControl(), data, ParentWindow);
            try
            {
                if (dialog.ShowDialog() == true)
                {
                    ServiceRequest serviceRequest = DocumentManager.GetItem<ServiceRequest>(data.ServiceRequestId);
                    BudgetTemplate template = DocumentManager.GetItem<BudgetTemplate>(data.BudgetTemplate.Id);

                    Budget budget = CreateBudget(serviceRequest, template);

                    WindowManager.OpenDocument(budget);
                }
            }
            finally
            {
                dialog.Close();
            }
        }

        private Budget CreateBudget(ServiceRequest serviceRequest, BudgetTemplate budgetTemplate)
        {
            using (new WaitCursor())
            {
                Budget budget = budgetTemplate.CreateBudget(serviceRequest);
                DocumentManager.InvokeDocumentOperationComplete(DocumentOperation.Save, budget);
                return budget;
            }
        }
    }
}
