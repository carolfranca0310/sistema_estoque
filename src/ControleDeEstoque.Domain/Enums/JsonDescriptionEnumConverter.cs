using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InventoryManagement.Domain.Enums
{
    public class JsonDescriptionEnumConverter<T> : JsonConverter<T> where T : struct, Enum
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? value = reader.GetString();

            if (value == null)
                throw new JsonException("Value cannot be null.");

            foreach (var field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var description = field.GetCustomAttribute<DescriptionAttribute>()?.Description;
                if (description != null && string.Equals(description, value, StringComparison.OrdinalIgnoreCase))
                {
                    return (T)field.GetValue(null)!;
                }
            }

            if (Enum.TryParse(value, ignoreCase: true, out T result))
                return result;

            throw new JsonException($"Unable to convert \"{value}\" to enum {typeof(T)}.");
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var field = typeof(T).GetField(value.ToString()!);
            var description = field?.GetCustomAttribute<DescriptionAttribute>()?.Description;

            writer.WriteStringValue(description ?? value.ToString());
        }
    }
}
