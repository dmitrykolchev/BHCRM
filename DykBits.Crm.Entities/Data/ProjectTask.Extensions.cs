using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Xml.Serialization;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(ProjectTaskStatusEntry))]
    partial class ProjectTask
    {
        private List<ProjectTaskStatusEntry> _statuses;
        public Nullable<int> Color { get; set; }
        public bool UpdateStatus { get; set; }

        private bool _recursive;

        partial void NotifyPropertyChangedInternal(string propertyName)
        {
            if (!this._recursive)
            {
                this._recursive = true;
                try
                {
                    if (propertyName == ProjectTask.ProjectTaskStatusIdProperty || propertyName == ProjectTaskStatusProperty)
                    {
                        UpdateStatus = true;
                    }
                    else if (propertyName == TaskStartProperty)
                    {
                        if (this.TaskStart > this.TaskFinish)
                            this.TaskFinish = this.TaskStart;
                    }
                    else if (propertyName == TaskFinishProperty)
                    {
                        if (this.TaskStart > this.TaskFinish)
                            this.TaskStart = this.TaskFinish;
                    }
                }
                finally
                {
                    this._recursive = false;
                }
            }
        }

        protected override void OnDeserialized()
        {
            UpdateStatus = false;
        }

        public List<ProjectTaskStatusEntry> Statuses
        {
            get
            {
                if (this._statuses == null)
                    this._statuses = new List<ProjectTaskStatusEntry>();
                return this._statuses;
            }
        }

        protected override string ValidateProperty(System.Reflection.PropertyInfo propertyInfo, ColumnAttribute columnAttribute)
        {
            if (propertyInfo.Name == ProjectMemberRoleIdProperty)
            {
                if (!ProjectMemberRoleId.HasValue)
                    return "Необходимо выбрать роль участника проекта";
            }
            else if (propertyInfo.Name == ProjectIdProperty)
            {
                if (ProjectId == 0)
                    return "Необходимо выбрать проект";
            }
            return base.ValidateProperty(propertyInfo, columnAttribute);
        }
    }
}
