using System;

namespace CalculatorApp
{
    public class AdvancedCalculator : Calculator
    {
        private double _result;

        public override double GetResult()
        {
            return base.GetResult() * 1_000_000; 
        }

        public double Power(int baseNumber, int exponent)
        {
            _result = Math.Pow(baseNumber, exponent); 
            SetResult(_result);
            return _result;
        }
    }
}
