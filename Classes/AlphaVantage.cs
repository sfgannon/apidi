using System.Text.Json.Serialization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;
using Microsoft.VisualBasic;

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
    
        [JsonPropertyName("Time Series (30min)")]
        public Dictionary<string, AVTSPoint> TimeSeries { get; set; }

        public AVTS() {}
    }
}