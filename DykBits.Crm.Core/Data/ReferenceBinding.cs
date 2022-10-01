using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace DykBits.Crm.Data
{
    public sealed class ReferenceBinding: Binding
    {
        private static readonly DocumentIdConverter ReferenceConverter = new DocumentIdConverter();

        public ReferenceBinding()
        {
            this.Converter = ReferenceConverter;
            this.Mode = BindingMode.OneWay;
        }
        public ReferenceBinding(string path)
            : base(path)
        {
            this.Converter = ReferenceConverter;
            this.Mode = BindingMode.OneWay;
        }
        public string ClassName
        {
            get
            {
                return this.ConverterParameter as string;
            }
            set
            {
                this.ConverterParameter = value;
            }
        }
    }
}
