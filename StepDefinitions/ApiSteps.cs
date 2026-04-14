using TechTalk.SpecFlow;
using NUnit.Framework;
using Microsoft.Playwright; 

[Binding]
public class ApiSteps
{
    private readonly ApiContext _apiContext;
    private IAPIResponse? _response;

    public ApiSteps(ApiContext apiContext)
    {
        _apiContext = apiContext;
    }

    [When(@"I send GET request to ""(.*)""")]
    public async Task SendGetRequest(string url)
    {
        _response = await _apiContext.Request!.GetAsync(url, new()
{
    Headers = new Dictionary<string, string>
    {
        ["Accept"] = "application/json"
    }
});
    }

[Then(@"response status should be (.*)")]
public async Task ValidateStatus(int status)
{
    var body = await _response!.TextAsync();

    Console.WriteLine($"Status: {_response.Status}");
    Console.WriteLine($"Response: {body}");

    Assert.That(_response.Status, Is.EqualTo(status));
}
}