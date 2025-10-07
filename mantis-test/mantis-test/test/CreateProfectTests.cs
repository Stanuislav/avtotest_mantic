using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_test
{
    [TestFixture]
    public class CreateProfectTests: AuthTestBase
    {
        [Test]
        public async Task TestCreationProfectTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };


            ProjectData project = new ProjectData("testPgofectMantis7", "testPgofectMantisDesc7");

            int oldProfect = app.Project.GetProjectGount();

          
            Mantis.ProjectData[] oldProjcetDataAPI = await app.API.GetProject(account);

            app.Project.Creation(project);

            Mantis.ProjectData[] newProjectDataAPI = await app.API.GetProject(account);

            List<Mantis.ProjectData> oldProjcetDataAPIList = oldProjcetDataAPI.ToList();

            Mantis.ProjectData mantisProject = new Mantis.ProjectData
            {
                name = project.NameProfect
            };

            oldProjcetDataAPIList.Add(mantisProject);


            List<Mantis.ProjectData> newProjectDataAPIList = newProjectDataAPI.ToList();
            

            Assert.That(oldProfect + 1, Is.EqualTo(app.Project.GetProjectGount()));
            Assert.That(oldProjcetDataAPIList.Count, Is.EqualTo(newProjectDataAPIList.Count));
        }
    }
}
