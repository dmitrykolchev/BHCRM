//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DykBits.Crm.Data
{
    using System;
    using System.Xml.Serialization;
    
    public partial class UserNotificationView : DataItemView
    {
        public const string DataItemClassName = "UserNotification";
        private System.Nullable<int> _DocumentTypeIdField;
        private System.Nullable<int> _DocumentIdField;
        private int _UserIdField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public UserNotificationState State
        {
            get
            {
                return (UserNotificationState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> DocumentTypeId
        {
            get
            {
                return this._DocumentTypeIdField;
            }
            set
            {
                this._DocumentTypeIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> DocumentId
        {
            get
            {
                return this._DocumentIdField;
            }
            set
            {
                this._DocumentIdField = value;
            }
        }
        [XmlAttribute()]
        public int UserId
        {
            get
            {
                return this._UserIdField;
            }
            set
            {
                this._UserIdField = value;
            }
        }
    }
}
