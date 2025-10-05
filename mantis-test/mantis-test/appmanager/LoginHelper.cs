using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_test
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper (ApplicationManager manager) : base(manager)
        {

        }


        public void Login(AccountData account)
        {
            if (isLoggedIn())
            {
                logout();
            }

            Type(By.Name("username"), account.Name);
            

            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();

        }

      

        private bool isLoggedIn()
        {
            return IsElementPresent(By.CssSelector("label hidden-xs label-default arrowed"));
        }




        private void logout()
        {
            if (isLoggedIn())
            {
                driver.FindElement(By.CssSelector("fa fa-sign-out ace-icon")).Click();
            }
        }
    }
}
