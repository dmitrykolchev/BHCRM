using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Diagnostics;

namespace DykBits.Crm.Data
{
    [XmlType(AnonymousType = true)]
    [DebuggerDisplay("{FromState} -> {ToState}")]
    public class DocumentTransitionTemplate
    {
        private List<Role> _roles = new List<Role>();
        private DocumentState _fromState;
        private DocumentState _toState;
        private Nullable<bool> _hasAccessRight;
        [XmlAttribute("Id")]
        public int Id { get; set; }
        [XmlAttribute("FromState")]
        public byte FromStateValue { get; set; }
        [XmlAttribute("ToState")]
        public byte ToStateValue { get; set; }
        [XmlElement("Role")]
        public List<Role> Roles
        {
            get
            {
                return this._roles;
            }
        }
        [XmlIgnore]
        public bool HasAccessRight
        {
            get
            {
                if (this._hasAccessRight == null)
                {
                    int[] roles = Roles.Select(t=>t.Id).ToArray();
                    var role = SecurityManager.CurrentUser.Roles.Values.Where(t => roles.Contains(t.Id)).FirstOrDefault();
                    this._hasAccessRight = role != null;
                }
                return this._hasAccessRight.Value;
            }
        }
        [XmlIgnore]
        public DocumentState FromState
        {
            get
            {
                if (this._fromState == null)
                    this._fromState = Document.States.GetById(FromStateValue);
                return this._fromState;
            }
        }
        [XmlIgnore]
        public DocumentState ToState
        {
            get
            {
                if (this._toState == null)
                    this._toState = Document.States.GetById(ToStateValue);
                return this._toState;
            }
        }
        [XmlIgnore]
        public DocumentMetadata Document { get; internal set; }
        public class Role
        {
            [XmlAttribute("Id")]
            public int Id { get; set; }
        }
    }
}
