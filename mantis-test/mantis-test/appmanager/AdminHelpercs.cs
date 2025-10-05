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
    public class AdminHelpercs : HelperBase
    {
        private string baseUrl;

        public AdminHelpercs(ApplicationManager manager, string baseUrl) : base(manager) {
            this.baseUrl = baseUrl;
        }


        public List<AccountData> GetAccounts()
        {
            return null;
        }

        public void DeleteAccount(AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_edit_page.php?user_id="+account.Id;
            driver.FindElement(By.XPath("//button[@formaction='manage_user_delete.php']")).Click();
            driver.FindElement(By.CssSelector(".btn.btn-primary.btn-white.btn-round")).Click();
        }

        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_page.php";
            IList<IWebElement> rows = driver.FindElements(By.XPath("//tbody/tr[position() > 1]"));
            foreach (IWebElement row in rows)
            {
                IWebElement link = row.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;

                accounts.Add(new AccountData()
                {
                    Name = name,
                    Id = id,
                });
            }
            return accounts;
        }

        private IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = baseUrl + "/login_page.php";
            driver.FindElement(By.Name("username")).SendKeys("administrator");
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            driver.FindElement(By.Name("password")).SendKeys("root");
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            return driver;
        }
    }
}
