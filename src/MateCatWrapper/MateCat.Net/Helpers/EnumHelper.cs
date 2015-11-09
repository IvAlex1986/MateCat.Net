using System;
using System.ComponentModel;
using System.Reflection;

namespace MateCat.Net.Helpers
{
    internal static class EnumHelper
    {
        public static T Parse<T>(String value) where T: struct
        {
            if (!typeof (T).IsEnum)
            {
                throw new InvalidEnumArgumentException("Please use Enum in parameter");
            }

            var clearedValue = value.Replace(" ", String.Empty).Replace("-", String.Empty);

            return (T)Enum.Parse(typeof(T), clearedValue, true);
        }

        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var field = value.GetType().GetField(value.ToString());
            return (T)field.GetCustomAttribute(typeof(T), false);
        }
    }
}
