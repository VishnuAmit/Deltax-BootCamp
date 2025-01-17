using System;
using System.Linq;

class Helper4
{
    public static void Question4()
    {
        Console.WriteLine("Enter a list of numbers separated by commas:");
        string input = Console.ReadLine();
        try
        {
            int[] numbers = input.Split(',').Select(int.Parse).ToArray();

            Array.Sort(numbers);
            Array.Reverse(numbers);

            Console.WriteLine("Numbers in descending order:");
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input :( ");
        }
    }
}
