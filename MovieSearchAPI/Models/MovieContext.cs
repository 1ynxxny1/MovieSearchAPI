using Microsoft.EntityFrameworkCore;

namespace MovieSearchAPI.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<MovieDetail> MovieDetails { get; set; }
        public DbSet<MovieRating> MovieRatings { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieDetail>()
                .HasMany(md => md.MovieRatings)
                .WithOne(mr => mr.MovieDetail)
                .HasForeignKey(mr => mr.MovieId);

            modelBuilder.Entity<Movie>()
            .HasMany(m => m.MovieRatings)
            .WithOne(mr => mr.Movie)
            .HasForeignKey(mr => mr.MovieId);
        }
    }
}
