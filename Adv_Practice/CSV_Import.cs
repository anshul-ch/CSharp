using System.Collections.Generic;
using NUnit.Framework;

namespace CSharp.Adv_Practice
{
    public class ImportResult
    {
        public int Inserted { get; set; }
        public List<int> FailedRows { get; set; } = new List<int>();
    }

    public class CsvImporter
    {
        public ImportResult Import(IEnumerable<string> rows)
        {
            var result = new ImportResult();
            int rowNo = 1;

            foreach (var row in rows)
            {
                var parts = row.Split(',');
                if (parts.Length < 2)
                    result.FailedRows.Add(rowNo);
                else
                    result.Inserted++;

                rowNo++;
            }

            return result;
        }
    }

    [TestFixture]
    public class CsvImporterTests
    {
        [Test]
        public void PartialSuccessHandled()
        {
            var rows = new[]
            {
                "1,Phone",
                "InvalidRow",
                "2,Laptop"
            };

            var importer = new CsvImporter();
            var result = importer.Import(rows);

            Assert.That(result.Inserted, Is.EqualTo(2));
            Assert.That(result.FailedRows.Count, Is.EqualTo(1));
        }
    }

    class Csv_Import
    {
        static void Main() { }
    }
}
