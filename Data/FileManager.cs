using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;


namespace MovieLibrary.Data
{
    internal class FileManager
    {
        private readonly string file = Path.Combine(Environment.CurrentDirectory, "Files", "movies.csv");

        public void listMovies(){
            if(File.Exists(file)){
                //Reading data from file
                StreamReader sr = new StreamReader(file);
                while(!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    //converting each string to an array with split with a ,
                    string[] arr = line.Split(',');
                    //output the array?
                    string str = String.Join(",", arr);
                    Console.WriteLine(str);
                }
                sr.Close();
            }
            else
            {
                Console.WriteLine("File does not exist");
            }

        }

        public void addMovie()
        {
            string movieId = "";
            int id = 0;
            string answer;
            int counter = 0;
            string title = "";
            
            List<string> genres = new List<string>();
            List<string> titles = new List<string>();
            StreamReader sr = new StreamReader(file);


            
            while(!sr.EndOfStream){
                
                string line = sr.ReadLine();
                string[] arr = line.Split(",");
               
                movieId = arr[0];
        
                if(movieId == "movieId"){
                    id = 0;
                } else{
                    id = Int32.Parse(movieId);
                    id++;
                }
                  
                   
            }

            
            
           
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
            string genre = String.Join("|", genres);
            System.Console.WriteLine(id);
            sw.WriteLine("{0},{1},{2}" id,title,genre);

            
            sw.Close();
        }
        //   Struggling with finding a way to check for duplicates
        // public void duplicateTitle(string title){
        //     List<string> titles = new List<string>();
        //     StreamReader sr = new StreamReader(file);
            
        //     while(!sr.EndOfStream){
                
        //         string line = sr.ReadLine();
        //         string[] arr = line.Split(",");
               
        //         titles = arr[1];

        //         if(titles.Count != list.Distinct().Count())
        //         {
        //             title = console.ReadLine();
        //         }
        //     }
        // }
    }
}