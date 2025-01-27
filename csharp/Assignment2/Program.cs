using System;
namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // using basic calculator
            ICalculator calculator = new Calculator();

            Console.WriteLine("Calculator Operations:");
            Console.WriteLine($"Add two integers: {calculator.Add(10, 20)}");
            Console.WriteLine($"Add three integers: {calculator.Add(5, 10, 15)}");
            Console.WriteLine($"Add two floating point numbers: {calculator.Add(2.5, 3.5)}");
            Console.WriteLine($"Latest result: {calculator.GetResult()}");

            // using advanced calculator
            AdvancedCalculator advCalculator = new AdvancedCalculator();

            Console.WriteLine("\nAdvancedCalculator Operations:");
            Console.WriteLine($"Add two integers: {advCalculator.Add(8, 12)}");
            Console.WriteLine($"Add three integers: {advCalculator.Add(7, 14, 21)}");
            Console.WriteLine($"Add two floating-point numbers: {advCalculator.Add(1.1, 2.2)}");
            Console.WriteLine($"Latest result in micros: {advCalculator.GetResult()}");

        }
    }
}

