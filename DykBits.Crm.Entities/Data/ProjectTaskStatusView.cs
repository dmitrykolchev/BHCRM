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
    
    public partial class ProjectTaskStatusView : DataItemView
    {
        public const string DataItemClassName = "ProjectTaskStatus";
        private int _ColorField;
        private decimal _CompleteField;
        private byte _ProjectTaskStateField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public ProjectTaskStatusState State
        {
            get
            {
                return (ProjectTaskStatusState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [XmlAttribute()]
        public int Color
        {
            get
            {
                return this._ColorField;
            }
            set
            {
                this._ColorField = value;
            }
        }
        [XmlAttribute()]
        public decimal Complete
        {
            get
            {
                return this._CompleteField;
            }
            set
            {
                this._CompleteField = value;
            }
        }
        [XmlAttribute()]
        public byte ProjectTaskState
        {
            get
            {
                return this._ProjectTaskStateField;
            }
            set
            {
                this._ProjectTaskStateField = value;
            }
        }
    }
}