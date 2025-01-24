﻿using System;

namespace CalculatorApp
{
    public class AdvancedCalculator : Calculator
    {
        public double Power(int baseNumber, int exponent)
        {
            Result = Math.Pow(baseNumber, exponent);
            return Result;
        }

        public override double GetResult()
        {
            return Result * 1_000_000;
        }
    }
}
