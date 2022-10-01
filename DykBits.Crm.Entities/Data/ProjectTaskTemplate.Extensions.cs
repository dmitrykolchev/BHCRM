using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DykBits.Crm.Data
{
    partial class ProjectTaskTemplate: IDataErrorInfo
    {
        protected override string ValidateProperty(PropertyInfo propertyInfo, ColumnAttribute columnAttribute)
        {
            if (propertyInfo.Name == ProjectMemberRoleIdProperty)
            {
                if (ProjectMemberRoleId <= 0)
                    return "Выберите значение из списка";
            }
            return base.ValidateProperty(propertyInfo, columnAttribute);
        }
    }
}
