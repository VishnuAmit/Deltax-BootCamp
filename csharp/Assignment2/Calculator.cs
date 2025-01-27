using System;

namespace CalculatorApp
{
    public class Calculator : ICalculator
    {
    
        private double _result;
        public double Result
        {
            get => _result; 
            set => _result = value; 
        }

        public virtual double Add(int firstNumber, int secondNumber)
        {
            Result = firstNumber + secondNumber;
            return Result;
        }

        public virtual double Add(int firstNumber, int secondNumber, int thirdNumber)
        {
            Result= firstNumber + secondNumber + thirdNumber;
            return Result;
        }

        public virtual double Add(double firstNumber, double secondNumber)
        {
            Result = firstNumber + secondNumber;
            return Result;
        }

    }
}
