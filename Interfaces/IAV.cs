using ApiDi.Classes;

public interface IAVService
{
    public Task<AVTS> GetTimeSeries(string pFunction = "TIME_SERIES_INTRADAY", string pSymbol = "QQQ", string pInterval = "5min");
    public Task<AVTS> GetDaily(string pFunction = "TIME_SERIES_DAILY", string pSymbol = "QQQ", string pInterval = "5min");
    }