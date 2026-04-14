using Microsoft.Playwright;
using System.Threading.Tasks;

public class ApiHelper
{
    private readonly IAPIRequestContext _apiContext;

    public ApiHelper(IPlaywright playwright)
    {
        _apiContext = playwright.APIRequest.NewContextAsync().Result;
    }

    public async Task<IAPIResponse> Get(string url)
    {
        return await _apiContext.GetAsync(url);
    }
}