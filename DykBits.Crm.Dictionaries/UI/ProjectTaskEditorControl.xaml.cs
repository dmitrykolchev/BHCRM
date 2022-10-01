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

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for ContractEditorControl.xaml
    /// </summary>
    public partial class ProjectTaskEditorControl : EditorControlBase
    {
        public ProjectTaskEditorControl()
        {
            InitializeComponent();
        }

        private ProjectTask Document
        {
            get { return (ProjectTask)this.DataSource; }
        }

        protected override void OnDataSourceChanged(DataSourceChangedEventArgs e)
        {
            base.OnDataSourceChanged(e);
            var document = e.OldDataSource as ProjectTask;
            if(document != null)
                document.PropertyChanged -= document_PropertyChanged;
            document = e.NewDataSource as ProjectTask;
            if(document != null)
                document.PropertyChanged += document_PropertyChanged;
        }

        void document_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == ProjectTask.ProjectTaskStatusIdProperty)
            {
                if (Document.ProjectTaskStatusId != null)
                {
                    var taskStatus = DocumentManager.GetItem<ProjectTaskStatus>(Document.ProjectTaskStatusId.Value);
                    Document.ProjectTaskStatus = taskStatus.Comments;
                    Document.Complete = taskStatus.Complete;
                }
            }
            else if (e.PropertyName == ProjectTask.ProjectMemberRoleIdProperty || e.PropertyName == ProjectTask.ProjectIdProperty)
            {
                if (Document.ProjectId != 0 && Document.ProjectMemberRoleId.HasValue)
                {
                    EmployeeFilter filter = new EmployeeFilter { ProjectId = Document.ProjectId, ProjectMemberRoleId = Document.ProjectMemberRoleId };
                    var items = DocumentManager.Browse<EmployeeView>(filter);
                    if (items.Count == 1)
                        Document.AssignedToEmployeeId = items[0].Id;
                    else
                        Document.AssignedToEmployeeId = null;
                }
            }   
        }

        private void DocumentPicker_RequestFilterData(object sender, RequestFilterDataEventArgs e)
        {
            EmployeeFilter filter = e.DataSourceFilter as EmployeeFilter;
            filter.ProjectId = Document.ProjectId;
            filter.ProjectMemberRoleId = Document.ProjectMemberRoleId;
        }
    }
}
