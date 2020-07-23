using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieCatalog.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalog.Helpers
{
    public class ViewerHelper
    {

        private const string CurrentViewerSessionKey = "viewer";

        public static void SetCurrent(HttpContext httpContext, Viewer viewer)
        {
            string viewerJson = JsonConvert.SerializeObject(viewer);
            httpContext.Session.SetString(CurrentViewerSessionKey, viewerJson);
        }

        public static Viewer GetCurrent(HttpContext httpContext)
        {
            string viewerJson = null;
            Viewer viewer = null;
            try
            {
                viewerJson = httpContext.Session.GetString(CurrentViewerSessionKey);
                if (viewerJson != null)
                    viewer = JsonConvert.DeserializeObject<Viewer>(viewerJson);
            }
            finally {}

            return viewer;
        }

        public static void RemoveCurrent(HttpContext httpContext)
        {
            httpContext.Session.Remove(CurrentViewerSessionKey);
        }

    }
}
