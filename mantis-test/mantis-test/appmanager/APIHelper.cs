using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Text.RegularExpressions;

namespace mantis_test
{
    public class APIHelper : HelperBase
    {


        public APIHelper(ApplicationManager manager) : base(manager) {
        }

        public async Task<string> CreateNewIssueAsync(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client =  new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            var result = await client.mc_issue_addAsync(account.Name, account.Password, issue);
           
            Console.WriteLine("test0" + result);
            return result;
        }
    }
}
