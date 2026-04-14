using TechTalk.SpecFlow;
using NUnit.Framework;
using PlaywrightBDD.Pages;

[Binding]
public class CartSteps
{
    private readonly CartPage _cartPage;
    private readonly InventoryPage _inventoryPage;

    public CartSteps(TestContext context)
    {
        _cartPage = new CartPage(context.Page!);
        _inventoryPage = new InventoryPage(context.Page!);
         _checkoutPage = new CheckoutPage(context.Page!);
    }

    [When(@"I add a product to cart")]
    public async Task AddProduct()
    {
        await _inventoryPage.AddItemToCart();
    }

    [When(@"I open the cart")]
    public async Task OpenCart()
    {
        await _cartPage.OpenCart();
    }

    [Then(@"product should be in cart")]
    public async Task ValidateCart()
    {
        int count = await _cartPage.GetCartItemCount();
        Assert.That(count, Is.GreaterThan(0));
    }
private readonly CheckoutPage _checkoutPage;


[When(@"I proceed to checkout")]
public async Task Checkout()
{
    await _cartPage.Checkout();
}

[When(@"I enter checkout details")]
public async Task EnterDetails()
{
    await _checkoutPage.EnterDetails();
    await _checkoutPage.CompleteCheckout();
}

[Then(@"order should be successful")]
public async Task ValidateOrder()
{
    var message = await _checkoutPage.GetSuccessMessage();
    Assert.That(message, Does.Contain("Thank you"));
}
}