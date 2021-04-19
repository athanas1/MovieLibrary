using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using MovieLibrary.Context;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.DataModels;

namespace MovieLibrary.Data{

    internal class DatabaseMovieManager : IDatabaseMovieManager{



        public void addMedia(){
            string title = "";
            System.Console.WriteLine("What is the name of the Movie?");
            title = Console.ReadLine();
         using(var db = new MovieContext()){

             var movie = new Movie(){
                 Title = title
             };
             db.Movies.Add(movie);
             db.SaveChanges();
            }
        }

        public void searchTitle(string response){
            using(var db = new MovieContext()){
                
                
               var movies = db.Movies;
                
               foreach(var movie in movies){
                   if(movie.Title.Contains(response)){
                       System.Console.WriteLine($"({movie.Id}) {movie.Title} {movie.ReleaseDate}");
                   }
               }
                
            }
        }

        public void updateMovie(){
            int id;
            string title = "";
            System.Console.WriteLine("What is the ID of the Movie you want to update?");
            try
            {
                id = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                
                throw new Exception("Please input a valid response!");
            }

           using (var db = new MovieContext()){
                

                // var foundMovie = db.Movies.Where(x=>x.Id == id)
                // .FirstOrDefault();

                // System.Console.WriteLine($"Movie attempting to update is: ({foundMovie.Id})  {foundMovie.Title}" );
                
                System.Console.WriteLine("Change the Title of the movie to what?");
                title = Console.ReadLine();

                var movie = new Movie(){
                    Id = id,
                    Title = title
                };

                db.Movies.Update(movie);
                db.SaveChanges();

                System.Console.WriteLine($"\nNew Title of movie with ID({movie.Id}) {movie.Title}");

            //    foreach (var movie in movies){
            //        if(movie.Id == id){
            //            System.Console.WriteLine($"({movie.Id}) {movie.Title}");
            //        }
            //    }

           }
        }

        public void deleteMovie(){
            int id;
            System.Console.WriteLine("What is the ID of the Movie you want to Delete?");
            try
            {
                id = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                
                throw new Exception("Please input a valid response!");
            }
            using (var db = new MovieContext()){

                var foundMovie = db.Movies.Where(x=> x.Id == id)
                .FirstOrDefault();

                System.Console.WriteLine($"You are about to Delete: {foundMovie.Title} Are you sure? (Y/N)");

                var answer = Console.ReadLine().ToUpper();
                if(answer == "Y"){
                    System.Console.WriteLine($"{foundMovie.Title} has been Deleted");
                    db.Movies.Remove(foundMovie);
                    db.SaveChanges();
                } else{
                    System.Console.WriteLine("Have a Good day");
                }
            }
            
        }
    
    
        public void listMedia(){
            
        }        
        public void searchGenre(string response){
           
        }


    }

}