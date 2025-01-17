using System;
using System.Linq;

class Helper3
{
    public static void Question3()
    {
        while (true)
        {
            Console.WriteLine("Enter at least 5 comma-separated numbers: ");
            string input = Console.ReadLine();
            int[] numbers = input.Split(',').Select(int.Parse).ToArray();

            if (numbers.Length < 5)
            {
                Console.WriteLine("Invalid List :( ");
                continue;
            }

            var smallest = numbers.OrderBy(n => n).Take(3);
            Console.WriteLine("The 3 smallest numbers are: " + string.Join(", ", smallest));
            break;
        }
    }
}
