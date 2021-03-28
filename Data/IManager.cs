namespace MovieLibrary.Data
{
public interface IManager{
    void listMedia();

    void addMedia();

    void searchTitle(string response);
    
    void searchGenre(string response);
}

}