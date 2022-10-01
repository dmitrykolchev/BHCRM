using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Diagnostics;
using DykBits.Crm.UI;

namespace DykBits.Crm.Data
{
    [XmlType(AnonymousType = true)]
    [DebuggerDisplay("{Name}")]
    public class DocumentState
    {
        public const int NotExist = 0;
        private IList<DocumentTransitionTemplate> _availableTransitions;
        private System.Windows.Media.ImageSource _image;
        public DocumentState()
        {
        }
        [XmlIgnore]
        public DocumentMetadata Document { get; internal set; }
        [XmlAttribute("Value")]
        public byte State { get; set; }
        [XmlAttribute("Ordinal")]
        public int OrdinalPosition { get; set; }
        [XmlAttribute("OverlayImage")]
        public byte[] OverlayImageData { get; set; }
        [XmlIgnore]
        public System.Windows.Media.ImageSource Image
        {
            get
            {
                if (this._image == null)
                {
                    if (OverlayImageData != null)
                    {
                        this._image = ImageHelper.CreateImage(OverlayImageData);
                    }
                    else
                    {
                        this._image = Document.SmallImage;
                    }
                }
                return this._image;
            }
        }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Caption { get; set; }
        [XmlAttribute]
        public string Description { get; set; }
        public IList<DocumentTransitionTemplate> AvailableTransitions
        {
            get
            {
                if (this._availableTransitions == null)
                    this._availableTransitions = this.Document.Transitions.Where(t => t.FromStateValue == this.State && t.HasAccessRight).ToList();
                return this._availableTransitions;
            }
        }
        public override int GetHashCode()
        {
            return this.Document.Id ^ (State + 13);
        }
        public override bool Equals(object obj)
        {
            if (obj is DocumentState)
                return ((DocumentState)obj).State == this.State && ((DocumentState)obj).Document.Id == this.Document.Id;
            return false;
        }
        [XmlIgnore]
        public bool IsReadOnly
        {
            get
            {
                if (this.State != 0)
                {
                    if (this.Document.SupportsTransitionTemplates)
                        return this.AvailableTransitions.Where(t => t.FromStateValue == this.State && t.ToStateValue == this.State).Count() == 0;
                }
                return false;
            }
        }
        [XmlIgnore]
        public bool CanDelete
        {
            get
            {
                return CanChangeStateTo(DocumentState.NotExist);
            }
        }
        public bool CanChangeStateTo(byte newState)
        {
            if (this.Document.SupportsTransitionTemplates)
                return this.AvailableTransitions.Where(t => t.FromStateValue == this.State && t.ToStateValue == newState).Count() > 0;
            return true;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
