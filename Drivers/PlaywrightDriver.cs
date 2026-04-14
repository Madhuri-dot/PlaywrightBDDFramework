using Microsoft.Playwright;

namespace PlaywrightBDD.Drivers;

public class PlaywrightDriver
{
    private static AsyncLocal<IPlaywright?> _playwright = new();
    private static AsyncLocal<IBrowser?> _browser = new();
    private static AsyncLocal<IPage?> _page = new();

    public async Task Initialize()
    {
        _playwright.Value = await Microsoft.Playwright.Playwright.CreateAsync();

        _browser.Value = await _playwright.Value.Chromium.LaunchAsync(new()
        {
            Headless = true,
            //SlowMo = 300
        });

        _page.Value = await _browser.Value.NewPageAsync();

        Console.WriteLine("Browser + Page initialized");
    }

    public IPage GetPage()
    {
        return _page.Value ?? throw new Exception("Page not initialized");
    }

    public async Task Quit()
    {
        if (_browser.Value != null)
            await _browser.Value.CloseAsync();
    }
}