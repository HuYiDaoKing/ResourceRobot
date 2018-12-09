using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceRobot.Channels
{
    public class RobotRequest
    {
        public string AppKey { get; set; }
        public string SdkVersion { get; set; }
        public string SdkPath { get; set; }
        public string Func { get; set; }
    }

    public class WhiteListRequest : RobotRequest
    {

    }

    public class RegistWhiteListRequest : RobotRequest
    {

    }

    public class ReportExceptionRequest : RobotRequest
    {

    }

}
