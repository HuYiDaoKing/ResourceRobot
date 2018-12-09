using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ResourceRobot.SDK.Common
{
    internal class Utils
    {
        public string EcsName { get; set; }
        public int ProcessId { get; set; }
        public string ProgramName { get; set; }
        public string SdkPath { get; set; }
        public string SdkVersion { get; set; }

        public string ServiceAddr { get; set; }

        public Utils()
        {
            EcsName = GetMachineName();
            ProcessId = GetCurrentProcessId();
            SdkPath = GetPath();
            ServiceAddr = RobotSettingManager.Settings["serviceaddr"];
        }
        

        #region Private

        private string GetMachineName()
        {
            try
            {
                return Dns.GetHostName();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private int GetCurrentProcessId()
        {
            try
            {
                Process CurrentProcess = Process.GetCurrentProcess();
                return CurrentProcess.Id;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        protected string GetPath()
        {
            Assembly callingAssembly = Assembly.GetCallingAssembly();
            return callingAssembly.Location;
        }

        protected string GetDllVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        #endregion
    }
}
