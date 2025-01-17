using System;
using System.Linq;

class Helper2
{
    public static void Question2()
    {
        Console.WriteLine("Enter a series of numbers separated by commas: ");
        string input = Console.ReadLine();
        string[] numbers = input.Split(',');

        try
        {
            int maximum_number = numbers.Select(num => int.Parse(num.Trim())).Max();
            Console.WriteLine("The maximum number is: " + maximum_number);
        }
        catch
        {
            Console.WriteLine("Invalid input :( ");
        }
    }
}
