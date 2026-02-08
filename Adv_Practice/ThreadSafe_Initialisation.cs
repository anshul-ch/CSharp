using System.Collections.Generic;
using NUnit.Framework;

namespace CSharp.Adv_Practice
{
    public class ConfigManager
    {
        private static readonly object sync = new object();
        private static ConfigManager instance;
        private readonly Dictionary<string, string> settings = new Dictionary<string, string>();

        private ConfigManager()
        {
            settings["AppName"] = "TestApp";
        }

        public static ConfigManager Instance
        {
            get
            {
                lock (sync)
                {
                    if (instance == null)
                        instance = new ConfigManager();
                    return instance;
                }
            }
        }

        public string GetSetting(string key)
        {
            return settings.ContainsKey(key) ? settings[key] : null;
        }
    }

    [TestFixture]
    public class ConfigManager_Test
    {
        [Test]
        public void SameInstanceReturned()
        {
            var a = ConfigManager.Instance;
            var b = ConfigManager.Instance;
            Assert.That(ReferenceEquals(a, b), Is.True);
        }
    }

    class ThreadSafe_Initialisation
    {
        static void Main() { }
    }
}
