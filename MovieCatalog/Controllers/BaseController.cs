using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCatalog.Dao;

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

        protected virtual string ControllerName() => null;
        protected IActionResult ControllerRedirect(string action)
        {
            if (ControllerName() == null)
                return Redirect("Home/NotFound");
            return Redirect($"/{action}");
        }

    }
}
