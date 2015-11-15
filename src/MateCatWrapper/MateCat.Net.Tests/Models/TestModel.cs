using System;
using System.Configuration;

namespace MateCat.Net.Tests.Models
{
    public abstract class TestModel
    {
        protected static String GetConfigurationSettingValue(String key)
        {
            return ConfigurationManager.AppSettings.Get(key);
        }

        protected static void SetConfigurationSettingValue(String key, String value)
        {
            ConfigurationManager.AppSettings.Set(key, value);
        }
    }
}
