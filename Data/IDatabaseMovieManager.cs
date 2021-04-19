namespace MovieLibrary.Data
{
    public interface IDatabaseMovieManager : IManager{

        void updateMovie();

        void deleteMovie();


    }

}