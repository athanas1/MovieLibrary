using MovieLibrary.Data;

namespace MovieLibrary{

    public interface IMenu{

        bool isValid { get; set; }

        string MenuSelection();
        void Choice(string userResponse);
    }
}