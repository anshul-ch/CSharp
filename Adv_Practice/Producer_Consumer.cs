using System.Collections.Generic;
using NUnit.Framework;

namespace CSharp.Adv_Practice
{
    public class Order
    {
        public int Id { get; set; }
    }
    public class OrderQueueProcessor
    {
        private readonly Queue<Order> queue = new Queue<Order>();

        public void AddOrder(Order order)
        {
            queue.Enqueue(order);
        }

        public int ProcessAll()
        {
            int count = 0;
            while (queue.Count > 0)
            {
                queue.Dequeue();
                count++;
            }
            return count;
        }
    }

    [TestFixture]
    public class OrderQueueTest
    {
        [Test]
        public void AllOrdersAreProcessed()
        {
            var processor = new OrderQueueProcessor();
            processor.AddOrder(new Order { Id = 1 });
            processor.AddOrder(new Order { Id = 2 });

            Assert.That(processor.ProcessAll(), Is.EqualTo(2));
        }
    }

    class Producer_Consumer
    {
        static void Main() { }
    }
}
