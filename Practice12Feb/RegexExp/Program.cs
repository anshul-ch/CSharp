using System;
using System.Text.RegularExpressions;
class Program
{
    public static void Main(String[] args){ 
    string? input = Console.ReadLine();
    // only 10 number only
    //string pattern = "^[1-9][0-9]{9}$";

    // only lowercase
    //string pattern = "^[a-z]+$";

    // email     
    //string pattern = @"^[0-9A-Za-z_.]+@[a-z]+[.][a-z]{2,4}$";

     // Match a hex color code: # followed by either 3 or 6 hexadecimal digits (case-insensitive).
    // string pattern = "^#([A-F0-9]{3}) | #([A-F0-9]{6})$"; 

    // Date format YYYY-MM-DD
    //string pattern = "^([1-9][0-9]{3}-(0[1-9]|1[0-2])-(0[1-9]|1[0-9]|2[0-9]|3[0-1]))$";

    // Ip address
    //string pattern = "^([1-9]?[0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])[.]([1-9]?[0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])[.]([1-9]?[0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])[.]([1-9]?[0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])$";


    // clock 24-H
    //string pattern = "^([0-1][0-9]|2[0-3])[:]([0-5][0-9])$";

    // Match a password that is at least 8 characters and includes at least one uppercase, one lowercase, and one digit.
    //string pattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{8,}$";

    
    // bool result = Regex.IsMatch(input, pattern);
    // Console.WriteLine(result?"true":"false");

}
}