using System;

public class Program
{
    public static void Main(String[] args)
    {
        string input = "3E+3";
        string[] array = input.Split("E");
        int number  = Convert.ToInt32(array[0]);
        int power =  Convert.ToInt32(array[1]);
        double result  = Math.Pow(10, power);
        int final  = Convert.ToInt32(result*number);
       Console.WriteLine(final);
    }
}