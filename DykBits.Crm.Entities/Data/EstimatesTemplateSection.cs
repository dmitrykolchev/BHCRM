using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class EstimatesTemplateSection: NotifyObject
    {
        private string _fileAs;
        private int _productCategoryId;
        private string _comments;
        [XmlAttribute]
        public int EstimatesTemplateSectionId { get; set; }
        [XmlAttribute]
        public int EstimatesTemplateId { get; set; }
        [XmlAttribute]
        public int OrdinalPosition { get; set; }
        [XmlAttribute]
        public string FileAs
        {
            get { return this._fileAs; }
            set
            {
                this._fileAs = value;
                InvokePropertyChanged();
            }
        }
        [XmlAttribute]
        public int ProductCategoryId
        {
            get { return this._productCategoryId; }
            set
            {
                this._productCategoryId = value;
                InvokePropertyChanged();
            }
        }
        [XmlAttribute]
        public string Comments
        {
            get { return this._comments; }
            set
            {
                this._comments = value;
                InvokePropertyChanged();
            }
        }
    }
}
