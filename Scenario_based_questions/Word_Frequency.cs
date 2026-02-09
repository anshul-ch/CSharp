using System;
using System.Collections.Generic;

namespace CSharp.Scenario_based_questions
{
    class Frequency
    {
        public string sentence { get; set; }

        public Frequency(string input)
        {
            sentence = input;
        }

        public Dictionary<string, int> CalculateFrequency()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            if (string.IsNullOrWhiteSpace(sentence))
            {
                return result;
            }

            string[] words = sentence.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (result.ContainsKey(word))
                {
                    result[word]++;
                }
                else
                {
                    result[word] = 1;
                }
            }

            return result;
        }
    }

    public class Word_Frequency
    {
        static void Main(string[] args)
        {
            Frequency freq = new Frequency("Dot net dot NET core Core");

            Dictionary<string, int> output = freq.CalculateFrequency();

            foreach (var item in output)
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }
        }
    }
}
