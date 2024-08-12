using Undefined.Plugins.ExampleApi;
using Undefined.Plugins.ExamplePlugin;
using Undefined.Plugins.ExamplePluginExtension.Exceptions;

namespace Undefined.Plugins.ExamplePluginExtension;


[Plugin("ExtensionPlugin", 1, 0,0)]
public class ExtensionPlugin : PluginApi
{
    protected override void OnEnable()
    {
        if (!PluginsManager.TryGetPlugin<TestPlugin>(out var plugin))
            throw new PluginMissingException();

        plugin!.HelloWorld();
    }
}