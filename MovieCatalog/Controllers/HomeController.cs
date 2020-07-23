using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCatalog.Dao;
using MovieCatalog.Models;
using MovieCatalog.ViewModels;

namespace MovieCatalog.Controllers
{
    public class HomeController : BaseController
    {
        
        public HomeController(ILogger<HomeController> logger, MovieCatalogContext context)
            : base(logger, context)
        {}

        public IActionResult Index()
        {
            var vm = new MoviesViewModel();
            var movieDaoManager = new MovieDaoManager(_context);
            vm.Movies = movieDaoManager.GetAll();
            return View("~/Views/Movies/Index.cshtml", vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
