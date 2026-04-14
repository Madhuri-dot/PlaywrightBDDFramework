using Microsoft.Playwright;

public class ApiContext
{
    public IAPIRequestContext? Request { get; set; }
    public IAPIResponse? Response { get; set; }

    public async Task Initialize(IPlaywright playwright)
    {
        Request = await playwright.APIRequest.NewContextAsync(new()
        {
            ExtraHTTPHeaders = new Dictionary<string, string>
            {
                ["Authorization"] = "Bearer YOUR_TOKEN",
                ["Accept"] = "application/json"
            }
        });
}
}
