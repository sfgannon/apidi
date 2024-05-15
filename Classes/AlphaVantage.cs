using System.Globalization;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks.Dataflow;
using Microsoft.VisualBasic;

namespace ApiDi.Classes
{
    public class AVDateTimeConverter : JsonConverter<DateTime> {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString()!, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
        }
    }
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
    public class AVTimeSeries{
        public string sBody {get; set; }

        public AVTimeSeries() {}
    }

    public class AVTS {
        [JsonPropertyName("Meta Data")]
        public AVMeta MetaData {get; set; }

        [JsonPropertyName("Time Series (5min)")]
        public AVTimeSeries TimeSeries { get; set; }

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