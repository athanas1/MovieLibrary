namespace MovieLibrary.Data
{
    public interface IDatabaseMovieManager : IManager{

        void updateMovie(string response);

        void deleteMovie(string response);
    }

}