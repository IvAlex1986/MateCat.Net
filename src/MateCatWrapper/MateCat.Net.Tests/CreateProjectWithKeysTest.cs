using MateCat.Net.Models;
using NUnit.Framework;
using Should;
using System.Collections.Generic;

namespace MateCat.Net.Tests
{
    public class CreateProjectWithKeysTest : CreateProjectTest
    {
        protected override void When()
        {
            var projectFiles = new List<ProjectFile> { new ProjectFile(FilePath) };

            var subject = MateCatApiHelper.GetCode(CreateProjectTestModel.SupportedSubject);
            var keys = new List<ProjectKey> { new ProjectKey() };

            Project = SUT.CreateProject(projectFiles, ProjectName,
                CreateProjectTestModel.SourceLanguage, CreateProjectTestModel.TargetLanguage, subject,
                CreateProjectTestModel.UseMemoryServer, CreateProjectTestModel.UseMachineTranslation, keys, CreateProjectTestModel.SegmantationRule);

            ReadStatusTestModel.ProjectId = Project.Id;
            ReadStatusTestModel.ProjectPassword = Project.Password;
            ReadStatusTestModel.Save();
        }

        [Test]
        public void ProjectKeysNotNull()
        {
            Project.NewKeys.ShouldNotBeNull();
        }

        [Test]
        public void ProjectKeysNotEmpty()
        {
            Project.NewKeys.ShouldNotBeEmpty();
        }
    }
}
