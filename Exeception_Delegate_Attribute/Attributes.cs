namespace CSharp._22_JAN;

public class Calculator
{
    [Obsolete("use the Add method instead of OldAdd")]   // This attribute marks the OldAdd method as obsolete
    public int OldAdd(int a, int b)
    {
        return a + b;
    }
    public int Add(int a, int b)
    {
        return a + b;
    }
}

public class Attributes
{
    public static void Main(String[] args)
    {
        Calculator calc = new Calculator();
        Console.WriteLine(calc.OldAdd(3, 5));
        Console.WriteLine(calc.Add(4, 6));
    }
}