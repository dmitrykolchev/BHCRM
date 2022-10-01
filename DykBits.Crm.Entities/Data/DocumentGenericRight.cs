using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class DocumentGenericRight : NotifyObject, IGenericRight
    {
        private int _rightFlags;
        [XmlAttribute]
        public int DocumentTypeId { get; set; }
        [XmlAttribute]
        public int ApplicationRoleId { get; set; }
        public int RightFlags
        {
            get { return (int)((uint)this._rightFlags & (uint)GenericRight.All); }
            set
            {
                this._rightFlags = (int)((uint)value & (uint)GenericRight.All);
                InvokePropertyChanged();
            }
        }
        [XmlIgnore]
        public GenericRight Rights
        {
            get { return (GenericRight)(RightFlags & (int)GenericRight.All); }
            set
            {
                RightFlags = (int)(value & GenericRight.All);
            }
        }
        private void SetRight(GenericRight right, bool value)
        {
            if (value)
                Rights |= right;
            else
                Rights &= ~right;
        }
        private bool GetRight(GenericRight right)
        {
            return (Rights & right) == right;
        }
        [XmlIgnore]
        public bool CanBrowse
        {
            get { return GetRight(GenericRight.Browse); }
            set
            {
                SetRight(GenericRight.Browse, value);
                if (!value)
                {
                    CanGet = false;
                    CanDeleteOwn = false;
                }
                InvokePropertyChanged();
            }
        }
        [XmlIgnore]
        public bool CanGet
        {
            get { return GetRight(GenericRight.Get); }
            set
            {
                SetRight(GenericRight.Get, value);
                if (!value)
                {
                    CanEditOwn = false;
                    CanEditAll = false;
                }
                else
                {
                    CanBrowse = true;
                }
                InvokePropertyChanged();
            }
        }
        [XmlIgnore]
        public bool CanEditOwn
        {
            get { return GetRight(GenericRight.EditOwn); }
            set
            {
                SetRight(GenericRight.EditOwn, value);
                if (!value)
                    CanEditAll = false;
                else
                    CanGet = true;
                InvokePropertyChanged();

            }
        }
        [XmlIgnore]
        public bool CanEditAll
        {
            get { return GetRight(GenericRight.EditAll); }
            set
            {
                SetRight(GenericRight.EditAll, value);
                if (value)
                    CanEditOwn = true;
                InvokePropertyChanged();
            }
        }
        [XmlIgnore]
        public bool CanDeleteOwn
        {
            get { return GetRight(GenericRight.DeleteOwn); }
            set
            {
                SetRight(GenericRight.DeleteOwn, value);
                if (!value)
                    CanDeleteAll = false;
                else
                    CanGet = true;
                InvokePropertyChanged();
            }
        }
        [XmlIgnore]
        public bool CanDeleteAll
        {
            get { return GetRight(GenericRight.DeleteAll); }
            set
            {
                SetRight(GenericRight.DeleteAll, value);
                if (value)
                    CanDeleteOwn = true;
                InvokePropertyChanged();
            }
        }
    }
}
