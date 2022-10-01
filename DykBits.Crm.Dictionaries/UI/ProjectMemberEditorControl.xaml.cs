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
using DykBits.Crm.Data;
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for ContractEditorControl.xaml
    /// </summary>
    public partial class ProjectMemberEditorControl : EditorControlBase
    {
        public ProjectMemberEditorControl()
        {
            InitializeComponent();
        }

        private ProjectMember Document
        {
            get { return (ProjectMember)this.DataSource; }
        }

        protected override void OnDataSourceChanged(DataSourceChangedEventArgs e)
        {
            base.OnDataSourceChanged(e);
            base.OnDataSourceChanged(e);
            var document = e.OldDataSource as ProjectMember;
            if (document != null)
                document.PropertyChanged -= document_PropertyChanged;
            document = e.NewDataSource as ProjectMember;
            if (document != null)
                document.PropertyChanged += document_PropertyChanged;
        }

        void document_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == ProjectMember.EmployeeIdProperty)
            {
                if (Document.EmployeeId != null)
                    Document.FileAs = this.documentEmployee.SelectedItem.FileAs;
                else
                {
                    if(Document.ProjectMemberRoleId != 0)
                       Document.FileAs = ((IDataItem)comboRole.SelectedItem).FileAs;
                }
            }
            else if (e.PropertyName == ProjectMember.ProjectMemberRoleIdProperty)
            {
                if (Document.ProjectMemberRoleId != 0 && Document.EmployeeId == null)
                    Document.FileAs = ((IDataItem)comboRole.SelectedItem).FileAs;
            }
        }

        protected override void CanExecute(CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if(command != null)
            {
                if(command.Id == UICommandId.Create)
                {
                    e.CanExecute = false;
                    e.Handled= true;
                    return;
                }
            }
            base.CanExecute(e);
        }
    }
}
