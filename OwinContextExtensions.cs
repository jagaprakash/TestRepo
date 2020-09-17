using System;
using System.Linq;
using System.Web;
using Microsoft.Owin;

namespace ClientCredentialsGrant
{
    public static class OwinContextExtensions
    {
        public static int GetClientID()
        {
            int result = 0;
            var claim = CurrentContext.Authentication.User.Claims.FirstOrDefault(c => c.Type == "ClientID");

            if (claim != null)
            {
                result = Convert.ToInt32(claim.Value);
            }
            return result;
        }

        public static IOwinContext CurrentContext
        {
            get
            {
                return HttpContext.Current.GetOwinContext();
            }
        }
    }
}