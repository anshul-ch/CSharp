namespace CSharp.Practice.FlipKey_Logic;

class Program
{
    public string CleanseAndInvert(string input)
    {
        if (string.IsNullOrEmpty(input) || input.Length < 6)
            return "";

        if (!input.All(char.IsLetter))
            return "";

        var filtered = input.ToLower().Where(c => ((int)c) % 2 != 0).Reverse().ToArray();

        for (int i = 0; i < filtered.Length; i++)
        {
            if (i % 2 == 0)
                filtered[i] = char.ToUpper(filtered[i]);
        }

        return new string(filtered);
    }

    static void Main()
    {
        Console.WriteLine("Enter the word");
        string input = Console.ReadLine();
        Program program = new Program();
        string result = program.CleanseAndInvert(input);

        if (result == "")
            Console.WriteLine("Invalid Input");
        else
            Console.WriteLine($"The generated key is - {result}");
    }
}