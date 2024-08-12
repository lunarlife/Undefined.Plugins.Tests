using Undefined.Plugins.ExampleApi;

namespace Undefined.Plugins.ExamplePlugin;

[Plugin("TestPlugin", 1, 0, 0)]
public class TestPlugin : PluginApi
{
    public void HelloWorld()
    {
        Console.WriteLine("HelloWorld!");
    }
}