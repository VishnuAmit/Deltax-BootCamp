using System;
using System.Collections.Generic;
using System.Linq;
using MovieApp.Exceptions;
using MovieApp.Models;

namespace MovieApp.Services
{
    public class MovieService
    {
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public List<Actor> Actors { get; set; } = new List<Actor>();
        public List<Producer> Producers { get; set; } = new List<Producer>();

        public MovieService()
        {
            // Sample data
            Actors.Add(new Actor("Will Smith"));
            Actors.Add(new Actor("Tom Hanks"));
            Actors.Add(new Actor("Scarlett Johansson"));

            Producers.Add(new Producer("James Cameron"));
            Producers.Add(new Producer("Christopher Nolan"));

            Movies.Add(new Movie("Avatar", 2009, "BLue man."));
            Movies[0].Actors.Add(Actors[0]);
            Movies[0].Producer = Producers[0];
        }

        public void AddMovie(string name, int yearOfRelease, string plot, List<Actor> selectedActors, Producer selectedProducer)
        {
            if (string.IsNullOrWhiteSpace(name) || yearOfRelease <= 0 || string.IsNullOrWhiteSpace(plot))
            {
                throw new MovieValidationException("Invalid movie input data.");
            }

            var newMovie = new Movie(name, yearOfRelease, plot)
            {
                Actors = selectedActors,
                Producer = selectedProducer
            };

            Movies.Add(newMovie);
            Console.WriteLine("Movie added successfully!");
        }

        public List<Movie> GetMoviesAfterYear(int year)
        {
            return Movies.Where(m => m.YearOfRelease > year).ToList();
        }

        public List<string> GetMoviesByProducer(string producerName)
        {
            return Movies.Where(m => m.Producer.Name == producerName).Select(m => m.Name).ToList();
        }

        public List<(string, int)> GetAllMovies()
        {
            return Movies.Select(m => (m.Name, m.YearOfRelease)).ToList();
        }

        public Movie GetFirstMovieByName(string name)
        {
            return Movies.FirstOrDefault(m => m.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<Movie> GetMoviesByActor(string actorName)
        {
            return Movies.Where(m => m.Actors.Any(a => a.Name == actorName)).ToList();
        }
    }
}
