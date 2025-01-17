using System;

class Helper5
{
    public static void Question5()
    {
        Console.WriteLine("Enter your DOB (yyyy-MM-dd): ");
        string input = Console.ReadLine();

        if (DateTime.TryParse(input, out DateTime birthdate))
        {
            DateTime today = DateTime.Now;

            int years = today.Year - birthdate.Year;
            int months = today.Month - birthdate.Month;
            int days = today.Day - birthdate.Day;


            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(today.Year, today.Month == 1 ? 12 : today.Month - 1);
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            Console.WriteLine($"You are {years} years, {months} months, and {days} days old.");
        }
        else
        {
            Console.WriteLine("Invalid date format :( " );
        }
    }
}
