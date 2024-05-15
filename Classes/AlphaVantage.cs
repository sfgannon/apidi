using System.Text.Json.Serialization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace ApiDi.Classes
{
    public class AVMeta{
        [JsonPropertyName("1. Information")]
        public string Information {get; set; }

        [JsonPropertyName("2. Symbol")]
        public string Symbol {get; set; }

        [JsonPropertyName("3. Last Refreshed")]
        [JsonConverter(typeof(AVDateTimeConverter))]
        public DateTime LastRefreshed {get; set; }

        [JsonPropertyName("4. Interval")]
        public string Interval {get; set; }

        [JsonPropertyName("5. Output Size")]
        public string OutputSize {get; set; }

        [JsonPropertyName("6. Time Zone")]
        public string TimeZone {get; set; }

        public AVMeta() {}
    }
    public class AVTSPoint{
        [JsonPropertyName("1. open")]
        public string Open { get; set; }

        [JsonPropertyName("2. high")]
        public string High { get; set; }

        [JsonPropertyName("3. low")]
        public string Low { get; set; }

        [JsonPropertyName("4. close")]
        public string Close { get; set; }

        [JsonPropertyName("5. volume")]
        public string Volume { get; set; }

        public AVTSPoint() {}
    }

    public class AVTS {
        [JsonPropertyName("Meta Data")]
        public AVMeta MetaData {get; set; }

        [JsonPropertyName("Time Series (5min)")]
        public Dictionary<string, object> Points;

        public AVTS() {}
    }



    public class AlphaVantageMeta
    {
        [JsonPropertyName("1. Information")]
        public string sInformation;
        public string sSymbol;
        public string sLastRefreshed;
        public string sInterval;
        public string sOutputSize;
        public string sTimeZone;
        public AlphaVantageMeta() {
            this.sInformation = "";
            this.sSymbol = "";
            this.sLastRefreshed = "";
            this.sInterval = "";
            this.sOutputSize = "";
            this.sTimeZone = "";
        }
    }
    public class TimeSeriesPoint
    {
        DateTime tTime;
        decimal dOpen;
        decimal dHigh;
        decimal dLow;
        decimal dClose;
        int intVolume;
    }
    public class AlphaVantageOptions {
        public AlphaVantageMeta? meta;
        public TimeSeriesPoint[]? ts;
        public AlphaVantageOptions() {
            this.meta = null;
            this.ts = null;
        }
    }
    public class TimeSeries
    {
        AlphaVantageMeta? Metadata;
        TimeSeriesPoint[]? Values;
        public TimeSeries() { }
        public TimeSeries(AlphaVantageOptions opts) {
            this.Metadata = opts.meta;
            this.Values = opts.ts;
        }
    }
    public class AlphaVantageRequest {
        string sSymbol { get; set; } = string.Empty;
        string sFunction { get; set; } = string.Empty;
        public AlphaVantageRequest(string pSymbol, string pFunction) {
            sSymbol = pSymbol;
            sFunction = pFunction;
        }
    }
}