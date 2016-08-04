using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace More.IdentityServer.UI.Logout
{
    public class LoggedOutViewModel
    {
        public string PostLogoutRedirectUri { get; set; }
        public string ClientName { get; set; }
        public string SignOutIframeUrl { get; set; }
    }
}
