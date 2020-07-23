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

        public const string ControllerName = "auth";
        protected override string GetControllerName() => ControllerName;

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
            vm.FormUrl = $"/{ControllerName}/{LoginPostActionName}";
            FindErrorMessage(vm);
            return View("~/Views/Auth/Login.cshtml", vm);
        }

        public const string LoginPostActionName = "login";
        [ActionName(LoginPostActionName), HttpPost]
        public IActionResult LoginPost(string username, string password)
        {
            var viewerDaoManager = new ViewerDaoManager(_context);
            (Viewer viewer, Exception error) = viewerDaoManager.Login(username, password);
            if (error != null)
            {
                ErrorHelper.SetFormError(HttpContext, error);
                return ControllerRedirect("login");
            }

            ViewerHelper.SetCurrent(HttpContext, viewer);
            return Redirect("/");
        }

        public const string RegisterPageActionName = "register";
        [ActionName(RegisterPageActionName), HttpGet]
        public IActionResult RegisterPage()
        {
            var vm = new AuthViewModel();
            vm.FormUrl = $"/{ControllerName}/{RegisterPostActionName}";
            FindErrorMessage(vm);
            return View("~/Views/Auth/Register.cshtml", vm);
        }

        public const string RegisterPostActionName = "register";
        [ActionName(RegisterPostActionName), HttpPost]
        public IActionResult Register(string username, string password, string repassword)
        {
            if (!password.Equals(repassword))
                return ControllerRedirect("register");
            var viewerDaoManager = new ViewerDaoManager(_context);
            var (viewer, error) = viewerDaoManager.Register(username, password);
            if (error != null)
            {
                ErrorHelper.SetFormError(HttpContext, error);
                return ControllerRedirect("register");
            }
            return ControllerRedirect("login");
        }

        public const string LogoutActionName = "logout";
        [ActionName(LogoutActionName), HttpGet]
        public IActionResult Logout()
        {
            ViewerHelper.RemoveCurrent(HttpContext);
            return Redirect("/");
        }

        private void FindErrorMessage(AuthViewModel vm)
        {
            string errorMessage = ErrorHelper.GetFormError(HttpContext);
            if (errorMessage != null)
            {
                vm.ErrorMessage = errorMessage;
                ErrorHelper.RemoveFormError(HttpContext);
            }
        }

    }
}
