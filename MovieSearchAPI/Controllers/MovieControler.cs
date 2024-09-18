using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieSearchAPI.DTOs;
using MovieSearchAPI.Models;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovieByTitle([FromQuery] string title)
        {
            var movies = await _context.Movies
                .Where(m => m.Title.Contains(title))
                .Select(m => new MovieDTO
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year,
                    Type = m.Type,
                    Poster = m.Poster
                }).ToListAsync();

            if (movies == null || !movies.Any())
            {
                return NotFound();
            }

            return Ok(movies);
        }


        [HttpGet("movie/{id}")]
        public async Task<ActionResult<MovieDetailDTO>> GetMovieDetailsById(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.MovieDetails)
                .Include(m => m.MovieRatings)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            var movieDetailDto = new MovieDetailDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Year = movie.Year,
                Rated = movie.MovieDetails.Rated,
                Released = movie.MovieDetails.Released,
                Runtime = movie.MovieDetails.Runtime,
                Genre = movie.MovieDetails.Genre,
                Director = movie.MovieDetails.Director,
                Writer = movie.MovieDetails.Writer,
                Actors = movie.MovieDetails.Actors,
                Plot = movie.MovieDetails.Plot,
                Language = movie.MovieDetails.Language,
                Country = movie.MovieDetails.Country,
                Awards = movie.MovieDetails.Awards,
                Poster = movie.MovieDetails.Poster,
                Metascore = movie.MovieDetails.Metascore,
                imdbRating = movie.MovieDetails.imdbRating,
                imdbVotes = movie.MovieDetails.imdbVotes,
                imdbID = movie.MovieDetails.imdbID,
                Type = movie.MovieDetails.Type,
                DVD = movie.MovieDetails.DVD,
                BoxOffice = movie.MovieDetails.BoxOffice,
                Production = movie.MovieDetails.Production,
                Website = movie.MovieDetails.Website,
                Ratings = movie.MovieRatings.Select(r => new MovieRatingDTO
                {
                    Id = r.Id,
                    Source = r.Source,
                    Value = r.Value
                }).ToList()
            };

            return Ok(movieDetailDto);
        }

    }
}

