
using Microsoft.EntityFrameworkCore;
using Movies.Data.Configuration;
using Movies.Data.Entities;

namespace Movies.Data.Context
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<MovieDetail> MovieDetail { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new MovieDetailConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());



        }
    }
}
