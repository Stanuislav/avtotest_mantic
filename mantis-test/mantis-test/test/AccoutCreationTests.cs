using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mantis_test;
using NUnit.Framework;

namespace mantis_test
{
    [TestFixture]
    public class AccoutCreationTests : TestBase
    {
        [OneTimeSetUp]
        public void setUpCongig()
        {
   


            app.Ftp.BackupFile("/config/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config/config_inc.php", localFile);
            }
            

        }


        [Test]
        public void TestAccountRegistration()
        {

            List<AccountData> accounts = app.Admin.GetAllAccounts();
            AccountData account = new AccountData()
            {
                Name = "testusers2",
                Password = "qwerty2",
                Email = "testusers2@lacalhost.lacaldomain"
            };
            AccountData existiongAccount = accounts.Find(x => x.Name == account.Name);
            if (existiongAccount != null)
            {
                app.Admin.DeleteAccount(existiongAccount);
            }
           


            app.Registration.Register(account);
           
        }


        [OneTimeTearDown]
        public void restorConfig()
        {
            app.Ftp.RestorBackupFile("/config/config_inc.php");
        }
    }
}
