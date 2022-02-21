using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FileSystem.Core.Remote;
using sftpapi.Model;
using sftpapi.Services;
using System.Xml.Linq;

namespace sftpapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadToSFTPController : ControllerBase
    {
        // GET: api/UploadToSFTP
        [HttpGet]
        public IEnumerable<string> Get()
        {
            RemoteSystemSetting setting = new RemoteSystemSetting()
            {
                Host = "192.168.29.123",
                Port = 2222,
                UserName = "tester",
                Password = "password"
            };

            new XDocument(
                new XElement("root",
                    new XElement("Node", "Value")
                )
            ).Save("test.xml");


            IRemoteFileSystemContext remote = new SftpRemoteFileSystemService(setting);
            /*to use SFTP remote = new SftpRemoteFileSystem(setting);*/

            remote.Connect();                                       /*establish connection*/
            remote.SetRootAsWorkingDirectory();                     /*set root as work directory*/
            remote.UploadFile("test.xml", "/test.xml");    /*upload upload file*/
            /*others*/
            bool isConnected = remote.IsConnected();                /*check connection done or not*/
            remote.Disconnect();                                    /*stop connection*/
            remote.Dispose();
            System.IO.File.Delete("text.xml");/*dispose*/
            return new string[] { "Uploaded" };
        }
    }
}
