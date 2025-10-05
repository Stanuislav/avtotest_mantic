using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_test
{
    [TestFixture]
    public class RemoveProjcetTests : AuthTestBase
    {
        [Test]
        public void TestRemoveProfect()
        {
            int oldProfect = app.Project.GetProjectGount();

            app.Project.Remove(0);

            Assert.That(oldProfect - 1, Is.EqualTo(app.Project.GetProjectGount()));
        }
    }
}
