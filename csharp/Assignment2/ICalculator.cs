namespace CalculatorApp
{
    public interface ICalculator
    {
        double Result { get; }
        double Add(int a, int b);
        double Add(int a, int b, int c);
        double Add(double a, double b);
  
    }
}

