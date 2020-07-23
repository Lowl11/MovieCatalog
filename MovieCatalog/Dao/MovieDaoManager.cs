using Microsoft.EntityFrameworkCore;
using MovieCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MovieCatalog.Dao
{
    public class MovieDaoManager : BaseDaoManager<Movie>
    {

        public MovieDaoManager(MovieCatalogContext context)
            : base(context)
        {}

        public IEnumerable<Movie> GetMoviesWithAuthor()
        {
            return GetAll()
                .Include(movie => movie.Author)
                .AsEnumerable();
        }

    }
}
