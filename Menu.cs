using System;
using System.Collections.Generic;
using MovieLibrary.Data;
using ConsoleTables;


namespace MovieLibrary {

    internal class Menu {
        
        private FileManager manager;

        public bool isValid { get; set; }
        public Menu(){
            DisplayMenu();
        }

        //Though having the menu display from the constructor was cool so trying it out.
        private void DisplayMenu(){
            System.Console.WriteLine("Hello! Welcome to the Magnificent Movie Library");
            System.Console.WriteLine("Please select the options below");
            
        }

        public string MenuSelection(){
            System.Console.WriteLine("Select the following options");
            System.Console.WriteLine("1) List of our movies");
            System.Console.WriteLine("2) Add a movie to our list");
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
           
            switch (userResponse)
            {
                case "1":
                    // List movies
                    manager = new FileManager();
                    System.Console.WriteLine();
                    manager.listMovies();
                    break;
                case "2":
                    // Ask user to enter movie details
                    manager = new FileManager();
                    Console.WriteLine();
                    manager.addMovie();
                    break;
                default:
                    //default will close app
                    System.Console.WriteLine("Thank you for using Magnificent Movie Service");  
                    break;  
            }

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
