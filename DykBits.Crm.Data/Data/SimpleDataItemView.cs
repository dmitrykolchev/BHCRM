using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class SimpleDataItemView: DataItemView
    {
        public SimpleDataItemView()
        {
        }

        public override string DataItemClass
        {
            get { return "SimpleDataItem"; }
        }

        public override DocumentState GetDocumentState()
        {
            return this.Metadata.States.GetById(this.State);
        }

        public byte State
        {
            get
            {
                return ((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = value;
            }
        }
    }
}
