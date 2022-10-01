using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.UI
{
    public class PresentationExtensionType
    {
        public PresentationExtensionType()
        {
        }

        public object Parameter
        {
            get;
            set;
        }

        public PresentationNode Node
        {
            get;
            internal set;
        }

        public Type ExtensionType
        {
            get;
            set;
        }
    }
}
