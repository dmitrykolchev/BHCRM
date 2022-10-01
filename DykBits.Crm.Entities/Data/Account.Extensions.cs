using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(MarketingProgramTypeSelector))]
    [TypeMapping(typeof(ReasonSelector))]
    partial class Account
    {
        private ObservableCollectionWithRefresh<ContactView> _contacts;
        private ObservableCollection<MarketingProgramTypeSelector> _marketingProgramTypes;
        private ObservableCollection<ReasonSelector> _reasons;

        [XmlIgnore]        
        public ObservableCollectionWithRefresh<ContactView> Contacts
        {
            get
            {
                if (this._contacts == null)
                {
                    this._contacts = new ObservableCollectionWithRefresh<ContactView>(() =>
                    {
                        IDataAdapter dataAdapter = DocumentManager.CreateDataAdapterProxy<Contact>();
                        Filter filter = dataAdapter.CreateFilter(this, null);
                        return (IList<ContactView>)dataAdapter.Browse(filter.ToXml());
                    });
                }
                return this._contacts;
            }
        }

        public ObservableCollection<MarketingProgramTypeSelector> MarketingProgramTypes
        {
            get
            {
                if (this._marketingProgramTypes == null)
                {
                    this._marketingProgramTypes = new ObservableCollection<MarketingProgramTypeSelector>();
                    this._marketingProgramTypes.CollectionChanged += _marketingProgramTypes_CollectionChanged;
                }
                return this._marketingProgramTypes;
            }
        }

        void _marketingProgramTypes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach(MarketingProgramTypeSelector item in e.NewItems)
                item.PropertyChanged += item_PropertyChanged;
            InvokePropertyChanged("MarketingProgramTypes");
        }

        void item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            InvokePropertyChanged("MarketingProgramTypes");
        }

        public ObservableCollection<ReasonSelector> Reasons
        {
            get
            {
                if (this._reasons == null)
                {
                    this._reasons = new ObservableCollection<ReasonSelector>();
                    this._reasons.CollectionChanged += _reasons_CollectionChanged;
                }
                return this._reasons;
            }
        }

        void _reasons_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (ReasonSelector reason in e.NewItems)
                reason.PropertyChanged += reason_PropertyChanged;
            InvokePropertyChanged("Reasons");
        }

        void reason_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            InvokePropertyChanged("Reasons");
        }
    }
}
