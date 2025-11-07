using System.ComponentModel;
using System.Reflection;

namespace InventoryManagement.Domain.Utils.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo == null)
                return value.ToString();

            var descriptionAttribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();

            return descriptionAttribute?.Description ?? value.ToString();
        }

        public static TEnum GetEnumFromDescription<TEnum>(this string description) where TEnum : Enum
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException(nameof(description));

            var type = typeof(TEnum);

            foreach (var field in type.GetFields())
            {
                var attribute = field.GetCustomAttribute<DescriptionAttribute>();
                if (attribute != null && attribute.Description.Equals(description, StringComparison.OrdinalIgnoreCase))
                    return (TEnum)field.GetValue(null)!;

                if (field.Name.Equals(description, StringComparison.OrdinalIgnoreCase))
                    return (TEnum)field.GetValue(null)!;
            }

            throw new ArgumentException($"No enum value found for description '{description}' in {type.Name}");
        }


    }

}
