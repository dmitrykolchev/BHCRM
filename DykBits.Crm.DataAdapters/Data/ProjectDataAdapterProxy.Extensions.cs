using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class ProjectDataAdapterProxy
    {
        protected override Project CreateItemOverride(object dataContext)
        {
            Project document = base.CreateItemOverride(dataContext);
            document.StartDate = DateTime.Today;
            document.EndDate = DateTime.Today;
            document.ProjectTypeId = ProjectType.Commercial;
            IEmployeeInfo employee = SecurityManager.GetCurrentEmployee();
            document.ProjectManagerId = employee.Id;
            document.OrganizationId = employee.OrganizationId;
            return document;
        }
        public static void CreateTasksFromProjectTemplate(ServiceRequest serviceRequest, int projectTemplateId)
        {
            if (serviceRequest == null)
                throw new ArgumentNullException("serviceRequest");
            var project = DocumentManager.GetItem<Project>(serviceRequest.ProjectId);
            CreateTasksFromProjectTemplate(project, projectTemplateId);
        }
        public static void CreateTasksFromProjectTemplate(Project project, int projectTemplateId)
        {
            if (project == null)
                throw new ArgumentNullException("project");
            ProjectTaskTemplateDataAdapterProxy projectTaskTemplateDataAdapter = new ProjectTaskTemplateDataAdapterProxy();
            ProjectTaskDataAdapterProxy projectTaskDataAdapter = new ProjectTaskDataAdapterProxy();

            ProjectTaskTemplateFilter filter = (ProjectTaskTemplateFilter) projectTaskTemplateDataAdapter.CreateFilter(null, null);
            filter.ProjectTemplateId = projectTemplateId;
            var taskTemplates = projectTaskTemplateDataAdapter.Browse(filter.ToXml());
            foreach (var taskTemplate in taskTemplates)
            {
                var task = projectTaskDataAdapter.CreateItem(project);
                task.TaskNo = taskTemplate.TaskNo;
                task.TaskStart = project.StartDate + TimeSpan.FromDays(taskTemplate.TaskStartOffset);
                task.TaskFinish = task.TaskStart + TimeSpan.FromDays(taskTemplate.TaskDuration);
                task.FileAs = taskTemplate.FileAs;
                task.Importance = taskTemplate.Importance;
                task.ProjectMemberRoleId = taskTemplate.ProjectMemberRoleId;
                task.IsMilestone = taskTemplate.IsMilestone;
                projectTaskDataAdapter.Save(task);
            }
        }
    }
}
