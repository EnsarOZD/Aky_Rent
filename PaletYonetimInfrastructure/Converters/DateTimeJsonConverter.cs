using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaletYonetimInfrastructure.Converters
{
	public class DateTimeJsonConverter : JsonConverter<DateTime>
	{
		private readonly string _format;

		public DateTimeJsonConverter(string format)
		{
			_format = format;
		}

		public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var str = reader.GetString();
			// Önce ISO 8601 ve diğer standart formatları dene
			if (DateTime.TryParse(str, out var dt))
				return dt;
			// Olmazsa özel formatı dene
			return DateTime.ParseExact(str, _format, null);
		}

		public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToString(_format));
		}
	}
}