using System;
class Helper2
{
    public static void Question2()
    {
        Console.WriteLine("Enter a series of numbers separated by commas: ");
        string input = Console.ReadLine();
        string[] numbers = input.Split(',');

        try
        {
            int max = int.MinValue;
            foreach (string num in numbers)
            {
                int parse_number = int.Parse(num.Trim());
                max = Math.Max(max, parse_number); 
            }

            Console.WriteLine("The maximum number is: " + max);
        }
        catch
        {
            Console.WriteLine("Invalid input :( ");
        }
    }
}
