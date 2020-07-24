using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCatalog.Dao;
using MovieCatalog.Helpers;
using MovieCatalog.Models;
using MovieCatalog.ViewModels;
using System;
using System.Linq;

namespace MovieCatalog.Controllers
{
    public class CatalogController : BaseController
    {

        public const string ControllerName = "catalog";
        protected override string GetControllerName() => ControllerName;

        public CatalogController(
            ILogger<CatalogController> logger,
            MovieCatalogContext context,
            IWebHostEnvironment hostEnvironment
        ) : base(logger, context, hostEnvironment)
        {}

        public const string MainPageActionName = "movies";
        [ActionName(MainPageActionName), HttpGet]
        public IActionResult Movies(int? page)
        {
            var vm = new MoviesViewModel();
            var movieDaoManager = new MovieDaoManager(_context);
            vm.Movies = movieDaoManager.GetPage(page-1).AsEnumerable();
            vm.Pages = movieDaoManager.GetAll().Count() / 10;
            return View("~/Views/Movies/Index.cshtml", vm);
        }

        public const string MoviePageActionName = "movie";
        [ActionName(MoviePageActionName), HttpGet]
        public IActionResult MoviePage(int? id)
        {
            var vm = new MoviePageViewModel();
            var movieDaoManager = new MovieDaoManager(_context);
            Movie movie = movieDaoManager.GetMovieById(id.Value);
            if (movie == null)
                return ControllerRedirect("movies");

            vm.Movie = movie;
            return View("~/Views/Movies/Movie.cshtml", vm);
        }

        public const string AddMoviePageActionName = "add";
        [ActionName(AddMoviePageActionName), HttpGet]
        public IActionResult AddMoviePage()
        {
            var vm = new MovieFormViewModel();
            
            vm.Covers = FileHelper.GetFiles(_hostEnvironment.WebRootPath);
            vm.FormPostUrl = AddMovieActionName;
            FindSuccessAndErrorMessages(vm);

            return View("~/Views/Movies/Form.cshtml", vm);
        }

        public const string AddMovieActionName = "add";
        [ActionName(AddMovieActionName), HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            var movieDaoManager = new MovieDaoManager(_context);
            Exception error = movieDaoManager.AddMovie(movie, ViewerHelper.GetCurrent(HttpContext));

            if (error != null)
                ErrorHelper.SetFormError(HttpContext, error);
            else
                FormMessageHelper.SetSuccessMessage(HttpContext, "Фильм добавлен успешно!");

            return ControllerRedirect("add");
        }

        public const string EditMoviePageActionName = "edit";
        [ActionName(EditMoviePageActionName), HttpGet]
        public IActionResult EditMoviePage(int? id)
        {
            if (id == null)
                return ControllerRedirect("/");

            var movieDaoManager = new MovieDaoManager(_context);
            var vm = new MovieFormViewModel();

            vm.Covers = FileHelper.GetFiles(_hostEnvironment.WebRootPath);
            vm.Movie = movieDaoManager.GetById(id.Value);
            vm.FormPostUrl = EditMovieActionName;
            FindSuccessAndErrorMessages(vm);

            return View("~/Views/Movies/Form.cshtml", vm);
        }

        public const string EditMovieActionName = "edit";
        [ActionName(EditMovieActionName), HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            var movieDaoManager = new MovieDaoManager(_context);
            movieDaoManager.UpdateMovie(movie);
            return ControllerRedirect($"edit?id={movie.Id}");
        }

        public const string DeleteMovieActionName = "delete";
        [ActionName(DeleteMovieActionName)]
        public IActionResult DeleteMovie(int? id)
        {
            if (id != null)
            {
                var movieDaoManager = new MovieDaoManager(_context);
                movieDaoManager.Delete(id.Value);
            }

            return ControllerRedirect("movies");
        }

        private void FindSuccessAndErrorMessages(MovieFormViewModel vm)
        {
            string errorMessage = ErrorHelper.GetFormError(HttpContext);
            if (errorMessage != null)
            {
                vm.ErrorMessage = errorMessage;
                ErrorHelper.RemoveFormError(HttpContext);
                return;
            }

            string successMessage = FormMessageHelper.GetSuccessMessage(HttpContext);
            if (successMessage != null)
            {
                vm.SuccessMessage = successMessage;
                FormMessageHelper.RemoveSuccessMessage(HttpContext);
            }
        }

    }
}
