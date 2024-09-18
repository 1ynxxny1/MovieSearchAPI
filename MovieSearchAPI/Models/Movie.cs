namespace MovieSearchAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
        public MovieDetail MovieDetails { get; set; }
        public ICollection<MovieRating> MovieRatings { get; set; }
    }
}
