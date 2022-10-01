using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class OperatingBudgetDocumentBrowse
    {
        public int OperatingBudgetId { get; set; }
        public int BudgetItemId { get; set; }
        public int CalculationStage { get; set; }
    }

    public class OperatingBudgetDocumentItem
    {
        private DocumentMetadata _metadata;
        [XmlIgnore]
        public DocumentMetadata Metadata
        {
            get
            {
                if (this._metadata == null)
                    this._metadata = DocumentManager.GetMetadata(this.DocumentTypeId);
                return this._metadata;
            }
        }
        [XmlIgnore]
        public string DocumentCaption
        {
            get { return Metadata.Caption; }
        }
        [XmlIgnore]
        public object SmallImage
        {
            get { return Metadata.SmallImage; }
        }
        [XmlIgnore]
        public object LargeImage
        {
            get { return Metadata.LargeImage; }
        }
        [XmlIgnore]
        public DocumentState DocumentState
        {
            get
            {
                return Metadata.States.GetById(this.State);
            }
        }
        public int DocumentTypeId { get; set; }
        public int DocumentId { get; set; }
        public byte State { get; set; }
        public string FileAs { get; set; }
        public string Number { get; set; }
        public DateTime DocumentDate { get; set; }
        public int OrganizationId { get; set; }
        public string Comments { get; set; }
        public Nullable<decimal> TotalValue { get; set; }
    }
}
