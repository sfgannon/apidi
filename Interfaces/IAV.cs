using ApiDi.Classes;

public interface IAVService
{
    public Task<AVTS> GetTS(string pFunction = "TIME_SERIES_INTRADAY", string pSymbol = "QQQ", string pInterval = "5min");
    }