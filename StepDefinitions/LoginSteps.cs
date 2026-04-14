using TechTalk.SpecFlow;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightBDD.Pages;

[Binding]
public class LoginSteps
{
    private readonly LoginPage _loginPage;

    public LoginSteps(TestContext context)
    {
        _loginPage = new LoginPage(context.Page!);
    }

    [Given(@"I navigate to login page")]
    public async Task GivenINavigateToLoginPage()
    {
        await _loginPage.Navigate();
    }
    [Given(@"I login successfully")]
public async Task GivenILoginSuccessfully()
{
    await _loginPage.Navigate();
    await _loginPage.Login("standard_user", "secret_sauce");
}

    [When(@"I enter valid credentials")]
    public async Task WhenIEnterValidCredentials()
    {
        await _loginPage.Login("standard_user", "secret_sauce");
    }

    [When(@"I login with ""(.*)"" and ""(.*)""")]
    public async Task WhenILoginWithCredentials(string username, string password)
    {
         await _loginPage.Login(username, password);
    }

    [Then(@"I should see ""(.*)""")]
    public async Task ThenIShouldSeeResult(string result)
    {
    if (result == "success")
    {
        Assert.That(await _loginPage.IsHomePageLoaded(), Is.True);
    }
    else
    {
        var error = await _loginPage.GetErrorMessage();
        Assert.That(error, Is.Not.Null);
    }
}

    [Then(@"I should see homepage")]
    public async Task ThenIShouldSeeHomepage()
    {
        bool isVisible = await _loginPage.IsHomePageLoaded();
        Assert.That(isVisible, Is.True);
    }
}