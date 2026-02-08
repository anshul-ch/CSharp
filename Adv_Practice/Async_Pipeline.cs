using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CSharp.Adv_Practice
{
    public class Input
    {
        public int Value { get; set; }
    }

    public class Output
    {
        public int Value { get; set; }
    }

    public class PipelineProcessor
    {
        public List<Output> Process(List<Input> inputs)
        {
            return inputs
                .Select(i => new Output { Value = i.Value * 2 })
                .ToList();
        }
    }

    [TestFixture]
    public class PipelineProcessorTest
    {
        [Test]
        public void OrderIsPreserved()
        {
            var input = new List<Input>
            {
                new Input{Value=1},
                new Input{Value=2}
            };

            var result = new PipelineProcessor().Process(input);

            Assert.That(result[0].Value, Is.EqualTo(2));
            Assert.That(result[1].Value, Is.EqualTo(4));
        }
    }

    class Async_Pipeline
    {
        static void Main() { }
    }
}
