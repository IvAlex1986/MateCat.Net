using MateCat.Net.Enums;
using MateCat.Net.Models;
using MateCat.Net.Tests.Models;
using NUnit.Framework;
using Should;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace MateCat.Net.Tests
{
    public class CreateProjectTest : BaseTest
    {
        protected readonly String FilePath = String.Format("{0}.txt", Assembly.GetExecutingAssembly().GetName().Name);
        protected readonly String ProjectName = String.Format("MateCat.Net {0: yyyyMMdd HHmmss}", DateTime.UtcNow);
        protected readonly String TranslateText = ConfigurationManager.AppSettings.Get("TranslateText");

        protected readonly CreateProjectTestModel CreateProjectTestModel = new CreateProjectTestModel();
        protected readonly GetProjectStatusTestModel ReadStatusTestModel = new GetProjectStatusTestModel();

        protected Project Project;

        protected override void Given()
        {
            File.AppendAllText(FilePath, TranslateText);
        }

        protected override void When()
        {
            var projectFiles = new List<ProjectFile> { new ProjectFile(FilePath) };

            Project = SUT.CreateProject(projectFiles, ProjectName,
                CreateProjectTestModel.SourceLanguage, CreateProjectTestModel.TargetLanguage, CreateProjectTestModel.SupportedSubject,
                CreateProjectTestModel.UseMemoryServer, CreateProjectTestModel.UseMachineTranslation, CreateProjectTestModel.PrivateKey, CreateProjectTestModel.SegmantationRule);

            ReadStatusTestModel.ProjectId = Project.Id;
            ReadStatusTestModel.ProjectPassword = Project.Password;
            ReadStatusTestModel.Save();
        }

        protected override void AfterSpec()
        {
            File.Delete(FilePath);
        }

        [Test]
        public void ProjectNotNull()
        {
            Project.ShouldNotBeNull();
        }

        [Test]
        public void ProjectStatusIsOk()
        {
            Project.Status.ShouldEqual(CreationProjectStatus.Ok);
        }

        [Test]
        public void ProjectMessagesNotEmpty()
        {
            Project.Message.ShouldNotBeEmpty();
        }
    }
}
