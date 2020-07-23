using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCatalog.Dao;

namespace MovieCatalog.Controllers
{
    public class BaseController : Controller
    {

        protected readonly MovieCatalogContext _context;
        protected readonly ILogger _logger;
        
        public BaseController(ILogger logger, MovieCatalogContext context)
        {
            _logger = logger;
            _context = context;
        }

    }
}
