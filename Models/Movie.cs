using CsvHelper.Configuration;

namespace MovieLibrary.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        //This is a map and allows you to map the attributes of a class with the header names of a CSV text

        //creating the map
        public class MovieMap : ClassMap<Movie>
        {

            public MovieMap()
            {
                //allows us to easily manipulate csv data throught he use of csv helper
                Map(m => m.MovieId).Index(0).name("movieId");
                Map(m => m.Title).Index(0).name("Title");
                Map(m => m.Genre).Index(0).name("Genre");
            }
            // Couldn't get it to work without specifying which index to copy too I guess??
            // public MovieMap()
            // {
            //     Map(m => m.MovieId);
            //     Map(m => m.Title);
            //     Map(m => m.Genre);
            // }
        }
    }
}