using Microsoft.EntityFrameworkCore;
using MovieCatalog.Models;

namespace MovieCatalog.Dao
{
    public class MovieCatalogContext : DbContext
    {

        public DbSet<Viewer> Viewers { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public MovieCatalogContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MovieCatalog;Username=postgres;Password=qwerty11");
        }

    }
}
