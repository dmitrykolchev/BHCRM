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
    
    public partial class ServiceRequestFilter : Filter
    {
        public ServiceRequestFilter()
        {
            this.States = new byte[] { (byte)ServiceRequestState.Prospecting, (byte)ServiceRequestState.InProgress, (byte)ServiceRequestState.Qualification, (byte)ServiceRequestState.Won, (byte)ServiceRequestState.Lost, (byte)ServiceRequestState.Canceled, (byte)ServiceRequestState.Completed, (byte)ServiceRequestState.Closed};
        }
    }
}
