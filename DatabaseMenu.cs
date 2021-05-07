using System;
using System.Collections.Generic;
using MovieLibrary.Data;

namespace MovieLibrary
{
     internal class DatabaseMenu : IMenu {

         private IDatabaseMovieManager _databaseMovieManager;

         public bool isValid { get; set; }
        public DatabaseMenu(IDatabaseMovieManager movieManager){
            _databaseMovieManager = movieManager;
            DisplayMenu();
        }
        
private void DisplayMenu(){
            System.Console.WriteLine("\n\nHello! Welcome to the Magnificent Media Library");
            System.Console.WriteLine("Please select the options below");
            
        }

        public string MenuSelection(){
        System.Console.WriteLine("\n\nSelect the following options");
        System.Console.WriteLine("1) Search our movies");
        System.Console.WriteLine("2) Add a Movie to our list");
        System.Console.WriteLine("3) Update a Movie");
        System.Console.WriteLine("4) Delete a Movie");
        System.Console.WriteLine("5) Add a User to the System");
        System.Console.WriteLine("6) Rate a Movie");
        System.Console.WriteLine("7) List all of our Media");
        System.Console.WriteLine("Any other key will leave the system");
        
        var response = Console.ReadLine();
        if(response == "1"){
            isValid = true;
            
            
        } else if (response == "2") {
            isValid = true;
            
        } else if(response == "3"){
            isValid = true;
            
        }
        else if(response == "4"){
            isValid = true;
            
        }else if(response == "5"){
            isValid = true;
            
        }else if(response == "6"){
            isValid = true;
            
        }else if(response == "7"){
            isValid = true;
            
        }else{
            isValid = false;
            
        }
        return response;
        }


        public void Choice(string userResponse){
            if(userResponse == "1"){
                System.Console.WriteLine("What Movie would you like to search for?(NO NUMBERS PLEASE GOD)");
                var response = Console.ReadLine();
                _databaseMovieManager.searchTitle(response);
                
            } else if (userResponse == "2"){
                _databaseMovieManager.addMedia();

            } else if(userResponse == "3"){
                _databaseMovieManager.updateMovie();

            } else if(userResponse == "4"){
                _databaseMovieManager.deleteMovie();

            } else if (userResponse == "5"){
                _databaseMovieManager.addUser();
            } else if (userResponse == "6"){
                _databaseMovieManager.userRatedMovie();
            } else if (userResponse == "7"){
                _databaseMovieManager.listMedia();
            }
        }
     }
}

