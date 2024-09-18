namespace MovieSearchAPI.Models
{
    public class MovieRating
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Source { get; set; }
        public string Value { get; set; }
        public Movie Movie { get; set; }
        public MovieDetail MovieDetail { get; set; }
    }
}
