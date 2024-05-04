Basic Dependency Injection Concepts
- Create a service
- Register with service container
- Inject HttpClient
- Create a secondary service with dependency on the first service
- Register dependencies in service container
- Make an external API call using the dependent service and HttpClient

### Example of an AlphaVantage Daily Time Series Response

```
{
    "Meta Data": {
        "1. Information": "Intraday (5min) open, high, low, close prices and volume",
        "2. Symbol": "QQQ",
        "3. Last Refreshed": "2024-04-30 19:55:00",
        "4. Interval": "5min",
        "5. Output Size": "Compact",
        "6. Time Zone": "US/Eastern"
    },
    "Time Series (5min)": {
        "2024-04-30 19:55:00": {
            "1. open": "422.9200",
            "2. high": "423.2000",
            "3. low": "422.9000",
            "4. close": "423.1980",
            "5. volume": "19200"
        },
        "2024-04-30 19:50:00": {
            "1. open": "423.0350",
            "2. high": "423.0500",
            "3. low": "422.8400",
            "4. close": "422.9000",
            "5. volume": "2678"
        }
    }
}
```