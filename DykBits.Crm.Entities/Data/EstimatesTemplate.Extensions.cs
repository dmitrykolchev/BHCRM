using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(EstimatesTemplateSection))]
    partial class EstimatesTemplate
    {
        private EstimatesTemplateSectionCollection _sections;
        public EstimatesTemplateSectionCollection Sections
        {
            get
            {
                if (this._sections == null)
                {
                    this._sections = new EstimatesTemplateSectionCollection(this);
                    this._sections.CollectionChanged += _sections_CollectionChanged;
                }
                return this._sections;
            }
        }

        void _sections_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Sections");
            UpdateOrdinalPositions();
        }

        private void UpdateOrdinalPositions()
        {
            for (int index = 0; index < this.Sections.Count; ++index)
            {
                this.Sections[index].OrdinalPosition = index + 1;
            }
        }
    }

    public class EstimatesTemplateSectionCollection : ObservableCollection<EstimatesTemplateSection>
    {
        private EstimatesTemplate _owner;
        internal EstimatesTemplateSectionCollection(EstimatesTemplate owner)
        {
            this._owner = owner;
        }
    }
}
