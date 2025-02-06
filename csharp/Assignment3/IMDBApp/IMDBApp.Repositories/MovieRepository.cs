using IMDBApp.Domain.Interfaces;
using IMDBApp.Domain.Models;

namespace IMDBApp.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private List<Movie> _movies = new();

        public List<Movie> GetAllMovies() => _movies;

        public void AddMovie(Movie movie)
        {
            if (movie == null || string.IsNullOrEmpty(movie.Name) || movie.YearOfRelease <= 0 || string.IsNullOrEmpty(movie.Plot))
                throw new ArgumentNullException("Movie details are invalid.");

            _movies.Add(movie);
        }
    }
}
