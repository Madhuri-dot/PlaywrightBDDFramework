using TechTalk.SpecFlow;
using Microsoft.Playwright;

[Binding]
public class TestHooks
{
    private readonly TestContext _context;
    private readonly ApiContext _apiContext;

  public TestHooks(TestContext context, ApiContext apiContext)
    {
    _context = context;
    _apiContext = apiContext;
    }

[BeforeScenario]
public async Task Setup()
{
    var playwright = await Playwright.CreateAsync();

    var browser = await playwright.Chromium.LaunchAsync(new()
    {
        Headless = false
    });

    var page = await browser.NewPageAsync();

    _context.Browser = browser;
    _context.Page = page;

    // API setup
    _apiContext.Request = await playwright.APIRequest.NewContextAsync();
}

 [AfterScenario]
public async Task TearDown()
{
    if (_context.Page != null)
    {
        await _context.Page.CloseAsync();
        Console.WriteLine("Page closed");
    }
    else
    {
        Console.WriteLine("Page was null in teardown");
    }
}
}