using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;


namespace mantis_test
{
    [TestFixture]
    public class RemoveProjcetTests : AuthTestBase
    {
        [Test]
        public void TestRemoveProfect()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData project = new ProjectData("testPgofectMantis7");



            app.ProjectMenu.OpenPageProject();
            
           var ProjectListTable = app.Driver.FindElements(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr"));

            if (ProjectListTable.Count > 0)
            {
                app.API.CreateProjectApi(account, project);
            }


            int oldProfect = app.Project.GetProjectGount();

            app.Project.Remove(0);

            Assert.That(oldProfect - 1, Is.EqualTo(app.Project.GetProjectGount()));
        }
    }
}
