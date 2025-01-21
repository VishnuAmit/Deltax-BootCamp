using System;

namespace CalculatorApp
{
    public class Calculator : ICalculator
    {
        protected double _result;
        public virtual double add(int a, int b)
        {
            _result = a + b;
            return _result;
        }

        public virtual double add(int a, int b, int c)
        {
            _result = a + b + c;
            return _result;
        }

        public virtual double add(double a, double b)
        {
            _result = a + b;
            return _result;
        }

        public virtual double getresult()
        {
            return _result;
        }
    }
}

