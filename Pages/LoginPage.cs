using Microsoft.Playwright;

namespace PlaywrightBDD.Pages;

public class LoginPage
{
    private readonly IPage _page;

    public LoginPage(IPage page)
    {
        _page = page;
    }

    private ILocator Username => _page.Locator("#user-name");
    private ILocator Password => _page.Locator("#password");
    private ILocator LoginBtn => _page.Locator("#login-button");

    public async Task Navigate()
    {
        await _page.GotoAsync("https://www.saucedemo.com");
    }

    public async Task Login(string user, string pass)
    {
        await Username.FillAsync(user);
        await Password.FillAsync(pass);
        await LoginBtn.ClickAsync();
    }

    public async Task<bool> IsHomePageLoaded()
    {
    return _page.Url.Contains("inventory") &&
           await _page.Locator(".inventory_list").IsVisibleAsync();
    }

    private ILocator ErrorMessage => _page.Locator(".error-message-container");

    public async Task<string> GetErrorMessage()
    {
    return await ErrorMessage.InnerTextAsync();
    }
}