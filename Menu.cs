using System;
using System.Collections.Generic;
using MovieLibrary.Data;
using ConsoleTables;


namespace MovieLibrary {

    
    internal class Menu : IMenu {
        
        private IMovieManager _movieManager;
        private IShowManager _showManager;
        private IVideoManager _videoManager;
        private IDatabaseMovieManager _databaseMovieManager;

        

        public bool isValid { get; set; }
        public Menu(IMovieManager movieManager, IShowManager showManager, IVideoManager videoManager,IDatabaseMovieManager databaseMovieManager){
            _movieManager = movieManager;
            _showManager = showManager;
            _videoManager = videoManager;
            _databaseMovieManager = databaseMovieManager;
            DisplayMenu();
        }

        //Though having the menu display from the constructor was cool so trying it out.
        private void DisplayMenu(){
            System.Console.WriteLine("\n\nHello! Welcome to the Magnificent Media Library");
            System.Console.WriteLine("Please select the options below");
            
        }

        public string MenuSelection(){
            System.Console.WriteLine("\n\nSelect the following options");
            System.Console.WriteLine("1) List of our media");
            System.Console.WriteLine("2) Add a media to our list");
            System.Console.WriteLine("3) Search our media collections");
            System.Console.WriteLine("Any other key will leave the system");
            
            var response = Console.ReadLine();

            if(response == "1"){
                isValid = true;
                
            } else if (response == "2") {
                isValid = true;
                
            } else if(response == "3"){
                isValid = true;
            }
             else{
                isValid = false;
                
            }

            return response;
        }
        

        public void Choice(string userResponse){
            //Tried if
            string answer = "";
            string answer2 = "";
            string answer3 = "";
            if(userResponse == "1"){
                System.Console.WriteLine("Which media type would you like a list of? \n1)Movies\n2)Shows\n3)Videos");
                answer = Console.ReadLine();
                if(answer == "1"){
                    //manager = new MovieManager();
                    Console.WriteLine();
                    _movieManager.listMedia();
                } else if(answer == "2")
                {
                    //showManager = new ShowManager();
                    System.Console.WriteLine();
                    _showManager.listMedia();
                } else if(answer == "3")
                {
                    
                    //videoManager = new VideoManager();
                    System.Console.WriteLine();
                    _videoManager.listMedia();
                } else
                {
                    System.Console.WriteLine("Please select a correct response!");
                }
            } else if(userResponse == "2"){
                System.Console.WriteLine("\n\nWhich media type would you like to add? \n1)Movies\n2)Shows\n3)Videos");
                answer2 = Console.ReadLine();
                if(answer2 == "1"){
                    //manager = new MovieManager();
                    Console.WriteLine();
                    _movieManager.addMedia();
                } else if(answer2 == "2")
                {
                   // showManager = new ShowManager();
                    System.Console.WriteLine();
                    _showManager.addMedia();
                } else if(answer2 == "3")
                {
                    //videoManager = new VideoManager();
                    System.Console.WriteLine();
                    _videoManager.addMedia();
                } else
                {
                    System.Console.WriteLine("Please select a correct response!");
                } 
            } else if(userResponse == "3"){
                System.Console.WriteLine("\n\n Search based on the following options \n1)Title\n2)Genre");
                answer3 = Console.ReadLine();
                if(answer3 == "1"){
                    System.Console.WriteLine("What Title to search by?");
                    var response = Console.ReadLine();
                    _movieManager.searchTitle(response);
                    _showManager.searchTitle(response);
                    _videoManager.searchTitle(response);
                }else if(answer3 == "2"){
                    System.Console.WriteLine("What Genre do you want to search by?");
                    var response = Console.ReadLine();
                    _movieManager.searchGenre(response);
                    _showManager.searchGenre(response);
                    _videoManager.searchGenre(response);
                }
            }
            // switch (userResponse)
            // {
            //     case "1":
            //         // List movies
            //         manager = new MovieManager();
            //         System.Console.WriteLine();
            //         manager.listMovies();
            //         break;
            //     case "2":
            //         // Ask user to enter movie details
            //         manager = new MovieManager();
            //         Console.WriteLine();
            //         manager.addMovie();
            //         break;
            //     default:
            //         //default will close app
            //         System.Console.WriteLine("Thank you for using Magnificent Movie Service");  
            //         break;  
            // }

            /////////     tried putting the isvalid in choice, too many issues with this
            // if (selection == "1"){
            //     System.Console.WriteLine("here are the list of all our movies");
            //     valid = true;
            // } else if(selection == "2"){
            //     System.Console.WriteLine("here you can add movies to our list");
            //     valid = true;
            // } else if( selection != "1"|| "2"){
            //     System.Console.WriteLine("Oy you fucked up mate");
            //     valid = false;
            }
    }
}
