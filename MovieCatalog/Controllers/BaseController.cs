using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using MovieCatalog.Dao;
using MovieCatalog.Helpers;

namespace MovieCatalog.Controllers
{
    public abstract class BaseController : Controller
    {

        protected readonly MovieCatalogContext _context;
        protected readonly ILogger _logger;
        protected readonly IWebHostEnvironment _hostEnvironment;

        public BaseController(ILogger logger, MovieCatalogContext context, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Viewer = ViewerHelper.GetCurrent(HttpContext);

            base.OnActionExecuting(filterContext);
        }

        protected virtual string GetControllerName() => null;
        protected IActionResult ControllerRedirect(string action)
        {
            string controllerName = GetControllerName();
            if (controllerName == null)
                return Redirect("catalog/not-found");
            return Redirect($"/{controllerName}/{action}");
        }

    }
}
