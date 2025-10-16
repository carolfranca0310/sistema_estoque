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
    }
}
