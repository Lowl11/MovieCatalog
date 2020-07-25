using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalog.ViewModels
{
    public abstract class BaseFormViewModel
    {

        public string ErrorMessage { get; set; }

        public string SuccessMessage { get; set; }

        public string FormPostUrl { get; set; }

    }
}
