using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CSharp.Adv_Practice
{
    public class PaymentRequest
    {
        public decimal Amount { get; set; }
    }

    public class PaymentResult
    {
        public bool Success { get; set; }
    }

    public class PaymentProcessor
    {
        private readonly Queue<bool> responses;
        private int failureCount;
        private DateTime? blockedUntil;

        public PaymentProcessor(IEnumerable<bool> results)
        {
            responses = new Queue<bool>(results);
        }

        public PaymentResult Process(PaymentRequest request)
        {
            if (blockedUntil.HasValue && DateTime.Now < blockedUntil)
                return new PaymentResult { Success = false };

            for (int i = 0; i < 3; i++)
            {
                if (responses.Dequeue())
                {
                    failureCount = 0;
                    return new PaymentResult { Success = true };
                }

                failureCount++;

                if (failureCount >= 5)
                {
                    blockedUntil = DateTime.Now.AddSeconds(30);
                    break;
                }
            }

            return new PaymentResult { Success = false };
        }
    }

    [TestFixture]
    public class PaymentProcessorTests
    {
        [Test]
        public void BlocksFurtherCalls()
        {
            var processor = new PaymentProcessor(new[] { false, false, false, false, false, true });
            processor.Process(new PaymentRequest { Amount = 100 });
            var result = processor.Process(new PaymentRequest { Amount = 100 });
            Assert.That(result.Success, Is.False);
        }
    }

    class Resilient_Payment
    {
        static void Main() { }
    }
}
