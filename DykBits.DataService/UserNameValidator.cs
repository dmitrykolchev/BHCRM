using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Selectors;

namespace DykBits.DataService
{
    class UserNameValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            //AccountInfo login = SecurityHelper.GetAccountInfoFromUserName(userName);
            //if (login != null)
            //{
            //    if (SecurityHelper.Equals(SecurityHelper.GetPasswordHash(password), login.PasswordHash))
            //        return;
            //}
            //if (string.Compare(userName, "anonymous", StringComparison.OrdinalIgnoreCase) != 0)
            //    throw ExceptionUtils.CreateFault(new InvalidOperationException("unknown user or invalid password"));
        }
    }
}
