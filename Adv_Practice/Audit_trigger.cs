using System.Collections.Generic;
using NUnit.Framework;

namespace CSharp.Adv_Practice
{
    public class AuditEntry
    {
        public string Property { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }

    public class EntityTracker<T>
    {
        public List<AuditEntry> Track(Dictionary<string, string> oldValues, Dictionary<string, string> newValues)
        {
            var audit = new List<AuditEntry>();

            foreach (var key in oldValues.Keys)
            {
                if (oldValues[key] != newValues[key])
                {
                    audit.Add(new AuditEntry
                    {
                        Property = key,
                        OldValue = oldValues[key],
                        NewValue = newValues[key]
                    });
                }
            }

            return audit;
        }
    }

    [TestFixture]
    public class EntityTrackerTests
    {
        [Test]
        public void ChangesAreTracked()
        {
            var oldData = new Dictionary<string, string> { { "Name", "Amit" } };
            var newData = new Dictionary<string, string> { { "Name", "Amitesh" } };

            var result = new EntityTracker<object>().Track(oldData, newData);
            Assert.That(result.Count, Is.EqualTo(1));
        }
    }

    class Audit_trigger
    {
        static void Main() { }
    }
}
