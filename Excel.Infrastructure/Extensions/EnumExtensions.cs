using Excel.Domain.Enums;
using System.ComponentModel;

namespace Excel.Infrastructure.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this OperationType operationType)
        {
            var enumEmpty = "0";

            if(operationType.ToString().Equals(enumEmpty))
            {
                return string.Empty;
            }

            DescriptionAttribute[] attributes = (DescriptionAttribute[])operationType
                .GetType()
                .GetField(operationType.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
