using FileSystem.Core.Remote;
using Renci.SshNet;

namespace ConsoleApp.Test
{
    public class SftpRemoteFileSystem : SftpContext
    {
        private string _serverDetails;

        public SftpRemoteFileSystem(RemoteSystemSetting setting)
        {
            _serverDetails = FtpHelper.ServerDetails(setting.Host, setting.Port.ToString(), setting.UserName, setting.Type);
            var connectionInfo = new ConnectionInfo(setting.Host, setting.Port, setting.UserName, new PasswordAuthenticationMethod(setting.UserName, setting.Password));
            SftpClient = new SftpClient(connectionInfo);
        }

        public override string ServerDetails()
        {
            return _serverDetails;
        }
    }
}
