using System;
using System.Text.RegularExpressions;
public class Program
{
    public static void Main(String[] args)
    {
        // Scientific-Conversion.
    //     string input = "3E+3";
    //     string[] array = input.Split("E");
    //     int number  = Convert.ToInt32(array[0]);
    //     int power =  Convert.ToInt32(array[1]);
    //     double result  = Math.Pow(10, power);
    //     int final  = Convert.ToInt32(result*number);
    //    Console.WriteLine(final);

        // to remove the curreny formatting
    //Console.WriteLine(Regex.Replace("$1,500.75", "[^0-9.]", ""));
        
    // check numebers and sum them
    // string input = "8 16 32 bits";
    // string[] array = input.Split(" ");
    // int sum =0;
    // foreach(var number in array)
    //     {
    //         if(int.TryParse(number, out int result))
    //         {
    //             sum += result;
    //         }
    //     }
    //     Console.WriteLine(sum);

        // Extract both numbers and add them together.
        // string input = "2,000 apples and 3,500 oranges";
        // string filtered = input.Replace(",","");
        // string[] array = filtered.Split(" ");
        // int total = 0;
        // foreach (var item in array)
        // {
        //     if(int.TryParse(item, out int result))
        //     {
        //         total += result;
        //     }
        // }
        // Console.WriteLine(total);

        // string input = "Hack10101Rank1rank";
        // string pattern = @"^[a-zA-Z]+\d+[a-zA-Z]+\d+[a-zA-Z]+";
        // Console.WriteLine(Regex.IsMatch(input, pattern)? "true":"false");

    }
    
}