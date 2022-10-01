using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DykBits.Crm.Data
{
    partial class ContactFilter
    {
        public Nullable<int> AccountId { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)ContactState.Active };
            this.AccountId = null;
            if (dataContext is Account)
                this.AccountId = ((Account)dataContext).Id;
            else if (dataContext is Venue)
                this.AccountId = ((Venue)dataContext).Id;
        }
    }
}
