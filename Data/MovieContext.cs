using System.Collections.Generic;
using MovieLibrary.Models;

namespace MovieLibrary.Data
{
    internal class MovieContext
    {
        private readonly FileRepository file;
        private readonly Movie movie;

        public MovieContext(Movie movie = null)
        {
            file = new FileRepository();
            movie = this.movie;
        }

        public void AddMovie()
        {
            file.Add(movie);
        }

        public List<Movie> GetMovies()
        {
           return file.GetAll();
        }
    }
}