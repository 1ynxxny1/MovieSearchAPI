namespace MovieSearchAPI.DTOs
{
    public class MovieRatingDTO
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Source { get; set; }
        public string Value { get; set; }
    }
}
