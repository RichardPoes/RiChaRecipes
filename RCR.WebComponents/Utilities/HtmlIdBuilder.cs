namespace RCR.WebComponents.Utilities;

public static class HtmlIdBuilder
{
    private static readonly Random Rnd = new();

    /// <summary>
    /// Get a random string identifier but smaller than a Guid.
    /// The id prefix, not mentioned in the blog, ensures that the string starts with an alphabetical character.
    ///
    /// <a href="https://dvoituron.com/2022/04/07/generate-small-unique-identifier">Dvoituron Blog</a>
    /// </summary>
    /// <returns>Random string for example: 'id-127d9edf'</returns>
    public static string GetRandomId() => $"id-{Rnd.Next():x}";
}