using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharp.Day2_Iteration_and_Conditional_Statements
{
    /// <summary>
    /// This program let two users play the game of Rock, paper, Scissors on chance based.
    /// </summary>
    class Rock_Paper_Scissors
    {
        static void Main(string[] args)
        {
            // Input from Player 1
            Console.WriteLine("Player 1 - Enter Rock, Paper or Scissors: ");
            string p1 = Console.ReadLine().ToLower();

            // Input from Player 2
            Console.WriteLine("Player 2 - Enter Rock, Paper or Scissors: ");
            string p2 = Console.ReadLine().ToLower();

            // Checking if both players entered the same choice
            if (p1 == p2)
            {
                Console.WriteLine("Game Draw!");
            }
            else
            {
                // Nested conditions for Player 1 winning cases
                if ((p1 == "rock" && p2 == "scissors") ||
                    (p1 == "scissors" && p2 == "paper") ||
                    (p1 == "paper" && p2 == "rock"))
                {
                    Console.WriteLine("Player 1 Wins!");
                }
                // If Player 1 does not win, Player 2 wins
                else
                {
                    Console.WriteLine("Player 2 Wins!");
                }
            }
        }
    }
}
