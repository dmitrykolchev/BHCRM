using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(SecurityScheme.AccessRight), ElementName="AccessRight")]
    [TypeMapping(typeof(SecurityScheme.ApplicationRole), ElementName="ApplicationRole")]
    [TypeMapping(typeof(SecurityScheme.ApplicationRoleAccessRight), ElementName = "ApplicationRoleAccessRight")]
    partial class SecurityScheme
    {
        public class AccessRight
        {
            [XmlAttribute]
            public string Code { get; set; }
            [XmlAttribute]
            public string FileAs { get; set; }
        }

        public class ApplicationRole
        {
            [XmlAttribute]
            public string Code { get; set; }
            [XmlAttribute]
            public string FileAs { get; set; }
        }

        public class ApplicationRoleAccessRight
        {
            [XmlAttribute]
            public string ApplicationRole { get; set; }
            [XmlAttribute]
            public string AccessRight { get; set; }
        }

        private List<AccessRight> _rights = new List<AccessRight>();
        private List<ApplicationRole> _roles = new List<ApplicationRole>();
        private List<ApplicationRoleAccessRight> _roleRights = new List<ApplicationRoleAccessRight>();
        public List<AccessRight> Rights
        {
            get { return this._rights; }
        }
        public List<ApplicationRole> Roles
        {
            get
            {
                return this._roles;
            }
        }
        public List<ApplicationRoleAccessRight> RoleRights
        {
            get
            {
                return this._roleRights;
            }
        }
    }


}
