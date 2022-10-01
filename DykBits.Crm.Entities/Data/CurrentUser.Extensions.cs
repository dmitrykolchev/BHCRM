using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(UserApplicationRole))]
    [TypeMapping(typeof(UserAccessRight))]
    partial class CurrentUser : ICurrentUser
    {
        private List<UserApplicationRole> _userRoles;
        private List<UserAccessRight> _userRights;

        private IDictionary<string, IAccessRight> _rights;
        private IDictionary<string, IApplicationRole> _roles;
        private IDictionary<int, IGenericRight> _genericRights;

        private static CurrentUser sInstance;

        [XmlIgnore]
        public static CurrentUser Instance
        {
            get
            {
                if (sInstance == null)
                {
                    IDataAdapter dataAdapter = DocumentManager.CreateDataAdapterProxy<CurrentUser>();
                    var item = dataAdapter.Browse(Filter.EmptyXml).OfType<CurrentUserView>().FirstOrDefault();
                    if (item == null)
                        throw new InvalidOperationException("unknown user");
                    sInstance = (CurrentUser)dataAdapter.GetItem(item.GetKey());
                }
                return sInstance;
            }
        }

        [XmlIgnore]
        public bool Locked
        {
            get { return this.State == CurrentUserState.Inactive; }
        }

        public List<UserApplicationRole> Roles
        {
            get
            {
                if (this._userRoles == null)
                    this._userRoles = new List<UserApplicationRole>();
                return this._userRoles;
            }
        }
        public bool IsMemberOf(string role)
        {
            return this._roles.ContainsKey(role);
        }
        public List<UserAccessRight> Rights
        {
            get
            {
                if (this._userRights == null)
                    this._userRights = new List<UserAccessRight>();
                return this._userRights;
            }
        }

        [XmlIgnore]
        IDictionary<string, IAccessRight> ICurrentUser.Rights
        {
            get
            {
                if (this._rights == null)
                    this._rights = InitializeRights();
                return this._rights;
            }
        }

        [XmlIgnore]
        IDictionary<string, IApplicationRole> ICurrentUser.Roles
        {
            get
            {
                if (this._roles == null)
                    this._roles = InitializeRoles();
                return this._roles;
            }
        }

        [XmlIgnore]
        IDictionary<int, IGenericRight> ICurrentUser.GenericRights
        {
            get
            {
                if (this._genericRights == null)
                    this._genericRights = InitializeGenericRights();
                return this._genericRights;
            }
        }
        private IDictionary<int, IGenericRight> InitializeGenericRights()
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            IDataAdapter dataAdapter = documentManager.CreateDataAdapterProxy("DocumentAccessControlList");
            IDocumentAccessControlList dacl = (IDocumentAccessControlList)dataAdapter.GetItem(ItemKey.CreateKey("DocumentAccessControlList", 1));
            var roles = this.Roles.Select(t => t.ApplicationRoleId);
            var rights = dacl.Rights.Where(t => roles.Contains(t.ApplicationRoleId));
            Dictionary<int, IGenericRight> result = new Dictionary<int, IGenericRight>();
            foreach (var right in rights)
            {
                IGenericRight value;
                if (!result.TryGetValue(right.DocumentTypeId, out value))
                {
                    value = new GenericRightInternal { DocumentTypeId = right.DocumentTypeId, Rights = right.Rights };
                    result.Add(value.DocumentTypeId, value);
                }
                else
                {
                    ((GenericRightInternal)value).Rights |= right.Rights;
                }
            }
            return result;
        }

        private IDictionary<string, IAccessRight> InitializeRights()
        {
            ListManager listManager = ServiceManager.GetService<ListManager>();
            var rights = listManager.GetList("AccessRight");
            Dictionary<string, IAccessRight> result = new Dictionary<string, IAccessRight>();
            foreach (var item in this.Rights)
            {
                var right = (IAccessRight)rights[item.AccessRightId];
                result.Add(right.Code, right);
            }
            return result;
        }

        private IDictionary<string, IApplicationRole> InitializeRoles()
        {
            ListManager listManager = ServiceManager.GetService<ListManager>();
            var roles = listManager.GetList("ApplicationRole");
            Dictionary<string, IApplicationRole> result = new Dictionary<string, IApplicationRole>();
            foreach (var item in this.Roles)
            {
                var role = (IApplicationRole)roles[item.ApplicationRoleId];
                result.Add(role.Code, role);
            }
            return result;
        }

        bool ICurrentUser.HasRight(string right)
        {
            if (string.IsNullOrEmpty(right))
                return false;
            return ((ICurrentUser)this).Rights.ContainsKey(right);
        }

        private class GenericRightInternal : IGenericRight, IDocumentStateGenericRight
        {
            public int DocumentTypeId { get; internal set; }
            public byte DocumentState { get; internal set; }
            int IGenericRight.ApplicationRoleId
            {
                get
                {
                    throw new NotSupportedException();
                }
            }
            int IDocumentStateGenericRight.ApplicationRoleId
            {
                get
                {
                    throw new NotSupportedException();
                }
            }
            public GenericRight Rights { get; internal set; }
        }
    }
}
