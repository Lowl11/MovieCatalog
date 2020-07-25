using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalog.Helpers
{
    /// <summary>
    /// Содержит функционал позволяющий работать с сообщением об ошибке в сессии
    /// </summary>
    public class ErrorHelper
    {

        private const string FormErrorSessionKey = "form-error";

        public static void SetFormError(HttpContext httpContext, Exception error)
            => httpContext.Session.SetString(FormErrorSessionKey, error.Message);

        public static string GetFormError(HttpContext httpContext)
            => httpContext.Session.GetString(FormErrorSessionKey);

        public static void RemoveFormError(HttpContext httpContext)
            => httpContext.Session.Remove(FormErrorSessionKey);

    }
}
