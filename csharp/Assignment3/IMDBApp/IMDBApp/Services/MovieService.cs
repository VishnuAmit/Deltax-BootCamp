using IMDBApp.Domain.Interfaces;
using IMDBApp.Domain.Models;
using IMDBApp.Domain.Exceptions;
using System.Linq;

namespace IMDBApp.Services
{
    public class MovieService
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IActorRepository _actorRepo;
        private readonly IProducerRepository _producerRepo;

        public MovieService(IMovieRepository movieRepo, IActorRepository actorRepo, IProducerRepository producerRepo)
        {
            _movieRepo = movieRepo;
            _actorRepo = actorRepo;
            _producerRepo = producerRepo;
        }

        public void ListMovies()
        {
            var movies = _movieRepo.GetAllMovies();

            if (!movies.Any())
            {
                Console.WriteLine("No movies available in the repository.");
                return;
            }

            Console.WriteLine("Movie List");
            Console.WriteLine("==============================================");

            foreach (var movie in movies)
            {
                Console.WriteLine($"Name       : {movie.Name}");
                Console.WriteLine($"Year       : {movie.YearOfRelease}");
                Console.WriteLine($"Plot       : {movie.Plot}");
                Console.WriteLine($"Actors     : {string.Join(", ", movie.Actors.Select(a => a.Name))}");
                Console.WriteLine($"Producer   : {movie.Producer.Name}");
                Console.WriteLine("----------------------------------------------");
            }

            Console.WriteLine("==============================================");
        }

        public void AddMovie()
        {
            // Movie Name Validation
            Console.Write("Enter Movie Name: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
                throw new ValidationException("Movie name cannot be empty.");

            // Year of Release Validation
            Console.Write("Enter Year of Release: ");
            if (!int.TryParse(Console.ReadLine(), out var year) || year < 1896 || year > DateTime.Now.Year)
                throw new ValidationException("Invalid year entered. The movie year must be between 1896 and the current year.");

            // Plot Validation
            Console.Write("Enter Plot: ");
            var plot = Console.ReadLine();
            if (string.IsNullOrEmpty(plot))
                throw new ValidationException("Plot cannot be empty.");

            // Actors Selection
            var actors = _actorRepo.GetAllActors();
            if (actors.Count == 0)
                throw new ValidationException("No actors available. Please add actors first.");

            Console.WriteLine("Select Actors (comma-separated indices):");
            for (var i = 0; i < actors.Count; i++)
                Console.WriteLine($"{i + 1}. {actors[i].Name}");

            var actorIndices = Console.ReadLine()?.Split(',').Select(int.Parse).ToList();
            if (actorIndices == null || actorIndices.Any(index => index < 1 || index > actors.Count))
                throw new ValidationException("Invalid actor selection.");

            var selectedActors = actorIndices.Select(index => actors[index - 1]).ToList();

            // Producers Selection
            var producers = _producerRepo.GetAllProducers();
            if (producers.Count == 0)
                throw new ValidationException("No producers available. Please add producers first.");

            Console.WriteLine("Select a Producer (index):");
            for (var i = 0; i < producers.Count; i++)
                Console.WriteLine($"{i + 1}. {producers[i].Name}");

            if (!int.TryParse(Console.ReadLine(), out var producerIndex) || producerIndex < 1 || producerIndex > producers.Count)
                throw new ValidationException("Invalid producer selection.");

            var selectedProducer = producers[producerIndex - 1];

            var movie = new Movie { Name = name, YearOfRelease = year, Plot = plot, Actors = selectedActors, Producer = selectedProducer };

            _movieRepo.AddMovie(movie);
            Console.WriteLine("Movie added successfully!");
        }

        // LINQ Queries as per assignment 3
        public void GetMoviesReleasedAfter2010()
        {
            var moviesAfter2010 = _movieRepo.GetAllMovies()
                                             .Where(m => m.YearOfRelease > 2010)
                                             .ToList();

            if (moviesAfter2010.Any())
            {
                Console.WriteLine("Movies released after 2010:");
                foreach (var movie in moviesAfter2010)
                {
                    Console.WriteLine($"{movie.Name} ({movie.YearOfRelease})");
                }
            }
            else
            {
                Console.WriteLine("No movies found after 2010.");
            }
        }

   
        public void GetMoviesByProducer(string producerName)
        {
            var jamesCameronMovies = _movieRepo.GetAllMovies()
                                              .Where(m => m.Producer.Name.Equals(producerName, StringComparison.OrdinalIgnoreCase))
                                              .Select(m => m.Name)
                                              .ToList();

            if (jamesCameronMovies.Any())
            {
                Console.WriteLine($"Movies produced by {producerName}:");
                foreach (var movie in jamesCameronMovies)
                {
                    Console.WriteLine(movie);
                }
            }
            else
            {
                Console.WriteLine($"No movies found for producer {producerName}.");
            }
        }

        public void GetMoviesNameAndYear()
        {
            var moviesNameAndYear = _movieRepo.GetAllMovies()
                                              .Select(m => new { m.Name, m.YearOfRelease })
                                              .ToList();

            Console.WriteLine("Movies (Name and Year of Release):");
            foreach (var movie in moviesNameAndYear)
            {
                Console.WriteLine($"{movie.Name} ({movie.YearOfRelease})");
            }
        }

        public void GetFirstMovieContainingAvatar()
        {
            var firstAvatarMovie = _movieRepo.GetAllMovies()
                                              .FirstOrDefault(m => m.Name.Contains("Avatar", StringComparison.OrdinalIgnoreCase));

            if (firstAvatarMovie != null)
            {
                Console.WriteLine($"First movie containing 'Avatar': {firstAvatarMovie.Name} ({firstAvatarMovie.YearOfRelease})");
            }
            else
            {
                Console.WriteLine("No movie found containing 'Avatar'.");
            }
        }

        public void GetMoviesWithWillSmith()
        {
            var willSmithMovies = _movieRepo.GetAllMovies()
                                            .Where(m => m.Actors.Any(a => a.Name.Equals("Will Smith", StringComparison.OrdinalIgnoreCase)))
                                            .ToList();

            if (willSmithMovies.Any())
            {
                Console.WriteLine("Movies with Will Smith:");
                foreach (var movie in willSmithMovies)
                {
                    Console.WriteLine(movie.Name);
                }
            }
            else
            {
                Console.WriteLine("Will Smith has not acted in any movies.");
            }
        }
    }
}
