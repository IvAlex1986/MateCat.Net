using MateCat.Net.Enums;
using System;

namespace MateCat.Net.Tests.Models
{
    public class CreateProjectTestModel : TestModel
    {
        public CreateProjectTestModel()
        {
            ProjectName = String.Format("{0}_{1: yyyyMMdd HHmmss}", GetConfigurationSettingValue("ProjectName"), DateTime.UtcNow);
            SourceLanguage = GetConfigurationSettingValue("SourceLanguage");
            TargetLanguage = GetConfigurationSettingValue("TargetLanguage");
            UseMemoryServer = Boolean.Parse(GetConfigurationSettingValue("UseMemoryServer"));
            UseMemoryServer = Boolean.Parse(GetConfigurationSettingValue("UseMachineTranslation"));
            PrivateKey = GetConfigurationSettingValue("PrivateKey");
            SupportedSubject = (SupportedSubject)Enum.Parse(typeof(SupportedSubject), GetConfigurationSettingValue("SupportedSubject"));
            SegmantationRule = (SegmentationRule)Enum.Parse(typeof(SegmentationRule), GetConfigurationSettingValue("SegmantationRule"));
        }

        public String ProjectName { get; set; }

        public String SourceLanguage { get; set; }

        public String TargetLanguage { get; set; }

        public Boolean UseMemoryServer { get; set; }

        public Boolean UseMachineTranslation { get; set; }

        public String PrivateKey { get; set; }

        public SupportedSubject SupportedSubject { get; set; }

        public SegmentationRule SegmantationRule { get; set; }
    }
}
