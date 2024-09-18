namespace MovieSearchAPI.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
        public List<MovieDetailDTO> Details { get; set; }
    }
}
