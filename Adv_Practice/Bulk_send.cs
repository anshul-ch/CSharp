using System.Collections.Generic;
using NUnit.Framework;

namespace CSharp.Adv_Practice
{
    public class Email
    {
        public string Address { get; set; }
        public bool ShouldFail { get; set; }
    }

    public class BulkSendReport
    {
        public int Success { get; set; }
        public int Failure { get; set; }
    }

    public class BulkEmailSender
    {
        public BulkSendReport Send(List<Email> emails)
        {
            int success = 0;
            int failure = 0;

            foreach (var email in emails)
            {
                int attempts = 0;
                bool sent = false;

                while (attempts < 3 && !sent)
                {
                    attempts++;
                    if (!email.ShouldFail)
                        sent = true;
                }

                if (sent) success++;
                else failure++;
            }

            return new BulkSendReport { Success = success, Failure = failure };
        }
    }

    [TestFixture]
    public class BulkEmail_Sender_Test
    {
        [Test]
        public void Retries_Counts_test()
        {
            var emails = new List<Email>
            {
                new Email{Address="rahul@test.com",ShouldFail=false},
                new Email{Address="ankit@test.com",ShouldFail=true}
            };

            var report = new BulkEmailSender().Send(emails);
            Assert.That(report.Success, Is.EqualTo(1));
            Assert.That(report.Failure, Is.EqualTo(1));
        }
    }

    class Bulk_send
    {
        static void Main() { }
    }
}
