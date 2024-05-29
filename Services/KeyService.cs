
public class KeyService : IKey
{
    //private readonly ConfigurationManager _config;
    private string TwelveDataKey;
    private string AlphaVantageKey;
    public KeyService(IConfiguration config)
    {
        TwelveDataKey = config.GetValue<string>("ApiKeys:TwelveData") ?? throw new Exception("Config value 'TwelveDataKey' not found.");
        AlphaVantageKey = config.GetValue<string>("ApiKeys:AlphaVantage") ?? throw new Exception("Config value 'AlphaVantageKey' not found.");
    }

    public string GetTwelveData()
    {
        return TwelveDataKey;
    }
    public string GetAlphaVantage()
    {
        return AlphaVantageKey;
    }
}