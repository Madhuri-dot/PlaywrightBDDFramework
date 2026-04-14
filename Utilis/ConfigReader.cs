using Microsoft.Extensions.Configuration;

public class ConfigReader
{
    private static IConfigurationRoot _config;

    static ConfigReader()
    {
        _config = new ConfigurationBuilder()
            .AddJsonFile("Config/appsettings.json")
            .Build();
    }

    public static string Get(string key)
    {
        return _config[key] ?? throw new Exception($"Key '{key}' not found in config");
    }
}