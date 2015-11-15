using System;

namespace MateCat.Net.Tests.Models
{
    public class GetProjectStatusTestModel : TestModel
    {
        public GetProjectStatusTestModel()
        {
            ProjectId = Int32.Parse(GetConfigurationSettingValue("ProjectId"));
            ProjectPassword = GetConfigurationSettingValue("ProjectPassword");
        }

        public Int32 ProjectId { get; set; }

        public String ProjectPassword { get; set; }

        public void Save()
        {
            SetConfigurationSettingValue("ProjectId", ProjectId.ToString());
            SetConfigurationSettingValue("ProjectPassword", ProjectPassword);
        }
    }
}
