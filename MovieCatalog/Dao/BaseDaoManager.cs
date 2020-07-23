using Microsoft.EntityFrameworkCore;
using MovieCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalog.Dao
{
    public class BaseDaoManager<T>
        where T : DbModel
    {

        private readonly MovieCatalogContext _context;

        public BaseDaoManager(MovieCatalogContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

    }
}
