using Microsoft.EntityFrameworkCore;
using MovieDb.Entities;

namespace MovieDb.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
               : base(options)
        {
        }

        DbSet<Movie> Movie { get; set; }
        DbSet<Genre_ids> Genre_ids { get; set; }

    }
}
