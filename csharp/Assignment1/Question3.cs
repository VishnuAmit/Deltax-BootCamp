using System;

class Helper3
{
    public static void Question3()
    {
        while (true)
        {
            Console.WriteLine("Enter at least 5 comma-separated numbers: ");
            string input = Console.ReadLine();
            string[] inputarr = input.Split(',');

            if (inputarr.Length < 5)
            {
                Console.WriteLine("Invalid List :( ");
                continue;
            }

            try
            {
                int[] numbers = Array.ConvertAll(inputarr, s => int.Parse(s.Trim()));
                Array.Sort(numbers);

                Console.WriteLine("The 3 smallest numbers are: " + numbers[0] + ", " + numbers[1] + ", " + numbers[2]);
                break;
            }
            catch 
            {
                Console.WriteLine("Invalid input :( ");
            }
        }
    }
}
