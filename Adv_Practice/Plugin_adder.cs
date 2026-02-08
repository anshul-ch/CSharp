using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CSharp.Adv_Practice
{
    public interface IPlugin
    {
        string Name { get; }
        void Execute();
    }

    public class PluginLoader
    {
        public List<IPlugin> Load(List<IPlugin> plugins)
        {
            var loaded = new List<IPlugin>();

            foreach (var plugin in plugins)
            {
                if (plugin != null)
                    loaded.Add(plugin);
            }

            return loaded;
        }
    }

    public class SamplePlugin : IPlugin
    {
        public string Name => "Sample";
        public void Execute() { }
    }

    [TestFixture]
    public class PluginLoader_Test
    {
        [Test]
        public void PluginsLoaded()
        {
            var loader = new PluginLoader();
            var plugins = loader.Load(new List<IPlugin> { new SamplePlugin() });
            Assert.That(plugins.Count, Is.EqualTo(1));
        }
    }

    class Plugin_adder
    {
        static void Main() { }
    }
}
