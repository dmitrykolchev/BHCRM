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
using DykBits.Crm.Input;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for EstimatesDocumentGridControl.xaml
    /// </summary>
    public partial class EstimatesDocumentGridControl : DataGridControlBase
    {
        public EstimatesDocumentGridControl()
        {
            InitializeComponent();
        }

        protected override void CreateItem()
        {
            dynamic data = new ExpandoObject();
            data.EstimatesTemplate = null;
            ModalWindow dialog = ModalWindow.Create("Выберите шаблон сметы", new EstimatesTemplateSelectorControl(), data, ParentWindow);
            try
            {
                if (dialog.ShowDialog() == true)
                {
                    EstimatesTemplate template = DocumentManager.GetItem<EstimatesTemplate>(data.EstimatesTemplate.Id);
                    EstimatesDocument document = DocumentManager.CreateItem<EstimatesDocument>(null);
                    foreach (var section in template.Sections)
                    {
                        document.Sections.Add(new EstimatesDocumentSection
                        {
                            FileAs = section.FileAs,
                            OrdinalPosition = section.OrdinalPosition,
                            ProductCategoryId = section.ProductCategoryId,
                            Comments = section.Comments
                        });
                    }
                    WindowManager.OpenDocument(document);
                }
            }
            finally
            {
                dialog.Close();
            }
        }
    }
}
