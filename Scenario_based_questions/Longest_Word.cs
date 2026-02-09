using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharp.Scenario_based_questions
{
    class Word
    {
        public string Paragraph { get; set; }
        public Word(string para)
        {
            Paragraph = para;
        }
        public void CalculateLongestWord()
        {
            if (string.IsNullOrEmpty(Paragraph))
            {
                Console.WriteLine(Paragraph);
            }
            
            string[] data = Regex.Matches(Paragraph, @"[A-Za-z]+")
                                .Select(m => m.Value)
                                .ToArray();

            Array.Sort(data, (a, b) => b.Length.CompareTo(a.Length));

            Console.WriteLine(data[0]);
        }
    }
    public class Longest_Word
    {
        public static void Main(String[] args) {
            Word word = new Word("Elephant, hello, ABCDEFDSVASD:: HI AAAAAAAAAAAAAAAA");
            word.CalculateLongestWord();
    }
    }
}
