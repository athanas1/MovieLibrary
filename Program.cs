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
                .AddSingleton<IDatabaseMovieManager, DatabaseMovieManager>()
                .AddSingleton<IMovieManager, MovieManager>()
                .AddSingleton<IShowManager, ShowManager>()
                .AddSingleton<IVideoManager, VideoManager>()
                .AddSingleton<IMenu, DatabaseMenu>()
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
