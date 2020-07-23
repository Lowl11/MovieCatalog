using MovieCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalog.ViewModels
{
    public class MovieFormViewModel
    {

        public Movie Movie { get; set; }

        public string SuccessMessage { get; set; }

        public string ErrorMessage { get; set; }

    }
}
