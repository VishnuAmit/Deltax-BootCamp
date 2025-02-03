using IMDBApp.Domain.Interfaces;
using IMDBApp.Repositories;
using IMDBApp.Services;
using IMDBApp.Domain.Models;
using IMDBApp.Domain.Exceptions;

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
                    try
                    {
                        Console.Write("Enter Movie Name: ");
                        string name = Console.ReadLine() ?? string.Empty;
                        Console.Write("Enter Year of Release: ");
                        string yearInput = Console.ReadLine() ?? string.Empty;
                        if (!int.TryParse(yearInput, out int year))
                        {
                            throw new ValidationException("Invalid year format.");
                        }
                        Console.Write("Enter Plot: ");
                        string plot = Console.ReadLine() ?? string.Empty;
                        var actors = actorRepo.GetAllActors();
                        if (!actors.Any())
                        {
                            throw new ValidationException("No actors available. Please add actors first.");
                        }
                        Console.WriteLine("\nAvailable Actors:");
                        for (int i = 0; i < actors.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {actors[i].Name}");
                        }
                        Console.WriteLine("\nSelect Actors (comma-separated indices):");
                        string actorInput = Console.ReadLine() ?? string.Empty;
                        var selectedActorIndices = actorInput.Split(',')
                            .Select(x => int.TryParse(x.Trim(), out int index) ? index : 0)
                            .Where(x => x > 0 && x <= actors.Count)
                            .ToList();

                        var producers = producerRepo.GetAllProducers();
                        if (!producers.Any())
                        {
                            throw new ValidationException("No producers available. Please add producers first.");
                        }
                        Console.WriteLine("\nAvailable Producers:");
                        for (int i = 0; i < producers.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {producers[i].Name}");
                        }
                        Console.WriteLine("\nSelect Producer (index):");
                        string producerInput = Console.ReadLine() ?? string.Empty;
                        if (!int.TryParse(producerInput, out int producerIndex))
                        {
                            throw new ValidationException("Invalid producer selection.");
                        }
                        movieService.AddMovie(
                            name,
                            year,
                            plot,
                            selectedActorIndices,
                            producerIndex
                        );
                        Console.WriteLine("\nMovie added successfully!");
                    }
                    catch (ValidationException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nError: {ex.Message}");
                        Console.ResetColor();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nAn unexpected error occurred: {ex.Message}");
                        Console.ResetColor();
                    }
                    PauseAndReturnToMenu();
                    break;

                case "3":
                    ShowLinqOptions(movieService);
                    break;

                case "4":
                    Console.WriteLine("********* LIST OF ACTORS *********");

                    var actorList = movieService.GetAllActors(); 

                    if (actorList.Any())
                    {
                        for (int i = 0; i < actorList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {actorList[i].Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No actors found.");
                    }
                    break;

                case "5":
                    Console.WriteLine("Enter the name of the producer to add:");
                    var producerName = Console.ReadLine();

                    if (string.IsNullOrEmpty(producerName))
                    {
                        Console.WriteLine("Producer name cannot be empty.");
                        return;
                    }

                    movieService.AddProducer(producerName);
                    PauseAndReturnToMenu();
                    break;

                case "6":
                    Console.WriteLine("Select a movie to delete:");
                    var movies = movieRepo.GetAllMovies();

                    if (!movies.Any())
                    {
                        Console.WriteLine("No movies available in the repository.");
                        return;
                    }

                    for (int i = 0; i < movies.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {movies[i].Name}");
                    }

                    var movieIndex = int.Parse(Console.ReadLine()) - 1;
                    if (movieIndex < 0 || movieIndex >= movies.Count)
                    {
                        Console.WriteLine("Invalid selection.");
                        return;
                    }

                    var movieName = movies[movieIndex].Name;

                    movieService.DeleteMovie(movieName);

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

    static void PauseAndReturnToMenu()
    {
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
    }
}
