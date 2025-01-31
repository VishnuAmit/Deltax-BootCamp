using IMDBApp.Domain.Interfaces;
using IMDBApp.Domain.Models;

namespace IMDBApp.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly List<Movie> _movies;

        public MovieRepository()
        {
            _movies = new List<Movie>();
        }

        public List<Movie> GetAllMovies() => _movies;

        public void AddMovie(Movie movie)
        {
            if (movie == null || string.IsNullOrEmpty(movie.Name) || movie.YearOfRelease <= 0 || string.IsNullOrEmpty(movie.Plot))
                throw new ArgumentNullException("Movie details are invalid.");

            _movies.Add(movie);
        }
    }
}
