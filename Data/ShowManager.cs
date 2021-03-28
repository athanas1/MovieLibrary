using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using MovieLibrary.Models;

namespace MovieLibrary.Data
{

    internal class ShowManager : IShowManager
    {
        private readonly string file = Path.Combine(Environment.CurrentDirectory, "Files", "shows.csv");

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
                }
                sr.Close();
            }
            else
            {
                Console.WriteLine("File does not exist");
            }

        }

        public void addMedia(){
            string showId = "";
            int id  = 0;
            string answer;
            string title = "";
            List<string> writers = new List<string>();
            var list = new List<string>();
            StreamReader sr = new StreamReader(file);
            var show = new Show();
            // int season;
            // int episodes;

            System.Console.WriteLine("What is the name of the show?");
            title = Console.ReadLine();
            
            //list.Add(title);
            while(!sr.EndOfStream){
                 
                 string line = sr.ReadLine();
                 string[] arr = line.Split(",");
                 
                 showId = arr[0];
                 //list.Add(arr[1]);

                 if(showId == "showId"){
                     id = 0;
                 } else
                 {
                    try
                    {
                        id = Int32.Parse(showId);
                        
                    } catch (FormatException e)
                    {
                        System.Console.WriteLine(e.Message);
                    }
                 }

                // if(list.Count != list.Distinct().Count())
                // {
                //     System.Console.WriteLine("Duplicate Title! Please try again!");
                //     return;
                // }


            }
            id++;
            show.id = id;
            show.title = title;
            sr.Close();

            System.Console.WriteLine("What season of the show do you want to add?");
            try 
            {
                show.season = Int32.Parse(Console.ReadLine());
            } catch (FormatException e)
            {
                System.Console.WriteLine(e.Message);
            }

            System.Console.WriteLine("What episode of season " + show.season +  " do you want to add?");
            try 
            {
                show.episode = Int32.Parse(Console.ReadLine());
            } catch (FormatException e)
            {
                System.Console.WriteLine(e.Message);
            }
            
            StreamWriter sw = new StreamWriter(file, true);

            do
            {
                System.Console.WriteLine("Writer(s) of the show?");
                string output = Console.ReadLine();
                writers.Add(output);
                System.Console.WriteLine("Any other writers? (Y/N)");
                answer = Console.ReadLine().ToUpper();
            } while (answer == "Y");
            show.writer = String.Join("|", writers);
            System.Console.WriteLine(show.Display());
            sw.WriteLine(show.Display());

            sw.Close();

        }
        // searchMedia(string response){

        // }
    }
}