using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdentityServer4.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace More.IdentityServer.UI.Error
{
    public class ErrorController : Controller
    {
        private readonly IUserInteractionService _interaction;

        public ErrorController(IUserInteractionService interaction)
        {
            _interaction = interaction;
        }

        [Route("ui/error", Name = "Error")]
        public async Task<IActionResult> Index(string errorId)
        {
            var vm = new ErrorViewModel();

            if (errorId != null)
            {
                var message = await _interaction.GetErrorContextAsync(errorId);
                if (message != null)
                {
                    vm.Error = message;
                }
            }

            return View("Error", vm);
        }
    }
}
