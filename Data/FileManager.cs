using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using MovieLibrary.Models;

namespace MovieLibrary.Data
{
    internal class FileManager
    {
        private readonly string fileName = Path.Combine(Environment.CurrentDirectory, "Files", "movies.csv");

        public FileManager(){
            // if the file does not exist throw FnF exception
            if(!File.Exists(fileName)) throw new FileNotFoundException($"Can't find file {filename}");
        }

        public void addMovie(Movie movie){
            var movies = GetAll();
            
            var lastMovie = movies.OrderBy(o => o.MovieId).Last();
            movie.MovieId = lastMovie.MovieId + 1;

            movies.Add(movie); 
            using (var writer = new StreamWriter(_filename))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<MovieMap>();
                    csv.WriteRecords(movies);
                }
            }
        }

        public List<Movie> GetAll()
        {
            IEnumerable<Movie> records;

            using (var reader = new StreamReader(_filename))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<MovieMap>();

                    records = csv.GetRecords<Movie>().ToList();
                }
            }
            return new List<Movie>(records);
        }

            //tried getting this to work without the context
        // public List<Movie> GetMovies(){
        //     return GetAll();
        // }
        
    }
}