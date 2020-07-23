using MovieCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalog.ViewModels
{
    public class MoviesViewModel
    {

        public IEnumerable<Movie> Movies { get; set; }

    }
}
