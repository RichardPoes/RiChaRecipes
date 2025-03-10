using Microsoft.AspNetCore.Components;

namespace RCR.WebComponents;

public abstract class PolymorphComponent : ComponentBase
{
public RenderFragment RenderFragment => (builder) => { builder.OpenComponent(0, GetType()); builder.CloseComponent(); };
}