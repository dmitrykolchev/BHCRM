using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Security.Principal;
using System.IdentityModel.Claims;
using System.Security.Cryptography.X509Certificates;

namespace DykBits.Crm.Data
{
    internal class X500DistinguishedNameEndpointIdentity : EndpointIdentity
    {
        private X500DistinguishedName _name;

        public X500DistinguishedNameEndpointIdentity(string host)
        {
            _name = new X500DistinguishedName("CN=" + host);
        }

        public X500DistinguishedName Name
        {
            get { return this._name; }
        }
    }

    public class CustomIdentityVerifier : IdentityVerifier
    {
        public override bool CheckAccess(EndpointIdentity identity, System.IdentityModel.Policy.AuthorizationContext authContext)
        {
            return true;
            //X500DistinguishedNameEndpointIdentity requested = (X500DistinguishedNameEndpointIdentity)identity;
            //string requstedName = requested.Name.Format(false);
            //for (int index = 0; index < authContext.ClaimSets.Count; ++index)
            //{
            //    foreach (Claim claim in authContext.ClaimSets[index].FindClaims(ClaimTypes.Thumbprint, Rights.PossessProperty))
            //    {
            //        X500DistinguishedName name = (X500DistinguishedName)claim.Resource;
            //        string dsn = name.Format(false);
            //        if (dsn.Equals(requstedName, StringComparison.OrdinalIgnoreCase))
            //            return true;
            //    }
            //}
            //return false;
        }

        public override bool TryGetIdentity(EndpointAddress reference, out EndpointIdentity identity)
        {
            identity = new X500DistinguishedNameEndpointIdentity(reference.Uri.DnsSafeHost);
            return true;
        }
    }
}
