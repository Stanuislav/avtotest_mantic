using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_test
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager namager) : base(namager)
        {

        }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SumbitRegistration();
        }

        private void OpenRegistrationForm()
        {
            driver.FindElement(By.CssSelector(".back-to-login-link.pull-left")).Click();
        }

        private void SumbitRegistration()
        {
            driver.FindElement(By.CssSelector(".bigger-110")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.27.1/";
        }
    }
}
