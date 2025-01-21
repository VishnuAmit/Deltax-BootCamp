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
            Console.WriteLine($"Add two integers: {calculator.add(10, 20)}");
            Console.WriteLine($"Add three integers: {calculator.add(5, 10, 15)}");
            Console.WriteLine($"Add two floating point numbers: {calculator.add(2.5, 3.5)}");
            Console.WriteLine($"Latest result: {calculator.getresult()}");

            // using advanced calculator
            AdvancedCalculator advCalculator = new AdvancedCalculator();

            Console.WriteLine("\nAdvancedCalculator Operations:");
            Console.WriteLine($"Add two integers: {advCalculator.add(8, 12)}");
            Console.WriteLine($"Add three integers: {advCalculator.add(7, 14, 21)}");
            Console.WriteLine($"Add two floating-point numbers: {advCalculator.add(1.1, 2.2)}");
            Console.WriteLine($"Power operation: {advCalculator.power(2, 10)}");
            Console.WriteLine($"Latest result in micros: {advCalculator.getresult()}");
        }
    }
}

