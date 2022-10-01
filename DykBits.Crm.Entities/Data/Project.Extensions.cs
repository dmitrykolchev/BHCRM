using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    partial class Project
    {
        private Nullable<int> _projectManagerId;
        private Nullable<int> _serviceRequestId;

        public Nullable<int> ServiceRequestId
        {
            get { return this._serviceRequestId; }
            set
            {
                this._serviceRequestId = value;
                InvokePropertyChanged();
            }
        }

        [XmlIgnore]
        public bool HasServiceRequest
        {
            get { return ServiceRequestId.HasValue; }
        }

        public Nullable<int> ProjectManagerId
        {
            get
            {
                return this._projectManagerId;
            }
            set
            {
                this._projectManagerId = value;
                InvokePropertyChanged();
            }
        }
        partial void NotifyPropertyChangedInternal(string propertyName)
        {
            if (propertyName == ProjectTypeIdProperty)
            {
                InvokePropertyChanged("IsCommercial");   
            }
        }

        public bool IsCommercial
        {
            get
            {
                return this.ProjectTypeId == 2;
            }
        }
    }
}
