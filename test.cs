using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

public class PlaywrightTest
{
    [Test]
    public async Task LaunchBrowser()
    {
        using var playwright = await Playwright.CreateAsync();

        var browser = await playwright.Chromium.LaunchAsync(new()
        {
            Headless = false,
            SlowMo = 1000   // 👈 VERY IMPORTANT (slow actions)
        });

        var page = await browser.NewPageAsync();

        await page.GotoAsync("https://example.com");

        // 👇 Keep browser open long enough to SEE it
        await page.WaitForTimeoutAsync(15000);
    }
}