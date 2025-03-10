using Microsoft.JSInterop;

namespace RCR.JavaScript.Wrappers;

// This class provides an example of how JavaScript functionality can be wrapped
// in a .NET class for easy consumption. The associated JavaScript module is
// loaded on demand when first needed.
//
// This class can be registered as scoped DI service and then injected into Blazor
// components for use.

public class ThemeSelector
{
    private readonly AsyncJsObjectReference _jsObjectReference;

    public ThemeSelector(IJSRuntime jsRuntime)
    {
        _jsObjectReference = new AsyncJsObjectReference(jsRuntime, "./_content/RCR.JavaScript/js/themeSelector.js");
    }

    public async ValueTask<string> InitializeTheming()
    {
        return await _jsObjectReference.InvokeAsync<string>("initializeTheming");
    }
}