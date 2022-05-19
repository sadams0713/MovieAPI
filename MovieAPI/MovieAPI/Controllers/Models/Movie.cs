namespace MovieAPI.Controllers.Models
{
    public enum Genre
    {
        Horror,
        Romance,
        Comedy,
        Animated

    }
    public class Movie
    {
        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        public Genre Genre { get; set; }
    }
}
