using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm
{
    public class PresentationManager : PresentationNode
    {
        public PresentationManager()
        {
        }

        public string ClassName { get; set; }

        public override string Key
        {
            get
            {
                if (string.IsNullOrEmpty(base.Key))
                    return ClassName;
                return base.Key;
            }
            set
            {
                base.Key = value;
            }
        }
    }
}
