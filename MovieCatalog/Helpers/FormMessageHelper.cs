using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalog.Helpers
{
    /// <summary>
    /// Содержит функционал позволяющий работать с сообщениями об успехе в сессии
    /// </summary>
    public class FormMessageHelper
    {

        private const string FormSuccessSessionKey = "form-success";

        public static void SetSuccessMessage(HttpContext httpContext, string successMessage)
            => httpContext.Session.SetString(FormSuccessSessionKey, successMessage);

        public static string GetSuccessMessage(HttpContext httpContext)
            => httpContext.Session.GetString(FormSuccessSessionKey);

        public static void RemoveSuccessMessage(HttpContext httpContext)
            => httpContext.Session.Remove(FormSuccessSessionKey);

    }
}
