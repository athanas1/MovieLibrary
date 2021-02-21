using System;
using NLog.Web;


namespace MovieLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            do
            {
                var userSelection = menu.MenuSelection();  

                menu.Choice(userSelection);

            } while(menu.isValid);

            
        }
    }
}
