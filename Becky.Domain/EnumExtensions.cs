using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Becky.Domain
{
    public static class EnumExtensions
    {
        public static string GetDescription<TEnum>(this TEnum value)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var name = Convert.ToString(value, CultureInfo.InvariantCulture);
            var field = typeof(TEnum).GetField(name);
            var description = field?.GetCustomAttributes(inherit: true).OfType<DescriptionAttribute>().SingleOrDefault();

            return description != null ? description.Description : name;
        }

        public static List<KeyValuePair<int, string>> GetValues<TEnum>(this TEnum value)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return (
                from TEnum i in Enum.GetValues(typeof(TEnum))
                select new KeyValuePair<int, string>(Convert.ToInt32(i), i.GetDescription())).ToList();
        }
    }
}