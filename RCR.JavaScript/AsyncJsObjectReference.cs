using Microsoft.JSInterop;

namespace RCR.JavaScript;

public class AsyncJsObjectReference : IJSObjectReference
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public AsyncJsObjectReference(IJSRuntime jsRuntime, string filePath)
    {
        _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", filePath).AsTask());
    }

    public async ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<TValue>(identifier, args);
    }

    public async ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object?[]? args)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<TValue>(identifier, cancellationToken);
    }

    public async ValueTask DisposeAsync()
    {
        await Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual async Task Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_moduleTask.IsValueCreated)
            {
                var module = await _moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}