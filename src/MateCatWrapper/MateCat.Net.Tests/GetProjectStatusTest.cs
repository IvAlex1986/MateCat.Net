using MateCat.Net.Enums;
using MateCat.Net.Models;
using MateCat.Net.Tests.Models;
using NUnit.Framework;
using Should;
using System;

namespace MateCat.Net.Tests
{
    public class GetProjectStatusTest : BaseTest
    {
        protected readonly GetProjectStatusTestModel ReadStatusTestModel = new GetProjectStatusTestModel();

        private ProjectStatus _projectStatus;

        protected override void When()
        {
            _projectStatus = SUT.GetProjectStatus(ReadStatusTestModel.ProjectId, ReadStatusTestModel.ProjectPassword);
        }

        [Test]
        public void ProjectStatusNotNull()
        {
            _projectStatus.ShouldNotBeNull();
        }

        [Test]
        public void ProjectStatusNotFailed()
        {
            _projectStatus.Status.ShouldNotEqual(AnalysisProjectStatus.Fail);
        }

        [Test]
        public void ProjectStatusMessageIsEmpty()
        {
            (_projectStatus.Message ?? String.Empty).ShouldBeEmpty();
        }
    }
}
