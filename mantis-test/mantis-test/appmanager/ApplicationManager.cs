using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

namespace mantis_test
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected ManagementMenuHelper projectMenu;
        protected ProjectManagementHelper project;





        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.27.1/";
            loginHelper = new LoginHelper(this);
            projectMenu = new ManagementMenuHelper(this);
            project = new ProjectManagementHelper(this);

            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            Admin = new AdminHelpercs(this, baseURL);
            API = new APIHelper(this);
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.27.1/";
                app.Value = newInstance;
            }
            return app.Value;

        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
                driver = null;
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            //Assert.AreEqual("", verificationErrors.ToString());
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }

        public RegistrationHelper Registration { get;  set; }
        public FtpHelper Ftp {  get;  set; }

        public LoginHelper Auth
        {
            get { return loginHelper; }
        }

        public ManagementMenuHelper ProjectMenu
        {
            get { return projectMenu; }
        }
        public ProjectManagementHelper Project
        {
            get { return project; }
        }

        public AdminHelpercs Admin
        { get; set; }

        public APIHelper API
        { get; set; }
    }
}

     
