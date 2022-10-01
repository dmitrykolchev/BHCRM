using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class ContractView
    {
        public bool IsContractAnnex
        {
            get { return this.ParentContractId.HasValue; }
        }

        public bool IsContract
        {
            get { return !this.ParentContractId.HasValue; }
        }

    }
}
