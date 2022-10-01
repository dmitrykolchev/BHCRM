using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Security.Principal;
using System.Security;

namespace DykBits.Crm.Data
{
    public class SecurityManager
    {
        public SecurityManager()
        {
        }

        public static IEmployeeInfo GetCurrentEmployee()
        {
            IDatabaseContext db = ServiceManager.GetService<IDatabaseContext>();
            return db.GetCurrentEmployee();
        }

        public static IIdentity GetCurrentIdentity()
        {
            ServiceSecurityContext securityContext = ServiceSecurityContext.Current;
            if (securityContext != null && securityContext.PrimaryIdentity != null)
                return securityContext.PrimaryIdentity;
            return WindowsIdentity.GetCurrent();
        }

        private static ICurrentUser GetCurrentUser()
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            IDataAdapter dataAdapter = documentManager.CreateDataAdapterProxy("CurrentUser");
            var item = dataAdapter.Browse(Filter.EmptyXml).OfType<IDataItem>().FirstOrDefault();
            if (item == null)
                throw new InvalidOperationException("unknown user");
            return (ICurrentUser)dataAdapter.GetItem(item.GetKey());
        }

        private static ICurrentUser sCurrentUser;
        public static ICurrentUser CurrentUser
        {
            get
            {
                if (sCurrentUser == null)
                {
                    sCurrentUser = GetCurrentUser();
                }
                return sCurrentUser;
            }
        }

    }
}
