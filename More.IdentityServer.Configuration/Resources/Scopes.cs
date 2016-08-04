using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace More.IdentityServer.Configuration
{
    public class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new List<Scope>
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                new Scope
                 {
                     Name = "gcmportal",
                     DisplayName = "Generic Case Management Portal",
                     Description = "Allow the application to access to resource.",
                     Type = ScopeType.Resource
                 },
                 new Scope
                 {
                     Name = "gcmportalapi",
                     DisplayName = "Generic Case Management Portal API Access",
                     Description = "Allow the application to access to api resource.",
                     Type = ScopeType.Resource
                 },
                new Scope
                {
                    Name = "api",
                    DisplayName = "API 1",
                    Description = "API 1 features and data",
                    Type = ScopeType.Resource
                }
            };
        }
    }
}
