using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class ProjectMemberChangeData: NotifyObject
    {
        private IEnumerable<IDataItem> _items;
        private bool _includeInProject;
        private int _employeeId;
        private int _projectMemberRoleId;
        public bool IncludeInProject
        {
            get { return this._includeInProject; }
            set
            {
                this._includeInProject = value;
                InvokePropertyChanged();
                InvokePropertyChanged("ExcludeFromProject");
            }
        }

        public bool ExcludeFromProject
        {
            get { return !this._includeInProject; }
            set
            {
                this._includeInProject = !value;
                InvokePropertyChanged();
                InvokePropertyChanged("IncludeInProject");
            }
        }

        public int EmployeeId
        {
            get { return this._employeeId; }
            set
            {
                this._employeeId = value;
                InvokePropertyChanged();
            }
        }

        public int ProjectMemberRoleId
        {
            get { return this._projectMemberRoleId; }
            set
            {
                this._projectMemberRoleId = value;
                InvokePropertyChanged();
            }
        }

        public List<ItemId> ItemIds
        {
            get { return this.Items.Select(t => new ItemId(t.Id)).ToList(); }
        }


        [XmlIgnore]
        public IEnumerable<IDataItem> Items
        {
            get { return this._items; }
            set
            {
                this._items = value;
                InvokePropertyChanged();
            }
        }
    }
}
