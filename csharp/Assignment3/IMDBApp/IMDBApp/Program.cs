using IMDBApp.Domain.Interfaces;
using IMDBApp.Repositories;
using IMDBApp.Services;
using IMDBApp.Domain.Models;

class Program
{
    static void Main()
    {
        Console.Title = "🎬 My Movie Club 🎥";
        IMovieRepository movieRepo = new MovieRepository();
        IActorRepository actorRepo = new ActorRepository();
        IProducerRepository producerRepo = new ProducerRepository();
        var movieService = new MovieService(movieRepo, actorRepo, producerRepo);

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*************************************************");
            Console.WriteLine("            WELCOME TO MY MOVIE CLUB            ");
            Console.WriteLine("*************************************************");
            Console.ResetColor();

            Console.WriteLine("\nPlease select an option:\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  Press 1 to list movies available.");
            Console.WriteLine("  Press 2 to add the movies you desire.");
            Console.WriteLine("  Press 3 for other options.");
            Console.WriteLine("  Press 4 to add a new actor.");
            Console.WriteLine("  Press 5 to add a new producer.");
            Console.WriteLine("  Press 6 to delete a movie.");
            Console.WriteLine("  Press 7 to exit.");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nYour choice: ");
            Console.ResetColor();

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("********* LIST OF MOVIES *********");
                    Console.ResetColor();
                    movieService.ListMovies();
                    PauseAndReturnToMenu();
                    break;

                case "2":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("********* ADD A NEW MOVIE *********");
                    Console.ResetColor();
                    movieService.AddMovie();
                    PauseAndReturnToMenu();
                    break;

                case "3":
                    ShowLinqOptions(movieService);
                    break;

                case "4":
                    AddActor(actorRepo);
                    PauseAndReturnToMenu();
                    break;

                case "5":
                    AddProducer(producerRepo);
                    PauseAndReturnToMenu();
                    break;

                case "6":
                    DeleteMovie(movieRepo);
                    PauseAndReturnToMenu();
                    break;

                case "7":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Thank you for visiting My Movie Club! Goodbye!");
                    Console.ResetColor();
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.ResetColor();
                    PauseAndReturnToMenu();
                    break;
            }
        }
    }

    static void ShowLinqOptions(MovieService movieService)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("********* LINQ QUERIES *********");
        Console.ResetColor();

        Console.WriteLine("Please select an option for LINQ queries:\n");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Press 1:  Movies released after 2010.");
        Console.WriteLine("Press 2:  Movies produced by 'James Cameron'.");
        Console.WriteLine("Press 3:  Movies (Name and Year of Release).");
        Console.WriteLine("Press 4:  First movie containing 'Avatar'.");
        Console.WriteLine("Press 5:  Movies with actor 'Will Smith'.");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nYour choice: ");
        Console.ResetColor();

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                movieService.GetMoviesReleasedAfter2010();
                break;
            case "2":
                movieService.GetMoviesByProducer("James Cameron");
                break;
            case "3":
                movieService.GetMoviesNameAndYear();
                break;
            case "4":
                movieService.GetFirstMovieContainingAvatar();
                break;
            case "5":
                movieService.GetMoviesWithWillSmith();
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice. Please try again.");
                Console.ResetColor();
                break;
        }

        PauseAndReturnToMenu();
    }

    static void AddActor(IActorRepository actorRepo)
    {
 
        Console.WriteLine("********* LIST OF ACTORS *********");
        var actors = actorRepo.GetAllActors();
        if (actors.Count == 0)
        {
            Console.WriteLine("No actors found.");
        }
        else
        {
            for (int i = 0; i < actors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {actors[i].Name}");
            }
        }
        Console.Write("Enter Actor Name: ");
        var name = Console.ReadLine();

        var existingActor = actors.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (existingActor != null)
        {
            Console.WriteLine("This actor already exists in the list.");
        }
        else
        {
            Console.Write("Enter Actor Date of Birth (yyyy-MM-dd) : ");
            var dob = Console.ReadLine();

            var actor = new Actor { Name = name };
            actorRepo.AddActor(actor);
            Console.WriteLine("Actor added successfully.");
        }
    }


    static void AddProducer(IProducerRepository producerRepo)
    {
        Console.WriteLine("********* LIST OF PRODUCERS *********");
        var producers = producerRepo.GetAllProducers();
        if (producers.Count == 0)
        {
            Console.WriteLine("No producers found.");
        }
        else
        {
            for (int i = 0; i < producers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {producers[i].Name}");
            }
        }

        Console.Write("Enter Producer Name: ");
        var name = Console.ReadLine();

        var existingProducer = producers.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (existingProducer != null)
        {
            Console.WriteLine("This producer already exists in the list.");
        }
        else
        {
            Console.Write("Enter Producer Date of Birth (yyyy-MM-dd) : ");
            var dob = Console.ReadLine();

            var producer = new Producer { Name = name };
            producerRepo.AddProducer(producer);
            Console.WriteLine("Producer added successfully.");
        }
    }


    static void DeleteMovie(IMovieRepository movieRepo)
    {
        Console.WriteLine("Select a movie to delete:");
        var movies = movieRepo.GetAllMovies();
        for (int i = 0; i < movies.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {movies[i].Name}");
        }

        var movieIndex = int.Parse(Console.ReadLine()) - 1;
        var movieName = movies[movieIndex].Name;
        movieRepo.DeleteMovie(movieName);

        Console.WriteLine($"Movie '{movieName}' deleted successfully.");
    }

    static void PauseAndReturnToMenu()
    {
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
    }
}
