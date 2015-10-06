using System;

namespace Becky.Web.Helpers
{
    public class Helper
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}