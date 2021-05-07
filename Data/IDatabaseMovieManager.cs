namespace MovieLibrary.Data
{
    public interface IDatabaseMovieManager : IManager{

        void updateMovie();

        void deleteMovie();

        void addUser();

        void userRatedMovie();
    }

}