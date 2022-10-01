using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Diagnostics;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [DebuggerDisplay("{FileAs}[{Id}]")]
    public abstract class DataItemView : DataItemBase, IDataItem
    {
        private byte _StateField;
        private string _FileAsField;
        private string _CommentsField;

        protected DataItemView()
        {
        }
        public override DocumentState GetDocumentState()
        {
            return this.Metadata.States.GetById(((IDataItem)this).State);
        }

        [XmlIgnore]
        public override bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        public bool IsNew
        {
            get
            {
                return this._StateField == 0;
            }
        }
        [XmlIgnore]
        byte IDataItem.State
        {
            get
            {
                return (byte)this._StateField;
            }
            set
            {
                this._StateField = value;
            }
        }
        [XmlAttribute]
        public string FileAs
        {
            get
            {
                return this._FileAsField;
            }
            set
            {
                this._FileAsField = value;
            }
        }
        [XmlAttribute]
        public string Comments
        {
            get
            {
                return this._CommentsField;
            }
            set
            {
                this._CommentsField = value;
            }
        }
        public override string ToString()
        {
            return string.Format("{0}[{1}]", FileAs, Id);
        }
    }
}
