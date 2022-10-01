using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(DocumentTransitionAccess))]
    partial class DocumentTransition
    {
        private ObservableCollection<DocumentTransitionAccess> _roles;
        public ObservableCollection<DocumentTransitionAccess> Roles
        {
            get
            {
                if (this._roles == null)
                {
                    this._roles = new ObservableCollection<DocumentTransitionAccess>();
                    this._roles.CollectionChanged += _roles_CollectionChanged;
                }
                return this._roles;
            }
        }

        void _roles_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Roles");
        }

        [XmlIgnore]
        public int DocumentTypeIdUI
        {
            get { return this.DocumentTypeId; }
            set
            {
                this.DocumentTypeId = value;
                this.FromStateUI = 0;
                this.ToStateUI = 0;
                this._states = null;
                InvokePropertyChanged("States");
                InvokePropertyChanged();
            }
        }

        private IList<DocumentStateEntryView> _states;

        [XmlIgnore]
        public IList<DocumentStateEntryView> States
        {
            get
            {
                if (this._states == null)
                {
                    DocumentStateEntryFilter filter = new DocumentStateEntryFilter { AllStates = true, DocumentTypeId = this.DocumentTypeId };
                    this._states = DocumentManager.Browse<DocumentStateEntryView>(filter);
                }
                return this._states;
            }
        }

        [XmlIgnore]
        public byte FromStateUI
        {
            get { return this.FromState; }
            set
            {
                this.FromState = value;
                UpdateFileAs();
                InvokePropertyChanged();
            }
        }
        [XmlIgnore]
        public byte ToStateUI
        {
            get { return this.ToState; }
            set
            {
                this.ToState = value;
                UpdateFileAs();
                InvokePropertyChanged();
            }
        }
        private void UpdateFileAs()
        {
            var fromState = States.Where(t => t.Value == this.FromState).FirstOrDefault();
            var toState = States.Where(t => t.Value == this.ToState).FirstOrDefault();
            if (fromState != null && toState != null)
                this.FileAsUI = string.Format("{0} -> {1}", fromState.FileAs, toState.FileAs);
        }
        [XmlIgnore]
        public string FileAsUI
        {
            get { return this.FileAs; }
            set
            {
                this.FileAs = value;
                InvokePropertyChanged();
            }
        }
    }
}
