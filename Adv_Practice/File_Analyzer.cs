using System.Text.RegularExpressions;
using NUnit.Framework;

namespace CSharp.Adv_Practice
{
    public class ErrorSummary
    {
        public string? ErrorCode { get; set; }
        public int Count { get; set; }
    }

    public class ErrorCheck
    {
        public IEnumerable<ErrorSummary> GetTopErrors(
            IEnumerable<string> lines,int topN)
        {
            var errorCounts = new Dictionary<string, int>();
            Regex regex = new Regex(@"ERR\d{3}");

            foreach (var line in lines)
            {
                var match = regex.Match(line);
                if (!match.Success)
                    continue;

                string code = match.Value;

                if (!errorCounts.ContainsKey(code))
                    errorCounts[code] = 0;

                errorCounts[code]++;
            }

            return errorCounts
                .OrderByDescending(e => e.Value)
                .Take(topN)
                .Select(e => new ErrorSummary
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
            
        }
    }

    [TestFixture]
    public class ErrorCheckTests
    {
        [Test]
        public void Test_GetTopErrors()
        {
            // INPUT
            var inputLines = new[]
            {
                "ERROR ERR101 Failed",
                "ERROR ERR101 Timeout",
                "ERROR ERR202 Invalid input",
                "ERROR ERR101 Connection lost",
                "ERROR ERR303 Disk full"
            };

            var checkErr = new ErrorCheck();

            var result = checkErr.GetTopErrors(inputLines, 2).ToList();

            // ASSERT
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].ErrorCode, Is.EqualTo("ERR101"));
            Assert.That(result[0].Count, Is.EqualTo(3));
            Assert.That(result[1].ErrorCode, Is.EqualTo("ERR202"));
            Assert.That(result[1].Count, Is.EqualTo(1));
        }
    }
}
