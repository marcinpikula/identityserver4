using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Security.Cryptography.X509Certificates;

namespace More.IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + @"\idsvr3test.pfx" ;

            var rootPath = Path.Combine("path", "idsvr3test.pfx");

            //var cert = new X509Certificate2(Path.Combine("path", "idsvr3test.pfx"), "idsrv3test"));
            
            var host = new WebHostBuilder()
                .UseKestrel(options =>
                    options.UseHttps(new X509Certificate2(path, "idsrv3test"))
                )
                .UseUrls("https://localhost:5000/")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
