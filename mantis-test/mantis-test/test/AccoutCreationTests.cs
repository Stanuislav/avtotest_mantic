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
            AccountData account = new AccountData()
            {
                Name = "testusers1",
                Password = "qwerty1",
                Email = "testusers1@lacalhost.lacaldomain"
            };

            app.Registration.Register(account);
           
        }


        [OneTimeTearDown]
        public void restorConfig()
        {
            app.Ftp.RestorBackupFile("/config/config_inc.php");
        }
    }
}
