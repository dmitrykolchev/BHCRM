using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public abstract class NumberedDataItem : DataItem, INumberedDataItem
    {
        public const string NumberProperty = "Number";
        public const string DocumentDateProperty = "DocumentDate";
        public const string OrganizationIdProperty = "OrganizationId";

        private string _NumberField;
        private DateTime _DocumentDateField;
        private int _OrganizationIdField;
        protected NumberedDataItem()
        {
        }
        [Column(Name = "Number", IsNullable = false, MaximumLength = 32)]
        public string Number
        {
            get { return this._NumberField; }
            set
            {
                this._NumberField = value;
                InvokePropertyChanged();
            }
        }
        [Column(Name = "DocumentDate", IsNullable = false)]
        public DateTime DocumentDate
        {
            get { return this._DocumentDateField; }
            set
            {
                this._DocumentDateField = value;
                InvokePropertyChanged();
            }
        }
        [Column(Name = "OrganizationId", IsNullable = false)]
        public int OrganizationId
        {
            get { return this._OrganizationIdField; }
            set
            {
                this._OrganizationIdField = value;
                InvokePropertyChanged();
            }
        }
    }
}
