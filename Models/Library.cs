namespace MovieLibrary.Models
{
    public abstract class Library
    {
        public int id { get; set; }

        public string title { get; set; }

        public abstract string Display();

    }

    public class Movie : Library
    {
        public string genre { get; set; }
        
        public override string Display(){
            return (id + "," + title + "," + genre);
            //sw.WriteLine("{0}{1}{2},", id,title,genre);
        }
    }

    public class Show : Library
    {
        public int season { get; set; }
        public int episode { get; set; }
        public string writer { get; set; }

        public override string Display(){
           return (id + "," + title + "," + season + "," + episode + "," + writer);
        }
    }

    public class Video : Library
    {
        public string format { get; set; }
        public int length { get; set; }
        public int region { get; set; }
        
        public override string Display(){
            return (id + "," + title + "," + format + "," + length + "," + region); 
        }
    }
}