using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace CSharp.Adv_Practice
{
    public class CustomerApplication
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Pan { get; set; }
    }

    public class ValidationReport
    {
        public int Valid { get; set; }
        public int Invalid { get; set; }
    }

    public class JsonValidator
    {
        public ValidationReport ValidateBatch(List<string> payloads)
        {
            int valid = 0;
            int invalid = 0;

            foreach (var p in payloads)
            {
                var app = JsonSerializer.Deserialize<CustomerApplication>(p);
                bool isValid =
                    !string.IsNullOrWhiteSpace(app.Name) &&
                    Regex.IsMatch(app.Email ?? "", @"@") &&
                    app.Age >= 18 &&
                    app.Age <= 60 &&
                    Regex.IsMatch(app.Pan ?? "", @"^[A-Z]{5}\d{4}[A-Z]$");

                if (isValid) valid++; else invalid++;
            }

            return new ValidationReport { Valid = valid, Invalid = invalid };
        }
    }

    [TestFixture]
    public class JsonBatchValidatorTests
    {
        [Test]
        public void ValidAndInvalidAreCounted()
        {
            var list = new List<string>
            {
                "{\"Name\":\"Rohan\",\"Email\":\"rohan@test.com\",\"Age\":30,\"Pan\":\"ABCDE1234F\"}",
                "{\"Name\":\"\",\"Email\":\"bad\",\"Age\":10,\"Pan\":\"123\"}"
            };

            var validator = new JsonValidator();
            var result = validator.ValidateBatch(list);

            Assert.That(result.Valid, Is.EqualTo(1));
            Assert.That(result.Invalid, Is.EqualTo(1));
        }
    }

    class Json_Validation
    {
        static void Main() { }
    }
}
