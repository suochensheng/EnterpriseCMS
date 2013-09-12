using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Data;

namespace Web.Service.Authentication
{
    /// <summary>
    /// Authentication service interface
    /// </summary>
    public partial interface IAuthenticationService
    {
        void SignIn(Customer customer, bool createPersistentCookie);
        void SignOut();
        Customer GetAuthenticatedCustomer();
    }
}
