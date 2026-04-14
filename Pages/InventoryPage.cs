using Microsoft.Playwright;

namespace PlaywrightBDD.Pages;
public class InventoryPage
{
    private readonly IPage _page;

    public InventoryPage(IPage page)
    {
        _page = page;
    }

    private ILocator AddToCartButton => _page.Locator("button:has-text('Add to cart')");

    public async Task AddItemToCart()
    {
        await AddToCartButton.First.ClickAsync();
    }
}