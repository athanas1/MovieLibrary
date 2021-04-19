using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieLibrary.DataModels;

namespace MovieLibrary.Context
{
    public class MovieContext : DbContext
    {
        public DbSet<Genre> Genres {get;set;}
        public DbSet<Movie> Movies {get;set;}
        public DbSet<MovieGenre> MovieGenres {get;set;}
        public DbSet<Occupation> Occupations {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<UserMovie> UserMovies {get;set;}

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {   
                // IConfiguration config = new ConfigurationBuilder()
                //     .AddJsonFile("appsettings.json", true, true)
                //     .Build();
                optionsBuilder.UseSqlServer();
            }
    }
}