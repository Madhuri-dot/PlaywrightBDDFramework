using NUnit.Framework;
using Microsoft.Playwright;
using System.Threading.Tasks;

[TestFixture]
public class ApiTests
{
    [Test]
    public async Task GetUsers()
    {
        var playwright = await Playwright.CreateAsync();

        var request = await playwright.APIRequest.NewContextAsync();

        var response = await request.GetAsync("https://reqres.in/api/users?page=2");

        Assert.That(response.Status, Is.EqualTo(200));
    }
}