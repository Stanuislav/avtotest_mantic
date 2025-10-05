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
            app.Project.Creation();

        }
    }
}
