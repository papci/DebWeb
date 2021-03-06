using System.Threading.Tasks;
using static DebWeb.EnvSettings;

namespace DebWeb
{
    public class SystemdTemplate : FileTemplate
    {
        protected const string template
        =
        @"[Unit]
        Description={projectName} - Auto generated by DebWeb

        [Service]
        WorkingDirectory={projectPath}
        ExecStart={projectCommand}
        Restart=always
        RestartSec=10  
        SyslogIdentifier={projectName}
        User={userName}
    
        [Install]
        WantedBy=multi-user.target";

        public SystemdTemplate(SystemSettings sSettings, AppSettings settings) : base(sSettings, settings)
        {
        }

        public override string GetFilePath()
        {
            return $"{systemSettings.SystemdPath}/{appSettings.ProjectName}.service";
        }

        public override string GetTemplate()
        {

            return template
             .Replace("{projectName}", appSettings.ProjectName)
             .Replace("{projectPath}", appSettings.ProjectPath)
             .Replace("{projectCommand}", appSettings.ProjetCommand)
             .Replace("{userName}", appSettings.UserName);

        }

       
    }
}