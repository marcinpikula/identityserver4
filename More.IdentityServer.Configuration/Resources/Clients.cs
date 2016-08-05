using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace More.IdentityServer.Configuration
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                 new Client
                {
                     ClientId = "gcmportalimplicit-old",
                     ClientName = "Gcm Portal Client (Implicit)",
                     AllowedGrantTypes = GrantTypes.Implicit,
                     AllowedScopes = new List<string>
                     {
                         StandardScopes.ProfileAlwaysInclude.ToString(),
                         "openid",
                         "gcmportal"
                     },
                     
                    // redirect = URI of the Angular application
                    RedirectUris = new List<string>
                    {
                        "https://localhost:8443/main",
                        "https://localhost:8443/callback"
                    },
                    Claims = new List<System.Security.Claims.Claim>
                    {

                    }

                },

                 new Client
                 {
                     ClientId = "gcmportalimplicit",
                     ClientName = "JavaScript OIDC Client",
                     ClientUri = "https://localhost:8443/",
                     AllowedGrantTypes = GrantTypes.Implicit,

                     RedirectUris = new List<string>
                     {
                         "https://localhost:8443/access_token",
                         "https://localhost:8443/",
                         "https://localhost:8443/main",
                         "https://localhost:8443/callback",
                     },
                     PostLogoutRedirectUris = new List<string>
                     {
                         "http://localhost:8443/login",
                     },

                     AllowedCorsOrigins = new List<string>
                     {
                         "https://localhost:8443"
                     },

                     AllowedScopes = new List<string>
                     {
                         StandardScopes.OpenId.Name,
                         StandardScopes.Profile.Name,
                         StandardScopes.Email.Name,
                         StandardScopes.Roles.Name,
                         "gcmportal"
                     }
}
            };
        }
    }
}
