using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(DocumentGenericRight), ElementName="Right")]
    partial class DocumentAccessControlList: IDocumentAccessControlList
    {
        private DocumentGenericRightCollection _rights;

        public DocumentGenericRightCollection Rights
        {
            get
            {
                if (this._rights == null)
                {
                    this._rights = new DocumentGenericRightCollection(this);
                    this._rights.CollectionChanged += _rights_CollectionChanged;
                }
                return this._rights;
            }
        }

        IList<IGenericRight> IDocumentAccessControlList.Rights
        {
            get
            {
                return Rights.OfType<IGenericRight>().ToArray();
            }
        }

        void _rights_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Rights");
        }

        internal void InvokeRightPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            InvokePropertyChanged("Rights");
        }
    }

    public class DocumentGenericRightCollection : ObservableCollection<DocumentGenericRight>
    {
        private DocumentAccessControlList _owner;
        internal DocumentGenericRightCollection(DocumentAccessControlList owner)
        {
            this._owner = owner;
        }

        protected override void InsertItem(int index, DocumentGenericRight item)
        {
            base.InsertItem(index, item);
            item.PropertyChanged += this._owner.InvokeRightPropertyChanged;
        }
    }
}
