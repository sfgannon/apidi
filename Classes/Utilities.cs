
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiDi.Classes
{
    public class AVDateTimeConverter : JsonConverter<DateTime> {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            DateTime test = new DateTime();
            // Do TryParseExact and give format, if it doesnt align its a single full day
            if (DateTime.TryParseExact(reader.GetString()!, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out test)) {
                return test;
            } else {
                return DateTime.ParseExact(reader.GetString()!, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            // return DateTime.ParseExact(reader.GetString()!, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
        }
    }
}