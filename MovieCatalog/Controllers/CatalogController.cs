using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCatalog.Dao;
using MovieCatalog.ViewModels;

namespace MovieCatalog.Controllers
{
    public class CatalogController : BaseController
    {

        protected override string ControllerName() => "catalog";

        public CatalogController(ILogger<CatalogController> logger, MovieCatalogContext context)
            : base(logger, context)
        {}

        public const string MainPageActionName = "movies";
        [ActionName(MainPageActionName), HttpGet]
        public IActionResult Movies()
        {
            var vm = new MoviesViewModel();
            var movieDaoManager = new MovieDaoManager(_context);
            vm.Movies = movieDaoManager.GetAll();
            return View("~/Views/Movies/Index.cshtml", vm);
        }

    }
}
