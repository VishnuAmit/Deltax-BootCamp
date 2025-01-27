using System;
class Helper
{
    public static void Question1()
    {
        int sum = 0;

        while (true)
        {
            Console.WriteLine("Enter a number or type 'ok' to finish:");
            string input = Console.ReadLine();

            if (input.ToLower() == "ok")
                break;

            int number;
            if (int.TryParse(input, out number))
            {
                sum += number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        Console.WriteLine("The total sum is: " + sum);
    }
}
