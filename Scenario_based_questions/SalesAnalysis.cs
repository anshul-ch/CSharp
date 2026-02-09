using System;

class SalesAnalysis
{
    static void Main()
    {
        int[] sales = new int[7];

        for (int i = 0; i < 7; i++)
        {
            sales[i] = Convert.ToInt32(Console.ReadLine());
        }

        int max = sales[0];
        int min = sales[0];
        int sum = 0;

        for (int i = 0; i < sales.Length; i++)
        {
            sum += sales[i];

            if (sales[i] > max)
            {
                max = sales[i];
            }

            if (sales[i] < min)
            {
                min = sales[i];
            }
        }

        double avg = (double)sum / sales.Length;

        Console.WriteLine("Highest Sale: " + max);
        Console.WriteLine("Lowest Sale: " + min);
        Console.WriteLine("Average Sale: " + avg);
    }
}
