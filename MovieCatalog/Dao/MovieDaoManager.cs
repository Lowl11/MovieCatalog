﻿using Microsoft.EntityFrameworkCore;
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

        private const int MoviesPerPage = 10;

        public MovieDaoManager(MovieCatalogContext context)
            : base(context)
        {}

        public IEnumerable<Movie> GetPage(int? page)
        {
            int pageNumber = page ?? 0;
            return GetMovies()
                .OrderByDescending(movie => movie.Id)
                .Skip(pageNumber * MoviesPerPage)
                .Take(MoviesPerPage)
                .AsEnumerable();
        }

        public Exception AddMovie(Movie movie, Viewer author)
        {
            try
            {
                movie.AuthorId = author.Id;
                Add(movie);
            }
            catch
            {
                return new Exception("Произошла ошибка при добавлении фильма");
            }
            return null;
        }

        public Exception UpdateMovie(Movie updated)
        {
            try
            {
                Movie fromSource = GetMovieById(updated.Id);
                fromSource.Title = updated.Title;
                fromSource.PublishYear = updated.PublishYear;
                fromSource.Producer = updated.Producer;
                fromSource.Content = updated.Content;
                fromSource.CoverUrl = updated.CoverUrl;
                SaveChanges();
            }
            catch
            {
                return new Exception("Произошла ошибка при сохранении изменений");
            }
            return null;
        }

        public IQueryable<Movie> GetMovies()
        {
            return GetAll()
                .Include(movie => movie.Author);
        }

        public Movie GetMovieById(int? id)
        {
            return GetAll()
                .Include(movie => movie.Author)
                .SingleOrDefault(movie => movie.Id == id.Value);
        }

    }
}
