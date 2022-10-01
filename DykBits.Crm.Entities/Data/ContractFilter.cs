using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DykBits.Crm.Data
{
    partial class ContractFilter
    {
        public Nullable<int> OrganizationId { get; set; }
        public Nullable<int> AccountId { get; set; }
        public Nullable<int> ParentContractId { get; set; }

        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)ContactState.Active };
            if (dataContext is Account)
            {
                this.AccountId = ((Account)dataContext).Id;
            }
            else if (dataContext is Organization)
            {
                this.OrganizationId = ((Organization)dataContext).Id;
            }
            else if (dataContext is Contract)
            {
                this.ParentContractId = ((Contract)dataContext).Id;
            }
        }
    }
}
