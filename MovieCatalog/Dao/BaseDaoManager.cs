using Microsoft.EntityFrameworkCore;
using MovieCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalog.Dao
{
    /// <summary>
    /// Абстрактный класс предостовляющий базовый функционал для работы с моделями БД
    /// </summary>
    /// <typeparam name="T">Тип данных которое имеет представление в базе данных</typeparam>
    public abstract class BaseDaoManager<T>
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

        public T GetById(int id)
        {
            return _context.Set<T>()
                .SingleOrDefault(x => x.Id == id);
        }

        public void Add(T record)
        {
            _context.Add(record);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Set<T>().Remove(GetById(id));
            _context.SaveChanges();
        }

        public void SaveChanges()
           => _context.SaveChanges();

    }
}
