using System.Threading.Tasks.Dataflow;

namespace ApiDi.Classes
{
    public class AlphaVantageMeta
    {
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
}