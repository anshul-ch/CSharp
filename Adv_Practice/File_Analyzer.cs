using System;
using System.IO;
using System.Text.RegularExpressions;


namespace CSharp.Adv_Practice
{
    public class ErrorSummary
    {
        public string? ErrorCode {get; set;}
        public int Count {get; set;}
    }
    public class ErrorCheck
    {
        public IEnumerable<ErrorSummary> GetTopErrord(string filePath, int topN)
        {
            var errorCounts = new Dictionary<string, int>();
            Regex regex = new Regex(@"ERR\d{3}");
            foreach(var line in File.ReadLines(filePath))
            {
                var match = regex.Match(line);
                if (match.Success)
                {
                    string errorCodes = match.Value;
                    if (!errorCounts.ContainsKey(errorCodes))
                    {
                        errorCounts[errorCodes] =0;
                    }
                    errorCounts[errorCodes]++;
                }
            }
            return errorCounts.OrderByDescending(e => e.Value).Take(topN).Select(e => new ErrorSummary
            {
                ErrorCode = e.Key,
                Count = e.Value
            });
        }
    }

    class File_Analyzer
    {
        public static void Main(String[] args)
        {
            var error = new ErrorCheck();
            string filePath = "app.log";

        // Create local log file
        File.WriteAllLines(filePath, new[]
        {
            "INFO Application started",
            "ERROR ERR101 Database failure",
            "ERROR ERR101 Database timeout",
            "WARN Low memory",
            "ERROR ERR202 Invalid input",
            "ERROR ERR101 Connection lost",
            "ERROR ERR303 Disk full"
        });

            var result =  error.GetTopErrord(filePath, 5);
            foreach(var item in result)
            {
                Console.WriteLine(item.Count +"||" + item.ErrorCode);
            }
        }
    }
}