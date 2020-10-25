using Microsoft.EntityFrameworkCore;
using TreenetTestProject.Models;

namespace TreenetTestProject.Data
{
    public class FilmContexts : DbContext
    {
        public FilmContexts(DbContextOptions<FilmContexts> options) : base(options) { }

        public DbSet<Film> Film { get; set; }
        public DbSet<Search> Search { get; set; }
    }

}
