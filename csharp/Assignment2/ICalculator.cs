namespace CalculatorApp
{
    public interface ICalculator
    {
        double Add(int a, int b);
        double Add(int a, int b, int c);
        double Add(double a, double b);
        double GetResult();
    }
}

