using System.Diagnostics;
using System.Net.Sockets;
using Undefined.Plugins.ExampleApi;

namespace Undefined.Plugins.Tests;

public class Tests
{
    private const string EXAMPLE_PLUGIN_NAME = "Undefined.Plugins.ExamplePlugin";
    private const string EXAMPLE_EXTENSION_PLUGIN_NAME = "Undefined.Plugins.ExamplePluginExtension";
    private PluginsManager<PluginApi> _manager;

    public Tests()
    {
    }

    [SetUp]
    public void Setup()
    {
        _manager = PluginsManager<PluginApi>.Create<MainPlugin>(out var result);

        if (_manager.LoadPlugin(EXAMPLE_PLUGIN_NAME).Status == PluginLoadStatus.Error) Assert.Fail();
        if (_manager.LoadPlugin(EXAMPLE_EXTENSION_PLUGIN_NAME).Status == PluginLoadStatus.Error) Assert.Fail();
    }

    [TearDown]
    public void TearDown()
    {
        _manager.Dispose();
    }

    [Test]
    [Order(1)]
    public void ReloadPlugins()
    {
        foreach (var plugin in _manager.Plugins)
        {
            if (!plugin.TryReload(out var result)) continue;
            if (result!.Status == PluginLoadStatus.Error) Assert.Fail();
        }
        Assert.Pass();
    }

    [Test]
    [Order(2)]
    public void DisableAndUnloadPlugins()
    {
        foreach (var plugin in _manager.Plugins) plugin.TryUnload();
        Assert.Pass();
    }
}