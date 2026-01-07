using CSharp.Day3_OOPS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Day2_Iteration_and_Conditional_Statements
{
    class Competition
    {
        public string CompetitionName;
        public int Score;
        public Employee Emp;   // Association (Employee reference)

        // Constructor
        public Competition(string compName, int score, Employee emp)
        {
            CompetitionName = compName;
            Score = score;
            Emp = emp;
        }
    }
}
