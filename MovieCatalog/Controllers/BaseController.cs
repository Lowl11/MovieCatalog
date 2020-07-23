using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        public BaseController(ILogger logger, MovieCatalogContext context)
        {
            _logger = logger;
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Viewer = ViewerHelper.GetCurrent(HttpContext);

            base.OnActionExecuting(filterContext);
        }

        protected virtual string ControllerName() => null;
        protected IActionResult ControllerRedirect(string action)
        {
            if (ControllerName() == null)
                return Redirect("catalog/not-found");
            return Redirect($"/{action}");
        }

    }
}
