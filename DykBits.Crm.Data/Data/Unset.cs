using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public sealed class Unset
    {
        public static readonly Unset Value = new Unset();
        private Unset()
        {
        }
    }
}
