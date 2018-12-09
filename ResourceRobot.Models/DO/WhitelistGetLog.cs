using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceRobot.Models.DO
{
    public class WhitelistGetLog
    {
        public int Id { get; set; }
        public int Wid { get; set; }
        public string SdkVersion { get; set; }
        public string SdkPath { get; set; }
        public string SdkIP { get; set; }
        public DateTime DT { get; set; }
    }
}
