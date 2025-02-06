using IMDBApp.Domain.Interfaces;
using IMDBApp.Domain.Models;

namespace IMDBApp.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly List<Movie> _movies;

        // Constructor added
        public MovieRepository(List<Movie> initialMovies = null)
        {
            _movies = initialMovies ?? new List<Movie>
            {
                new Movie
                {
                    Name = "Titanic",
                    YearOfRelease = 1997,
                    Plot = "Epic romance on a ill-fated R.M.S. Titanic.",
                    Actors = new List<Actor> { new Actor { Name = "Leonardo DiCaprio" }, new Actor { Name = "Kate Winslet" } },
                    Producer = new Producer { Name = "James Cameron" }
                },
                new Movie
                {
                    Name = "Triangle",
                    YearOfRelease = 2009,
                    Plot = "A woman becomes trapped in a time loop.",
                    Actors = new List<Actor> { new Actor { Name = "Melissa George" } },
                    Producer = new Producer { Name = "Christopher Smith" }
                }
            };
        }

        public List<Movie> GetAllMovies() => _movies;

        public void AddMovie(Movie movie)
        {
            if (movie == null || string.IsNullOrEmpty(movie.Name) || movie.YearOfRelease <= 0 || string.IsNullOrEmpty(movie.Plot))
                throw new ArgumentNullException("Movie details are invalid.");

            _movies.Add(movie);
        }

        public void DeleteMovie(string movieName)
        {
            var movie = _movies.FirstOrDefault(m => m.Name.Equals(movieName, StringComparison.OrdinalIgnoreCase));
            if (movie != null)
            {
                _movies.Remove(movie);
            }
        }
    }
}
