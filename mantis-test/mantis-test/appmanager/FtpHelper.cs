using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.FtpClient;

namespace mantis_test
{
    public class FtpHelper : HelperBase
    {

        private FtpClient client;


        public FtpHelper(ApplicationManager mager) : base(mager)
        {
            Console.WriteLine("FtpHelper constructor called");

            try
            {
                client = new FtpClient();
                client.Host = "localhost";
                client.Credentials = new System.Net.NetworkCredential("mantis", "mantis");
                client.Connect();
                Console.WriteLine("FTP connected successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FTP connection failed: {ex.Message}");
                throw;
            }
        }

        public void BackupFile(String path)
        {
            String backUpPath = path + ".bak";
            if (client.FileExists(backUpPath))
            {
                return;
            }
            client.Rename(path, backUpPath);
        }


        public void RestorBackupFile(String path)
        {
            String backUpPath = path + ".bak";
            if (!client.FileExists(backUpPath))
            {
                return;
            }
            if (client.FileExists(path))
            {
                client.DeleteFile(path);
            }
            client.Rename(backUpPath, path );
        }

        public void Upload(String path, Stream localFile)
        {
            if (client.FileExists(path))
            {
                client.DeleteFile(path);
            }

            using (Stream ftpStream = client.OpenWrite(path))
            {
                byte[] buffer = new byte[8 * 1024];
                int count = localFile.Read(buffer, 0, buffer.Length);
                while (count > 0)
                {
                    ftpStream.Write(buffer, 0, count);
                    count = localFile.Read(buffer, 0, buffer.Length);
                }    
            }
        }



    }
}
