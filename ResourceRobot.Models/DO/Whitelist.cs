using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceRobot.Models.DO
{
    public class Whitelist
    {
        public int Wid { get; set; }
        public string AppName { get; set; }
        public string MethodName { get; set; }
        public string Discription { get; set; }
        public int NodeId { get; set; }
        public string NoType { get; set; }
        public string Appkey { get; set; }
    }
}
