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
            DateTime time = DateTime.Now;
            System.Console.WriteLine("What is the name of the Movie?");
            title = Console.ReadLine();
         using(var db = new MovieContext()){

             var movie = new Movie(){
                 Title = title,
                 ReleaseDate = time
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
                   } else{
                       System.Console.WriteLine("\nSorry, No movies were found with that keyword");
                       break;
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

        public void addUser(){
            int age;
            int id;
            System.Console.WriteLine("Age of User?");
            try
            {
                age = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                
                throw new Exception("Please input a valid response!");
            }

            System.Console.WriteLine("Gender of User?(M/F/NA)");
            string gender = Console.ReadLine().ToUpper();

            System.Console.WriteLine("Zipcode of User(XXXXX)");
            string zip = Console.ReadLine();
            using (var db = new MovieContext()){
                

                //var users = db.Users.Include(x=> x.Occupation).ToList();
                var occupation =  db.Occupations.ToList();
                foreach(var occup in occupation){
                    System.Console.WriteLine($"({occup.Id}) {occup.Name}");
                }

                var maxOccup = db.Occupations.OrderByDescending(x => x.Id).FirstOrDefault();
                System.Console.WriteLine($"What is the occupation ID for the user?");
                try
                {
                    id = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    throw new Exception("Please input a valid response!");
                }
                if(id > maxOccup.Id){
                    throw new Exception("Please Enter a valid Occupation ID");
                }

                var selectedOccupation = db.Occupations.FirstOrDefault(x=>x.Id == id);

                
                var user = new User(){
                    Age = age,
                    Gender = gender,
                    ZipCode = zip,
                    Occupation = selectedOccupation
                };  

                db.Users.Add(user);
                db.SaveChanges();

                var selectedUser = db.Users.Where(x=>x.Id==user.Id);
                var outputUser = selectedUser.ToList();

                foreach(var u in outputUser){
                    System.Console.WriteLine($"User ID({u.Id}) \nAge: {u.Age} \nGender: {u.Gender} \nOccupation: {u.Occupation.Name}");
                }
                // var users = selectedUser.Include(x=>x.Occupations).toList();
                
                // foreach(var user in users){
                //     System.Console.WriteLine($"User with ID({user.Id}) Age: {user.Age} Gender: {user.Gender}");
                // }

            // Getting a Occupation and then setting the occupation to the user
            //     using (var db = new MovieContext()) { 
            //     var users = db.Users.Where(x=> x.Id == 1).ToList();

            //     // select your occupation
            //     // 2
            //     var myOccupation = db.Occupations.FirstOrDefault(x=>x.Id == 2);

            //     var user =  new User() {
            //         Age = 32,
            //         Gender = "M",
            //         ZipCode = "53186",
            //         Occupation = myOccupation
            //     };

            // }


                // var selectedUser = db.Users.Where(x=>x.Id==user.Id);
                // var
                
  
            }
        }

        public void userRatedMovie(){
            using (var db = new MovieContext()){
                int uID;
                int movieID;
                int _rating;
                DateTime _ratedAt = DateTime.Now;

                

                //looking up user
                System.Console.WriteLine("What is your User ID?");
                try
                {
                    uID = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    throw new Exception("Please input a valid response!");
                }
                var maxUID = db.Users.OrderByDescending(x => x.Id).FirstOrDefault();
                if(uID > maxUID.Id){
                    throw new Exception("Please Enter a valid User ID");
                }

                var selectedUser = db.Users.FirstOrDefault(x=>x.Id == uID);
                

                // foreach(var u in outputUser){
                //     System.Console.WriteLine($"User ID({u.Id}) \nAge: {u.Age} \nGender: {u.Gender} \nOccupation: {u.Occupation.Name}");
                // }
                
                //looking up movie
                System.Console.WriteLine("What is the Movie Id you want to rate?");
                try
                {
                    movieID = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    throw new Exception("Please input a valid response!");
                }

                var selectedMovie = db.Movies.FirstOrDefault(x=> x.Id == movieID);

                System.Console.WriteLine("What is your rating for this movie?(1-5)");
                try
                {
                    _rating = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    throw new Exception("Please input a valid response!");
                }

                var userMovie = new UserMovie(){
                    Rating = _rating,
                    RatedAt = _ratedAt,
                    User = selectedUser,
                    Movie = selectedMovie
                };
                db.UserMovies.Add(userMovie);
                db.SaveChanges();

                var selectedRating = db.UserMovies.Where(x=>x.Id==userMovie.Id);
                

                foreach(var o in selectedRating){
                    System.Console.WriteLine($"Id for Rating({o.Id}) Rating given: {o.Rating} Rated at: {o.RatedAt} \n UserID ({o.User.Id}) Users Age: {o.User.Age} Users Gender: {o.User.Gender}\n  Id for Movie ({o.Movie.Id}) Movie Title: {o.Movie.Title} Movie Release Date: {o.Movie.ReleaseDate} ");
                }

            }
        }
    
    
        public void listMedia(){
            
        }        
        public void searchGenre(string response){
           
        }


    }

}