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
        public void TestCreationProfectTest()
        {
            ProjectData project = new ProjectData("testPgofectMantis1", "testPgofectMantisDesc1");

            int oldProfect = app.Project.GetProjectGount();

            app.Project.Creation(project);

            Assert.That(oldProfect + 1, Is.EqualTo(app.Project.GetProjectGount()));
        }
    }
}
