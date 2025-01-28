
using IMDBApp.Domain.Interfaces;
using IMDBApp.Repositories;
using IMDBApp.Services;

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
            Console.WriteLine("  Press 4 to exit.");
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

    static void PauseAndReturnToMenu()
    {
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
    }
}
