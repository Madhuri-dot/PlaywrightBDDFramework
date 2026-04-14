using Microsoft.Playwright;

public class TestContext
{
    public IBrowser? Browser { get; set; }
    public IPage? Page { get; set; }
}