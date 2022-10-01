using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute()
        {
            this.MaximumLength = -1;
        }
        public int MaximumLength { get; set; }
        public bool IsNullable { get; set; }
        public string Name { get; set; }
    }
}
