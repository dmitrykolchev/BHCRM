using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    partial class DocumentNumberingRule
    {
        [XmlIgnore]
        public int OrganizationIdUI
        {
            get { return this.OrganizationId; }
            set
            {
                this.OrganizationId = value;
                UpdateFileAs();
                InvokePropertyChanged();
            }
        }
        [XmlIgnore]
        public int DocumentTypeIdUI
        {
            get { return this.DocumentTypeId; }
            set
            {
                this.DocumentTypeId = value;
                UpdateFileAs();
                InvokePropertyChanged();
            }
        }
        private void UpdateFileAs()
        {
            if (this.DocumentTypeId == 0)
            {
                if (this.OrganizationId == 0)
                    this.FileAs = null;
                else
                    this.FileAs = ListManager.GetItem<OrganizationView>(this.OrganizationId).FileAs;
            }
            else
            {
                if (this.OrganizationId == 0)
                    this.FileAs = ListManager.GetItem<DocumentTypeEntryView>(this.DocumentTypeId).FileAs;
                else
                    this.FileAs = ListManager.GetItem<OrganizationView>(this.OrganizationId).FileAs + "/" + ListManager.GetItem<DocumentTypeEntryView>(this.DocumentTypeId).FileAs;
            }

        }
    }
}
