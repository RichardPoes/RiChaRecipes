using Microsoft.JSInterop;

namespace RCR.JavaScript.Wrappers;

// This class provides an example of how JavaScript functionality can be wrapped
// in a .NET class for easy consumption. The associated JavaScript module is
// loaded on demand when first needed.
//
// This class can be registered as scoped DI service and then injected into Blazor
// components for use.

public class ExampleJsInterop
{
    private readonly AsyncJsObjectReference _jsObjectReference;

    public ExampleJsInterop(IJSRuntime jsRuntime)
    {
        _jsObjectReference = new AsyncJsObjectReference(jsRuntime, "./_content/RCR.JavaScript/js/exampleJsInterop.js");
    }

    public async ValueTask<string> Prompt(string message)
    {
        return await _jsObjectReference.InvokeAsync<string>("showPrompt", message);
    }
}