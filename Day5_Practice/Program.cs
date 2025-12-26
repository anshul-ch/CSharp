using System;
using System.Collections.Generic;
using System.Text;

using System;
using System.Collections.Generic;
using System.Linq;


namespace CSharp.Day5_Practice
{
    /// <summary>
    /// THis code implements a Employee Pay management based on employement type and oter factors.
    /// </summary>
    public abstract class EmployeeRecord
    {
        public string EmployeeName { get; set; }
        public double[] WeeklyHours { get; set; }

        public abstract double GetMonthlyPay();
    }


    public class FullTimeEmployee : EmployeeRecord
    {
        public double HourlyRate { get; set; }
        public double MonthlyBonus { get; set; }

        public override double GetMonthlyPay()
        {
            return (WeeklyHours.Sum() * HourlyRate) + MonthlyBonus;
        }
    }

   public class ContractEmployee : EmployeeRecord
    {
        public double HourlyRate { get; set; }
        public override double GetMonthlyPay()
        {
            return (WeeklyHours.Sum() * HourlyRate);
        }
    }

    /// <summary>
    /// Main program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Contains all the emplyee record in list format
        /// </summary>
        public static List<EmployeeRecord> PayrollBoard = new List<EmployeeRecord>();

        public void RegisterEmployee(EmployeeRecord record)
        {
            PayrollBoard.Add(record);
        }
        /// <summary>
        /// Contains the weekly hours of employee mapped with Employee record
        /// </summary>
        /// <param name="records"></param>
        /// <param name="hoursThreshold"></param>
        /// <returns></returns>
        public Dictionary<string, int> GetOvertimeWeekCounts(List<EmployeeRecord> records, double hoursThreshold)
        {
            Dictionary<string, int> overtimeCounts = new Dictionary<string, int>();

            foreach (var emp in records)
            {
                int qualifyingWeeks = 0;
                foreach (var hours in emp.WeeklyHours)
                {
                    if (hours >= hoursThreshold)
                    {
                        qualifyingWeeks++;
                    }
                }

                if (qualifyingWeeks > 0)
                {
                    overtimeCounts.Add(emp.EmployeeName, qualifyingWeeks);
                }
            }

            return overtimeCounts;
        }

        public double CalculateAverageMonthlyPay()
        {
            if (PayrollBoard.Count == 0)
            {
                return 0;
            }

            double totalPay = 0;
            foreach (var emp in PayrollBoard)
            {
                totalPay += emp.GetMonthlyPay();
            }

            return totalPay / PayrollBoard.Count;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("1. Register Employee");
                Console.WriteLine("2. Show Overtime Summary");
                Console.WriteLine("3. Calculate Average Monthly Pay");
                Console.WriteLine("4. Exit");
                Console.Write("\nEnter your choice:\n");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Select Employee Type (1-Full Time, 2-Contract):");
                        int type = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Employee Name:");
                        string name = Console.ReadLine();

                        double[] hours = new double[4];
                        double rate = 0;
                        double bonus = 0;

                        if (type == 1)
                        {
                            Console.WriteLine("Enter Hourly Rate:");
                            rate = double.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Monthly Bonus:");
                            bonus = double.Parse(Console.ReadLine());
                        }
                        else if (type == 2)
                        {
                            Console.WriteLine("Enter Hourly Rate:");
                            rate = double.Parse(Console.ReadLine());
                        }

                        Console.WriteLine("Enter weekly hours (Week 1 to 4):");
                        for (int i = 0; i < 4; i++)
                        {
                            hours[i] = double.Parse(Console.ReadLine());
                        }

                        if (type == 1)
                        {
                            FullTimeEmployee ft = new FullTimeEmployee();
                            ft.EmployeeName = name;
                            ft.WeeklyHours = hours;
                            ft.HourlyRate = rate;
                            ft.MonthlyBonus = bonus;
                            program.RegisterEmployee(ft);
                        }
                        else if (type == 2)
                        {
                            ContractEmployee ct = new ContractEmployee();
                            ct.EmployeeName = name;
                            ct.WeeklyHours = hours;
                            ct.HourlyRate = rate;
                            program.RegisterEmployee(ct);
                        }

                        Console.WriteLine("Employee registered successfully");
                        Console.WriteLine("---");
                        break;

                    case 2:
                        Console.WriteLine("Enter hours threshold:");
                        double threshold = double.Parse(Console.ReadLine());

                        Dictionary<string, int> result = program.GetOvertimeWeekCounts(PayrollBoard, threshold);

                        if (result.Count > 0)
                        {
                            foreach (var kvp in result)
                            {
                                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No overtime recorded this month");
                        }
                        Console.WriteLine("---");
                        break;

                    case 3:
                        double avg = program.CalculateAverageMonthlyPay();
                        Console.WriteLine($"Overall average monthly pay: {avg}");
                        Console.WriteLine("---");
                        break;

                    case 4:
                        Console.WriteLine("Logging off — Payroll processed successfully!");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
