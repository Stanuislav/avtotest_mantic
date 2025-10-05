using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace mantis_test
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }

        [SetUp]
        public void OpenPageProject ()
        {
            driver.FindElement(By.XPath("//a[@href='/mantisbt-2.27.1/manage_overview_page.php']")).Click();
            driver.FindElement(By.XPath("//a[@href='/mantisbt-2.27.1/manage_proj_page.php']")).Click();
        }
    }
}
