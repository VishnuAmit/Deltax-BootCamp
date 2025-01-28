using IMDBApp.Domain.Models;

namespace IMDBApp.Domain.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        void AddMovie(Movie movie);
    }
}