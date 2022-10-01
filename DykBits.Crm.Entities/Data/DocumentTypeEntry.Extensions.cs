using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    partial class DocumentTypeEntry
    {
        private ObservableCollection<DocumentStateEntryView> _states;


        [XmlIgnore]
        public ObservableCollection<DocumentStateEntryView> States
        {
            get
            {
                if (this._states == null)
                {
                    this._states = LoadStates();
                }
                return this._states;
            }
        }

        private ObservableCollection<DocumentStateEntryView> LoadStates()
        {
            IDataAdapter dataAdapter = DocumentManager.CreateDataAdapterProxy<DocumentStateEntry>();
            Filter filter = dataAdapter.CreateFilter(this, null);
            return new ObservableCollection<DocumentStateEntryView>(dataAdapter.Browse(filter.ToXml()).OfType<DocumentStateEntryView>().OrderBy(t => t.Value));
        }

        [XmlIgnore]
        public string ClassNameUI
        {
            get { return this.ClassName; }
            set
            {
                this.ClassName = value;
                InvokePropertyChanged();
                this.DataAdapterTypeName = string.Format("DykBits.Crm.Data.{0}DataAdapter,DykBits.Crm.DataAdapters", this.ClassName);
                this.TableName = this.ClassName;
                this.ClrTypeName = string.Format("DykBits.Crm.Data.{0},DykBits.Crm.Entities", this.ClassName);
            }
        }
    }
}
