
public class KeyService : IKey
{
    //private readonly ConfigurationManager _config;
    private string TwelveDataKey;
    private string AlphaVantageKey;
    public KeyService(ConfigurationManager config)
    {
        // _config = config;
        var keysSection = config.GetSection("ApiKeys");
        TwelveDataKey = keysSection.GetValue<string>("TwelveDataKey");
        AlphaVantageKey = keysSection.GetValue<string>("AlphaVantageKey");
    }

    public string GetTwelveData() {
        return TwelveDataKey;
    }
    public string GetAlphaVantage() {
        return AlphaVantageKey;
    }
}