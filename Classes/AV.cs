using System.Text.Json.Serialization;

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

        [JsonPropertyName("Time Series")]
        public Dictionary<string, AVTSPoint> TimeSeries { get; set; }
    
        [JsonPropertyName("Time Series (60min)")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, AVTSPoint> TimeSeries60 { set {
            this.TimeSeries = value;
        }}
    
        [JsonPropertyName("Time Series (30min)")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, AVTSPoint> TimeSeries30 { set {
            this.TimeSeries = value;
        }}
    
        [JsonPropertyName("Time Series (15min)")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, AVTSPoint> TimeSeries15 { set {
            this.TimeSeries = value;
        }}
    
        [JsonPropertyName("Time Series (5min)")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, AVTSPoint> TimeSeries5 { set {
            this.TimeSeries = value;
        }}
    
        [JsonPropertyName("Time Series (1min)")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, AVTSPoint> TimeSeries1 { set {
            this.TimeSeries = value;
        }}

        public AVTS() {}
    }
}