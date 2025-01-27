using System;

namespace CalculatorApp
{
    public class Calculator : ICalculator
    {
        private double _result;

        public void SetResult(double result)
        {
            _result = result;
        }

        public virtual double Add(int firstNumber, int secondNumber)
        {
            _result = firstNumber + secondNumber;
            return _result;
        }

        public virtual double Add(int firstNumber, int secondNumber, int thirdNumber)
        {
            _result = firstNumber + secondNumber + thirdNumber;
            return _result;
        }

        public virtual double Add(double firstNumber, double secondNumber)
        {
            _result = firstNumber + secondNumber;
            return _result;
        }

        public virtual double GetResult()
        {
            return _result;
        }
    }
}
