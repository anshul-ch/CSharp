namespace CSharp.Practice.Word_Wand;

public class WordWand
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter the word to get it's output constraints:");
        string input = Console.ReadLine();
        if (input.All(c => char.IsLetter(c) || c == ' '))
        {
            WordReverse(input);
        }
        else
        {
            Console.WriteLine("Invalid Sentence");
        }
    }

    public static void WordReverse(string str)
    {
        string[] inputArray = str.Split(' ');
        if (inputArray.Length % 2 == 0)
        {
            ReverseArray(inputArray);
        }
        else
        {
            ReverseAtSamePosition(inputArray);
        }
    }
    public static void ReverseArray(string[] arr)
    {
        Array.Reverse(arr);
        Console.WriteLine("Reversed Sentence: " + string.Join(" ", arr));
    }

    public static void ReverseAtSamePosition(string[] arr)
    {
        string result = "";
        foreach (string str in arr)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            result += new string(charArray) + " ";
        }
        Console.WriteLine("Reversed Words at Same Position: " + result.Trim());
    }
}