# MateCat.Net
![MateCat](https://github.com/IvAlex1986/MateCat.Net/blob/master/MateCatLogo.jpg =250x)
<br />
**MateCat.Net** это wrapper написанный для .NET, который работает с онлайн CAT приложением [MateCat](https://www.matecat.com/). Официальную документацию по использованию API можно посмотреть [here](https://www.matecat.com/api/docs)

#Installation
Installation is performed via NuGet [package](https://www.nuget.org/packages/MateCat.Net).
```
PM> Install-Package MateCat.Net
```

#Example

Создание проекта MateCat:
```c#
using MateCat.Net.Enums;
using MateCat.Net.Models;
using System.Collections.Generic;

namespace MateCat.Net.Example
{
    public class CreateProjectExample
    {
        private readonly MateCatApi _mateCatApi = new MateCatApi();

        public Project RunCreateProjectExample()
        {
            List<ProjectFile> projectFiles = new List<ProjectFile> { new ProjectFile(@"C:\Temp\Example.txt") };
            Project project = _mateCatApi.CreateProject(projectFiles, "TestProjectName", "en-EN", "ru-RU", SupportedSubject.Internet);
            return project;
        }
    }
}
```

Смена пароля проекта MateCat:
```c#
using MateCat.Net.Models;

namespace MateCat.Net.Example
{
    public class ChangeProjectPasswordExample
    {
        private readonly MateCatApi _mateCatApi = new MateCatApi();

        public Project RunChangeProjectPasswordExample()
        {
            Project project = new CreateProjectExample().RunCreateProjectExample();
            project = _mateCatApi.ChangeProjectPassword(project.Id, project.Password, "MY_NEW_PASSWORD");
            return project;
        }
    }
}
```

Получение статуса проекта MateCat:
```c#
using MateCat.Net.Models;

namespace MateCat.Net.Example
{
    public class GetProjectStatusExample
    {
        private readonly MateCatApi _mateCatApi = new MateCatApi();

        public ProjectStatus RunGetProjectStatusExample()
        {
            Project project = new CreateProjectExample().RunCreateProjectExample();
            ProjectStatus projectStatus = _mateCatApi.GetProjectStatus(project.Id, project.Password);
            return projectStatus;
        }
    }
}
```

#License
This project is licensed under the [MIT license](https://github.com/IvAlex1986/MateCat.Net/blob/master/LICENSE).