using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using MovieLibrary.Models;

namespace MovieLibrary.Data
{
    internal class VideoManager
    {
        private readonly string file = Path.Combine(Environment.CurrentDirectory, "Files", "video.csv");


        public void listVideos(){
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

        public void addVideo()
        {
            string videoId = "";
            int id = 0;
            string answer;
            string title = "";
            List<string> formats = new List<string>();
            List<int> regions = new List<int>();
            StreamReader sr = new StreamReader(file);
            var video = new Video();

            System.Console.WriteLine("What is the name of the show?");
            title = Console.ReadLine();

            while(!sr.EndOfStream){
                 
                string line = sr.ReadLine();
                string[] arr = line.Split(",");
                
                videoId = arr[0];
                //list.Add(arr[1]);
                if(videoId == "videoId"){
                    id = 0;
                } else
                {
                   try
                   {
                       id = Int32.Parse(videoId);
                       
                   } catch (FormatException e)
                   {
                       System.Console.WriteLine(e.Message);
                   }
                }
            }
            id++;
            video.id = id;
            video.title = title;
            sr.Close();

            do
            {
                System.Console.WriteLine("What are the videos format(s)?");
                string output = Console.ReadLine();
                formats.Add(output);
                System.Console.WriteLine("Any other formats? (Y/N)");
                answer = Console.ReadLine().ToUpper();
            } while (answer == "Y");
            video.format = String.Join("|", formats);
            
            System.Console.WriteLine("What is the length of the video in minutes?");
            try 
            {
                video.length = Int32.Parse(Console.ReadLine());
            } catch (FormatException e)
            {
                System.Console.WriteLine(e.Message);
            }

             do
            {
                System.Console.WriteLine("What is the videos region code(s)?");
                try
                {
                   int output = Int32.Parse(Console.ReadLine()); 
                   regions.Add(output);
                } catch (FormatException e)
                {
                    System.Console.WriteLine(e.Message);
                    break;
                }
                
                
                System.Console.WriteLine("Any other region codes?? (Y/N)");
                answer = Console.ReadLine().ToUpper();
            } while (answer == "Y");

            video.region = String.Join('|', regions);

            StreamWriter sw = new StreamWriter(file, true);
            
            sw.WriteLine(video.Display());
            sw.Close();
            
        }
    }
}