using System;
using FileSystem.Core.Remote;
using Renci.SshNet;
using sftpapi.Helpers;
using sftpapi.Model;

namespace sftpapi.Services
{
	public class SftpRemoteFileSystemService : SftpContext
    {
        private string _serverDetails;

        public SftpRemoteFileSystemService(RemoteSystemSetting setting)
        {
            _serverDetails = FtpHelper.ServerDetails(setting.Host, setting.Port.ToString(), setting.UserName, setting.Type);
            var connectionInfo = new Renci.SshNet.ConnectionInfo(setting.Host, setting.Port, setting.UserName, new PasswordAuthenticationMethod(setting.UserName, setting.Password));
            SftpClient = new SftpClient(connectionInfo);
        }

        public override string ServerDetails()
        {
            return _serverDetails;
        }
    }
}

