using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(EmployeeSalary))]
    partial class Employee: IEmployeeInfo
    {
        private EmployeeSalaryCollection _salaries;
        public EmployeeSalaryCollection Salaries
        {
            get
            {
                if (this._salaries == null)
                {
                    this._salaries = new EmployeeSalaryCollection(this);
                    this._salaries.CollectionChanged += _salaries_CollectionChanged;
                }
                return this._salaries;
            }
        }
        void _salaries_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Salaries");            
        }
        string IEmployeeInfo.FullName
        {
            get { return this.FileAs; }
        }
        int IEmployeeInfo.OrganizationId
        {
            get { return this.AccountId; }
        }
        int IEmployeeInfo.UserId
        {
            get { return this.UserId.Value; }
        }
        protected override string ValidateProperty(System.Reflection.PropertyInfo propertyInfo, ColumnAttribute columnAttribute)
        {
            if (propertyInfo.Name == AccountIdProperty)
            {
                if (this.AccountId == 0)
                    return "Необходимо указать организацию";
            }
            else if (propertyInfo.Name == FirstNameProperty || propertyInfo.Name == MiddleNameProperty || propertyInfo.Name == LastNameProperty)
            {
                if (string.IsNullOrEmpty(this.FirstName) && string.IsNullOrEmpty(this.MiddleName) && string.IsNullOrEmpty(this.LastName))
                    return "Необходимо ввести имя сотрудника";
            }
            return base.ValidateProperty(propertyInfo, columnAttribute);
        }
    }
}
