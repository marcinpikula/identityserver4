using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdentityServer4.Services;
using IdentityServer4;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace More.IdentityServer.UI.Logout
{
    public class LogoutController : Controller
    {
        private readonly IUserInteractionService _interaction;

        public LogoutController(IUserInteractionService interaction)
        {
            _interaction = interaction;
        }

        [HttpGet("ui/logout", Name = "Logout")]
        public IActionResult Index(string logoutId)
        {
            ViewData["logoutId"] = logoutId;
            return View();
        }

        [HttpPost("ui/logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(string logoutId)
        {
            await HttpContext.Authentication.SignOutAsync(Constants.DefaultCookieAuthenticationScheme);

            // set this so UI rendering sees an anonymous user
            HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());

            var logout = await _interaction.GetLogoutContextAsync(logoutId);

            var vm = new LoggedOutViewModel()
            {
                PostLogoutRedirectUri = logout.PostLogoutRedirectUri,
                ClientName = logout.ClientId,
                SignOutIframeUrl = logout.SignOutIFrameUrl
            };
            return View("LoggedOut", vm);
        }
    }
}
