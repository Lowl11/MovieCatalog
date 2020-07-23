using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using MovieCatalog.Dao;
using MovieCatalog.Helpers;
using MovieCatalog.Models;
using MovieCatalog.ViewModels;
using Newtonsoft.Json;
using System;

namespace MovieCatalog.Controllers
{
    public class AuthController : BaseController
    {

        protected override string ControllerName() => "auth";

        public AuthController(
            ILogger<AuthController> logger,
            MovieCatalogContext context
        ) : base(logger, context)
        {}

        public const string LoginPageActionName = "login";
        [ActionName(LoginPageActionName), HttpGet]
        public IActionResult LoginPage()
        {
            Viewer viewer = ViewerHelper.GetCurrent(HttpContext);
            if (viewer != null)
                return Redirect("/");

            var vm = new AuthViewModel();
            vm.LoginPostUrl = LoginPostActionName;
            return View("~/Views/Auth/Login.cshtml", vm);
        }

        public const string LoginPostActionName = "login";
        [ActionName(LoginPostActionName), HttpPost]
        public IActionResult LoginPost(string username, string password)
        {
            var viewerDaoManager = new ViewerDaoManager(_context);
            Viewer viewer = viewerDaoManager.Login(username, password);
            if (viewer == null)
                return ControllerRedirect("login");

            ViewerHelper.SetCurrent(HttpContext, viewer);
            return Redirect("/");
        }

    }
}
