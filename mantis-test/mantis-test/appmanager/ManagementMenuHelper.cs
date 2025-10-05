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
            driver.FindElement(By.CssSelector("fa fa-gears menu-icon")).Click();
            driver.FindElements(By.CssSelector("nav nav-tabs padding-18"))[2].Click();
        }
    }
}
