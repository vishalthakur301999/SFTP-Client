using FileSystem.Core.Remote;
using System;

namespace ConsoleApp.Test
{

    class Program
    {
        static void Main(string[] args)
        {
            RemoteSystemSetting setting = new RemoteSystemSetting()
            {
                Host = "192.168.29.123",
                Port = 2222,
                UserName = "tester",
                Password = "password"
            };

            IRemoteFileSystemContext remote = new SftpRemoteFileSystem(setting);              
            /*to use SFTP remote = new SftpRemoteFileSystem(setting);*/

            remote.Connect();                                       /*establish connection*/
            remote.SetRootAsWorkingDirectory();                     /*set root as work directory*/
            //remote.DownloadFile("C:\\1.txt", "/files/test/1.txt");  /*download file*/
            remote.UploadFile("/Users/vishalthakur/hello.txt", "/hello.txt");    /*upload upload file*/

            /*others*/
            bool isConnected = remote.IsConnected();                /*check connection done or not*/
            remote.Disconnect();                                    /*stop connection*/
            remote.Dispose();                                       /*dispose*/
            //remote.DirectoryExists("/files/test/");                 /*check if directory exists or not*/
            //remote.CreateDirectoryIfNotExists("/files/test/");      /*create directory*/
            //remote.FileExists("/files/test/1.txt");                 /*check if file exists or not*/
            //remote.DeleteFileIfExists("/files/test/1.txt");         /*delete file*/
            //remote.SetWorkingDirectory("/files/test");              /*set other directory as root*/

            /*we don't have, but going to add some*/
            /*get all file names*/
            /*get all directory name*/
            /*download all files*/
            /*upload all files*/


            Console.WriteLine("Hello World!");
        }
    }
}
