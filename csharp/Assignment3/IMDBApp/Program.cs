using System;
using MovieApp.Exceptions;
using MovieApp.Models;
using MovieApp.Services;

namespace MovieApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var movieService = new MovieService();

            while (true)
            {
                Console.WriteLine("\n1. List Movies");
                Console.WriteLine("2. Add Movie");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    ListMovies(movieService);
                }
                else if (choice == "2")
                {
                    AddMovie(movieService);
                }
                else if (choice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice, try again.");
                }
            }
        }

        static void ListMovies(MovieService movieService)
        {
            foreach (var movie in movieService.Movies)
            {
                Console.WriteLine($"\nMovie: {movie.Name} ({movie.YearOfRelease})");
                Console.WriteLine($"Plot: {movie.Plot}");
                Console.WriteLine("Actors: " + string.Join(", ", movie.Actors.Select(a => a.Name)));
                Console.WriteLine($"Producer: {movie.Producer.Name}");
            }
        }

        static void AddMovie(MovieService movieService)
        {
            try
            {
                Console.Write("Enter movie name: ");
                var name = Console.ReadLine();
                Console.Write("Enter year of release: ");
                var year = int.Parse(Console.ReadLine());
                Console.Write("Enter plot: ");
                var plot = Console.ReadLine();

                Console.WriteLine("Select actors:");
                for (int i = 0; i < movieService.Actors.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {movieService.Actors[i].Name}");
                }

                var selectedActors = new List<Actor>();
                var selectedActorIndexes = Console.ReadLine().Split(',').Select(int.Parse);
                foreach (var index in selectedActorIndexes)
                {
                    selectedActors.Add(movieService.Actors[index - 1]);
                }

                Console.WriteLine("Select producer:");
                for (int i = 0; i < movieService.Producers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {movieService.Producers[i].Name}");
                }

                var selectedProducer = movieService.Producers[int.Parse(Console.ReadLine()) - 1];

                movieService.AddMovie(name, year, plot, selectedActors, selectedProducer);
            }
            catch (MovieValidationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
