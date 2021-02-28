using System;
using System.Collections.Generic;
using MovieLibrary.Data;
using ConsoleTables;


namespace MovieLibrary {

    internal class Menu {
        
        private MovieManager manager;
        private ShowManager showManager;
        private VideoManager videoManager;
        
        

        public bool isValid { get; set; }
        public Menu(){
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
            System.Console.WriteLine("2) Add a  media to our list");
            System.Console.WriteLine("Any other key will leave the system");
            
            var response = Console.ReadLine();

            if(response == "1"){
                isValid = true;
                
            } else if (response == "2") {
                isValid = true;
                
            } else{
                isValid = false;
                
            }

            return response;
        }
        

        public void Choice(string userResponse){
            //Tried if
            string answer = "";
            string answer2 = "";
            if(userResponse == "1"){
                System.Console.WriteLine("Which media type would you like a list of? \n1)Movies\n2)Shows\n3)Videos");
                answer = Console.ReadLine();
                if(answer == "1"){
                    manager = new MovieManager();
                    Console.WriteLine();
                    manager.listMovies();
                } else if(answer == "2")
                {
                    showManager = new ShowManager();
                    System.Console.WriteLine();
                    showManager.listShows();
                } else if(answer == "3")
                {
                    videoManager = new VideoManager();
                    System.Console.WriteLine();
                    videoManager.listVideos();
                } else
                {
                    System.Console.WriteLine("Please select a correct response!");
                }
            } else if(userResponse == "2"){
                System.Console.WriteLine("\n\nWhich media type would you like to add? \n1)Movies\n2)Shows\n3)Videos");
                answer2 = Console.ReadLine();
                if(answer2 == "1"){
                    manager = new MovieManager();
                    Console.WriteLine();
                    manager.addMovie();
                } else if(answer2 == "2")
                {
                    showManager = new ShowManager();
                    System.Console.WriteLine();
                    showManager.addShow();
                } else if(answer2 == "3")
                {
                    videoManager = new VideoManager();
                    System.Console.WriteLine();
                    videoManager.addVideo();
                } else
                {
                    System.Console.WriteLine("Please select a correct response!");
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
