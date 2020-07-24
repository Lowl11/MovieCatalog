using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCatalog.Dao;
using MovieCatalog.Helpers;
using MovieCatalog.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalog.Controllers
{
    public class FileController : BaseController
    {

        public const string ControllerName = "file";

        private readonly IWebHostEnvironment _hostingEnvironment;

        protected override string GetControllerName() => ControllerName;

        public FileController(
            ILogger<FileController> logger,
            MovieCatalogContext context,
            IWebHostEnvironment hostEnvironment
        ) : base(logger, context)
        {
            _hostingEnvironment = hostEnvironment;
        }

        public const string UploadPageActionName = "upload";
        [ActionName(UploadPageActionName), HttpGet]
        public IActionResult UploadPage()
        {
            var vm = new FileFormViewModel();
            vm.FormPostUrl = UploadActionName;
            FindSuccessAndErrorMessages(vm);
            return View("~/Views/File/Upload.cshtml", vm);
        }

        public const string UploadActionName = "upload";
        [ActionName(UploadActionName), HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            Exception error = await FileHelper.UploadFile(file, _hostingEnvironment.WebRootPath);
            if (error != null)
                ErrorHelper.SetFormError(HttpContext, error);
            else
                FormMessageHelper.SetSuccessMessage(HttpContext, "Изображение успешно загружено");
            return ControllerRedirect("upload");
        }

        private void FindSuccessAndErrorMessages(FileFormViewModel vm)
        {
            // 
        }

    }
}
