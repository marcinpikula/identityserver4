using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace More.IdentityServer.Configuration.Certificates
{
    public static class Certificate
    {
        // https certificate
        public static string CertificatePath = Directory.GetCurrentDirectory() + @"\idsvr3test.pfx";
        public static X509Certificate2 CertificateFile =  new X509Certificate2(CertificatePath, "idsrv3test");

        //TODO: identityserver certificate


    }
}
