
using System.Text.Json.Nodes;
using ApiDi.Classes;

public interface IAlphaVantageService
{
    public Task<string> GetTS(string pFunction = "TIME_SERIES_INTRADAY", string pSymbol = "QQQ", string pInterval = "5min");
    }