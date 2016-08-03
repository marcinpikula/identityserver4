using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.PlatformAbstractions;
using More.IdentityServer.Configuration;

namespace More.IdentityServer
{
    public class Startup
    {
        private readonly IHostingEnvironment _environment;

        public Startup(IHostingEnvironment env)
        {
            _environment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var cert = new X509Certificate2(Path.Combine(_environment.ContentRootPath, "idsvr3test.pfx"), "idsrv3test");

            var builder = services.AddIdentityServer(options =>
                {
                    options.UserInteractionOptions.LoginUrl = Common.Constants.LoginUrl;
                    options.UserInteractionOptions.LogoutUrl = Common.Constants.LogoutUrl;
                    options.UserInteractionOptions.ConsentUrl = Common.Constants.ConsentUrl;
                    options.UserInteractionOptions.ErrorUrl = Common.Constants.ErrorUrl;
                })
                .SetSigningCredential(cert)
                .AddInMemoryClients(Clients.Get())
                .AddInMemoryScopes(Scopes.Get())
                .AddInMemoryUsers(Users.Get());

            services
                 .AddMvc()
                 .AddRazorOptions(razor =>
                 {
                     razor.ViewLocationExpanders.Add(new UI.CustomViewLocationExpander());
                 });
            services.AddTransient<UI.Login.LoginService>();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            Func<string, LogLevel, bool> filter = (scope, level) =>
               scope.StartsWith("IdentityServer") ||
               scope.StartsWith("IdentityModel") ||
               level == LogLevel.Error ||
               level == LogLevel.Critical;

            loggerFactory.AddConsole(filter);
            loggerFactory.AddDebug(filter);

            app.UseDeveloperExceptionPage();

            app.UseIdentityServer();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

        }
    }
}
