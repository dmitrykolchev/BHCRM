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
    
    public partial class InventoryStatementFilter : Filter
    {
        public InventoryStatementFilter()
        {
            this.States = new byte[] { (byte)InventoryStatementState.Draft, (byte)InventoryStatementState.Approved};
        }
    }
}
