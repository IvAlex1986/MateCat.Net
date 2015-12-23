using MateCat.Net.Attributes;
using MateCat.Net.Helpers;
using System;

namespace MateCat.Net
{
    public static class MateCatApiHelper
    {
        public static String GetCode(Enum value)
        {
            return value.GetAttribute<CodeAttribute>().Value;
        }
    }
}
