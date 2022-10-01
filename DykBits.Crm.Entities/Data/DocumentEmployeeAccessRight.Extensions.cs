using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    partial class DocumentEmployeeAccessRight
    {
        [XmlIgnore]
        public bool EndDateVisible
        {
            get
            {
                return this.DocumentAccessTypeId == DocumentAccessType.DocumentAccessTypeTemporary;
            }
        }

        partial void NotifyPropertyChangedInternal(string propertyName)
        {
            if (propertyName == DocumentAccessTypeIdProperty)
            {
                InvokePropertyChanged("EndDateVisible");
                if (this.DocumentAccessTypeId == DocumentAccessType.DocumentAccessTypeTemporary && !this.EndDate.HasValue)
                {
                    if (this.StartDate.HasValue)
                        this.EndDate = this.StartDate;
                    else
                        this.EndDate = DateTime.Today;
                }
            }
        }

        protected override string ValidateProperty(System.Reflection.PropertyInfo propertyInfo, ColumnAttribute columnAttribute)
        {
            if (propertyInfo.Name == DocumentEmployeeAccessRight.StartDateProperty)
            {
                if (!this.StartDate.HasValue)
                    return "Необходимо указать дату начала";
            }
            else if (propertyInfo.Name == DocumentEmployeeAccessRight.EndDateProperty)
            {
                if (this.DocumentAccessTypeId == DocumentAccessType.DocumentAccessTypeTemporary && !this.EndDate.HasValue)
                    return "Необходимо указать дату окончания";
            }
            return base.ValidateProperty(propertyInfo, columnAttribute);
        }
    }
}
