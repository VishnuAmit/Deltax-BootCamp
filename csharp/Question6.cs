using System;
using System.IO;

class Helper6
{
    public static void Question6()
    {
    
        Console.WriteLine("Enter your favorite movies (one per line)...Type 'done' to finish!");

        var movies = new System.Collections.Generic.List<string>();
        string movie;

        while (true)
        {
            movie = Console.ReadLine();
            if (movie.ToLower() == "done")
                break;
            movies.Add(movie);
        }

  
        string filepath = "E://DeltaX//bootcamp//csharp//FavoriteMovies.txt";
        File.WriteAllLines(filepath, movies);

        Console.WriteLine("\nMovies in UPPERCASE:");

        string[] movieLines = File.ReadAllLines(filepath);
        foreach (var line in movieLines)
        {
            Console.WriteLine(line.ToUpper());
        }

    }
}
