using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class EstimatesDocumentSection: NotifyObject
    {
        private string _fileAs;
        private int _productCategoryId;
        private string _comments;
        private static int SectionCount = 0;
        public EstimatesDocumentSection()
        {
            this.EstimatesDocumentSectionId = System.Threading.Interlocked.Decrement(ref SectionCount);
        }

        [XmlIgnore]
        public EstimatesDocument Parent
        {
            get;
            internal set;
        }
        [XmlIgnore]
        public bool ReadOnly
        {
            get;
            internal set;
        }
        [XmlAttribute]
        public int EstimatesDocumentSectionId { get; set; }
        [XmlAttribute]
        public int EstimatesDocumentId { get; set; }
        [XmlAttribute]
        public virtual int OrdinalPosition { get; set; }
        [XmlAttribute]
        public virtual string FileAs
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
        internal class Subtotal : EstimatesDocumentSection
        {
            public Subtotal()
            {
                this.ReadOnly = true;
            }
            public override int OrdinalPosition
            {
                get
                {
                    return Int32.MaxValue - 100;
                }
                set
                {
                }
            }

            public override string FileAs
            {
                get
                {
                    return "Итого";
                }
            }
        }

        internal class SubtotalWithCommission : EstimatesDocumentSection
        {
            public SubtotalWithCommission()
            {
                ReadOnly = true;
            }
            public override int OrdinalPosition
            {
                get
                {
                    return Int32.MaxValue - 99;
                }
                set
                {
                }
            }

            public override string FileAs
            {
                get
                {
                    return "Итого c агентскими";
                }
            }
        }

        internal class SubtotalWithVAT : EstimatesDocumentSection
        {
            public SubtotalWithVAT()
            {
                this.ReadOnly = true;
            }
            public override int OrdinalPosition
            {
                get
                {
                    return Int32.MaxValue - 98;
                }
                set
                {
                }
            }

            public override string FileAs
            {
                get
                {
                    return "Итого c НДС";
                }
            }
        }

    }

}
