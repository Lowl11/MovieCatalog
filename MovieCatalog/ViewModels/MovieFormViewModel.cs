using MovieCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalog.ViewModels
{
    public class MovieFormViewModel : BaseFormViewModel
    {

        public Movie Movie { get; set; }

        public IEnumerable<CoverFile> Covers { get; set; }

    }
}
