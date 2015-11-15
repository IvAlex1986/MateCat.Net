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

        private Project _project;

        protected override void Given()
        {
            File.AppendAllText(FilePath, TranslateText);
        }

        protected override void When()
        {
            var projectFiles = new List<ProjectFile> { new ProjectFile(FilePath) };

            _project = SUT.CreateProject(projectFiles, ProjectName,
                CreateProjectTestModel.SourceLanguage, CreateProjectTestModel.TargetLanguage, CreateProjectTestModel.SupportedSubject,
                CreateProjectTestModel.UseMemoryServer, CreateProjectTestModel.UseMachineTranslation, CreateProjectTestModel.PrivateKey, CreateProjectTestModel.SegmantationRule);

            ReadStatusTestModel.ProjectId = _project.Id;
            ReadStatusTestModel.ProjectPassword = _project.Password;
            ReadStatusTestModel.Save();
        }

        protected override void AfterSpec()
        {
            File.Delete(FilePath);
        }

        [Test]
        public void ProjectNotNull()
        {
            _project.ShouldNotBeNull();
        }

        [Test]
        public void ProjectStatusIsOk()
        {
            _project.Status.ShouldEqual(CreationProjectStatus.Ok);
        }

        [Test]
        public void ProjectMessagesIsEmpty()
        {
            _project.Message.ShouldNotBeEmpty();
        }
    }
}
