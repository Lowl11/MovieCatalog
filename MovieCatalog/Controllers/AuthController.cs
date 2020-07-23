using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCatalog.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalog.Controllers
{
    public class AuthController : BaseController
    {

        public AuthController(ILogger<AuthController> logger, MovieCatalogContext context)
            : base(logger, context)
        {}

        public const string LoginPageActionName = "login";
        [ActionName(LoginPageActionName)]
        public IActionResult LoginPage()
        {
            return View("~/Views/Auth/Login.cshtml");
        }

    }
}
