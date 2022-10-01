using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class AccountChangeAccessData : NotifyObject
    {
        private bool _updateAccountManager;
        private Nullable<int> _assignedToEmployeeId;
        private bool _updateAssistant;
        private Nullable<int> _assistantEmployeeId;
        private bool _changeAccess;
        private bool _denyAccess;
        private Nullable<int> _denyEmployeeId;
        private bool _allowAccess;
        private Nullable<int> _allowEmployeeId;
        private int _documentAccessTypeId;
        private DateTime _startDate;
        private Nullable<DateTime> _endDate;
        private IEnumerable<IDataItem> _accounts;


        public AccountChangeAccessData()
        {
            this.StartDate = DateTime.Today;
            this.EndDate = DateTime.Today;
            this.DocumentAccessTypeId = DocumentAccessType.DocumentAccessTypeGeneral;
        }

        public bool UpdateAccountManager
        {
            get { return _updateAccountManager; }
            set
            {
                _updateAccountManager = value;
                InvokePropertyChanged();
            }
        }

        public Nullable<int> AssignedToEmployeeId
        {
            get { return this._assignedToEmployeeId; }
            set
            {
                this._assignedToEmployeeId = value;
                InvokePropertyChanged();
            }
        }

        public bool UpdateAssistant
        {
            get { return this._updateAssistant; }
            set
            {
                this._updateAssistant = value;
                InvokePropertyChanged();
            }
        }
        public Nullable<int> AssistantEmployeeId
        {
            get { return this._assistantEmployeeId; }
            set
            {
                this._assistantEmployeeId = value;
                InvokePropertyChanged();
            }
        }

        public bool ChangeAccess
        {
            get { return this._changeAccess; }
            set
            {
                this._changeAccess = value;
                InvokePropertyChanged();
                if (!value)
                {
                    DenyAccess = false;
                    AllowAccess = false;
                }
            }
        }

        public bool DenyAccess
        {
            get { return this._denyAccess; }
            set
            {
                this._denyAccess = value;
                InvokePropertyChanged();
            }
        }

        public Nullable<int> DenyEmployeeId
        {
            get { return this._denyEmployeeId; }
            set
            {
                this._denyEmployeeId = value;
                InvokePropertyChanged();
            }
        }

        public bool AllowAccess
        {
            get { return this._allowAccess; }
            set
            {
                this._allowAccess = value;
                InvokePropertyChanged();
            }
        }
        public Nullable<int> AllowEmployeeId
        {
            get { return this._allowEmployeeId; }
            set
            {
                this._allowEmployeeId = value;
                InvokePropertyChanged();
            }
        }

        public int DocumentAccessTypeId
        {
            get { return this._documentAccessTypeId; }
            set
            {
                this._documentAccessTypeId = value;
                InvokePropertyChanged();
                InvokePropertyChanged("EndDateVisible");
            }
        }

        public DateTime StartDate
        {
            get { return this._startDate; }
            set
            {
                this._startDate = value;
                InvokePropertyChanged();
            }
        }
        public Nullable<DateTime> EndDate
        {
            get { return this._endDate; }
            set
            {
                this._endDate = value;
                InvokePropertyChanged();
            }
        }

        public List<ItemId> AccountIds
        {
            get { return this.Accounts.Select(t => new ItemId(t.Id)).ToList(); }
        }

        [XmlIgnore]
        public bool EndDateVisible
        {
            get { return this.DocumentAccessTypeId == DocumentAccessType.DocumentAccessTypeTemporary; }
        }

        [XmlIgnore]
        public IEnumerable<IDataItem> Accounts
        {
            get { return this._accounts; }
            set
            {
                this._accounts = value;
                InvokePropertyChanged();
            }
        }
    }
}
