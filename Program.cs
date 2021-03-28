using System;
using NLog.Web;
using MovieLibrary.Data;
using Microsoft.Extensions.DependencyInjection;



namespace MovieLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IMovieManager, MovieManager>()
                .AddSingleton<IShowManager, ShowManager>()
                .AddSingleton<IVideoManager, VideoManager>()
                .AddSingleton<IMenu, Menu>()
                .BuildServiceProvider();
            
            var menu = serviceProvider.GetService<IMenu>();
            do
            {
                var userSelection = menu.MenuSelection();  

                menu.Choice(userSelection);

            } while(menu.isValid);

            
        }
    }
}
