using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using MovieLibrary.Models;


namespace MovieLibrary.Data
{

    
    internal class MovieManager : IMovieManager
    {
        private readonly string file = Path.Combine(Environment.CurrentDirectory, "Files", "movies.csv");

        public void listMedia(){
            if(File.Exists(file)){
                int counter = 0;
                string answer = "";
                
                //Reading data from file
                StreamReader sr = new StreamReader(file);
                while(!sr.EndOfStream)
                {
                    
                    string line = sr.ReadLine();
                    //converting each string to an array with split with a ,
                    string[] arr = line.Split(',');
                    //output the array?
                    string str = String.Join("  ", arr);
                    Console.WriteLine(str);
                    counter++;

                    if(counter == 10){
                        System.Console.WriteLine("\n Would you like to go to the next page?   (Y/N)");
                        answer = Console.ReadLine().ToUpper();
                        if(answer == "Y") {
                            counter = 0;
                        } else {
                            break;
                        }
                    }
                        
                    // if(valid)
                    // {
                    //     int x = 0;
                        
                    //     System.Console.WriteLine("List next page?  (Y/N)");
                    //     answer = Console.ReadLine().ToUpper();
                    //     if(answer == "Y"){
                    //         valid = true;
                    //     } else{
                    //         valid = false;
                    //     }
                    //     {
                            
                    //     }
                    // }
                }
                sr.Close();
            }
            else
            {
                Console.WriteLine("File does not exist");
            }

        }

        public void addMedia()
        {
            string movieId = "";
            int id = 0;
            string answer;
            string title = "";
            List<string> genres = new List<string>();
            var list = new List<string>();
            StreamReader sr = new StreamReader(file);
            var movie = new Movie();

            System.Console.WriteLine("What is the name of the movie?");
            title = Console.ReadLine();
            //adds writers to a list to check if there are duplicates
            list.Add(title);
            while(!sr.EndOfStream){
                 
                 string line = sr.ReadLine();
                 string[] arr = line.Split(",");
                 
                 movieId = arr[0];
                 list.Add(arr[1]);

                 if(movieId == "movieId"){
                     id = 0;
                 } else
                 {
                    try
                    {
                        id = Int32.Parse(movieId);
                        
                    } catch (FormatException e)
                    {
                        System.Console.WriteLine(e.Message);
                    }
                 }

                if(list.Count != list.Distinct().Count())
                {
                    System.Console.WriteLine("Duplicate Title! Please try again!");
                    return;
                }


            }
            id++;
            movie.id = id;
            movie.title = title;
            sr.Close();
            StreamWriter sw = new StreamWriter(file, true);
            
            
            /////////////----Couldn't use this, was getting file already opened error
            // while(!sr.EndOfStream){
                
            //     string line = sr.ReadLine();
            //     string[] arr = line.Split(",");
            //     title = arr[1];
            //     do{
            //         System.Console.WriteLine("Title of movie?");
            //         title = Console.ReadLine();
            //         if((titles.Count != titles.Distinct().Count())){
            //             System.Console.WriteLine("That is a duplicate value. Please try again.");
            //         }
            //     }while((titles.Count != titles.Distinct().Count()));
            // }

            do
            {
                System.Console.WriteLine("Genre(s) of movie?");
                string output = Console.ReadLine();
                genres.Add(output);
                System.Console.WriteLine("Any other genres? (Y/N)");
                answer = Console.ReadLine().ToUpper();
            } while (answer == "Y");
            movie.genre = String.Join("|", genres);
            System.Console.WriteLine(movie.Display());
            sw.WriteLine(movie.Display());
            //sw.WriteLine("{0},{1},{2}", id,title,genre);

            
            sw.Close();


        }
        public void searchTitle(string response){
            int counter = 0;
            List<string> searchList = new List<string>();
            List<string> completeList = new List<string>();
            StreamReader sr = new StreamReader(file);
            while(!sr.EndOfStream){
                
                string line = sr.ReadLine();
                string[] arr = line.Split(",");

                searchList.Add(arr[1]);
                
                
                var foundSearch = searchList.Where(search => search.Contains(response));
                completeList = foundSearch.Distinct().ToList();
                //completeList.foundSearch.Distinct().ToList();
                counter = foundSearch.Count();
                
            }
            sr.Close();
            System.Console.WriteLine("\nNumber of search(s) found based off " + response +" was "+ counter + " in Movies");
            System.Console.WriteLine("\n");
            foreach(string search in completeList)
            {
                System.Console.WriteLine(search);
            }
        }

        public void searchGenre(string response){
            int counter = 0;
            List<string> searchList = new List<string>();
            List<string> nameList = new List<string>();
            List<string> completeList = new List<string>();
            StreamReader sr = new StreamReader(file);
            while(!sr.EndOfStream){
                
                string line = sr.ReadLine();
                string[] arr = line.Split(",");

                searchList.Add(arr[2]);
                var foundSearch = searchList.Where(search => search.Contains(response));

                completeList = foundSearch.Distinct().ToList();
                //completeList.foundSearch.Distinct().ToList();
                counter = foundSearch.Count();
                
            }
            sr.Close();
            System.Console.WriteLine("\nNumber of search(s) found based off " + response +" was "+ counter + " in Movies");
            System.Console.WriteLine("\n");
            foreach(string search in completeList)
            {
                System.Console.WriteLine(search);
            }
        }
    }
}