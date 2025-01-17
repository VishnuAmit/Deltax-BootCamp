using System;

class Helper2
{
    public static void Question2()
    {
        Console.WriteLine("Enter a series of numbers separated by commas: ");
        string input = Console.ReadLine();
        string[] numbers = input.Split(',');

        int maximum_number = int.MinValue;

        foreach (string num in numbers)
        {
            if (int.TryParse(num.Trim(), out int current_number))
            {
                if (current_number > maximum_number)
                {
                    maximum_number = current_number;
                }
            }
            else
            {
                Console.WriteLine("Invalid input :( ");
                return;
            }
        }

        Console.WriteLine("The maximum number is: " + maximum_number);
    }
}
