using System.Collections.Generic;


namespace MovieLibrary.Models{


    public class MovieJson
    {
        public int id {get; set;}

        public string title {get; set;}

        public string genre {get; set;}


        public MovieJson(int id, string title, string genre){
            this.id = id;
            this.title = title;
            this.genre = genre;
        }
    }
}
