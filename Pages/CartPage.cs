using Microsoft.Playwright;

namespace PlaywrightBDD.Pages;
public class CartPage
{
    private readonly IPage _page;

    public CartPage(IPage page)
    {
        _page = page;
    }

    // Locators
    private ILocator CartIcon => _page.Locator(".shopping_cart_link");
    private ILocator CartItems => _page.Locator(".cart_item");
    private ILocator RemoveButton => _page.Locator("button:has-text('Remove')");
    private ILocator CheckoutButton => _page.Locator("#checkout");

    // Actions
    public async Task OpenCart()
    {
        await CartIcon.ClickAsync();
    }

    public async Task<int> GetCartItemCount()
    {
        return await CartItems.CountAsync();
    }

    public async Task RemoveItem()
    {
        await RemoveButton.First.ClickAsync();
    }

    public async Task Checkout()
    {
        await CheckoutButton.ClickAsync();
    }
}