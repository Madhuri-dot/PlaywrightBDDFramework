using Microsoft.Playwright;

namespace PlaywrightBDD.Pages;
public class CheckoutPage
{
    private readonly IPage _page;

    public CheckoutPage(IPage page)
    {
        _page = page;
    }

    private ILocator FirstName => _page.Locator("#first-name");
    private ILocator LastName => _page.Locator("#last-name");
    private ILocator ZipCode => _page.Locator("#postal-code");
    private ILocator ContinueBtn => _page.Locator("#continue");
    private ILocator FinishBtn => _page.Locator("#finish");
    private ILocator SuccessMsg => _page.Locator(".complete-header");

    public async Task EnterDetails()
    {
        await FirstName.FillAsync("Test");
        await LastName.FillAsync("User");
        await ZipCode.FillAsync("12345");
    }

    public async Task CompleteCheckout()
    {
        await ContinueBtn.ClickAsync();
        await FinishBtn.ClickAsync();
    }

    public async Task<string> GetSuccessMessage()
    {
        return await SuccessMsg.InnerTextAsync();
    }
}