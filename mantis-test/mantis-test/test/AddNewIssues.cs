using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_test
{
    [TestFixture]
    public class AddNewIssues : TestBase
    {
        [Test]
        public async Task AddNewIssue()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };


            //Тут нужно получать вначале список проектов всех, если нет создавать
            ProjectData project = new ProjectData()
            {
                Id = "7"
            };

            IssueData issue = new IssueData()
            {
                Summary = "sone test",
                Description = "some long test",
                Category = "General"

            };

            await app.API.CreateNewIssueAsync(account, project, issue);
               
        }

       


    }
}
