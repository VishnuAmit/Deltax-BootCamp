using System;

namespace CalculatorApp
{
    public class AdvancedCalculator : Calculator
    {
        public double power(int baseNum, int exponent)
        {
            _result = Math.Pow(baseNum, exponent);
            return _result;
        }

        public override double getresult()
        {
            return _result * 1_000_000;
        }
    }
}
