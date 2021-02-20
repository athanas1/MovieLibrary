using System;
using NLog.Web;


namespace MovieLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie movie = new Movie();
            Menu menu = new Menu();
            File file = new File();

            file.addFile("movies.csv");
            Menu.display();

            do{
            var choice = menu.GetInput();
            

             } while(choice == "1"|| choice == "2");
        }
    }
}
