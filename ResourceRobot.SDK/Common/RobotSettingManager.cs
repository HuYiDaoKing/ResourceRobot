using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ResourceRobot.SDK.Common
{
    public class RobotSettingManager: Dictionary<string, string>
    {
        //初始配置
        private const string CONFIG_PATH = @"ResourceRobotSetting.xml";
        private const string SERVICE_ADDRESS_KEY = "serviceaddr";
        private const string SERVICE_ADDRESS_VALUE = @"net.tcp://172.16.0.194:3723/ResourceRobot.White.WcfService";

        private static RobotSettingManager _Settings = null;
        public static RobotSettingManager Settings
        {
            get
            {
                if (_Settings == null)
                    _Settings = new RobotSettingManager();
                return _Settings;
            }
        }

        private RobotSettingManager()
        {
            var configPath =Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory,CONFIG_PATH);
            if (!File.Exists(configPath))
            {
                XElement xelement = XElement.Load(configPath);
                var xes = from c in xelement.Elements("Setting")
                          select c;
                foreach (var xe in xes)
                {
                    string key = string.Empty;
                    string value = string.Empty;
                    key = xe.Attribute("name").Value;
                    value = xe.Attribute("value").Value;//暂不加密

                    if (!this.Keys.Contains(key))
                        this.Add(key, value);
                }
            }
            else
            {
                string key = SERVICE_ADDRESS_KEY;
                string value = SERVICE_ADDRESS_VALUE;
                if (!this.Keys.Contains(key))
                    this.Add(key, value);
            }
        }

        public string this[string key]
        {
            get
            {
                if (!this.ContainsKey(key))
                    return String.Empty;
                return base[key];
            }
            set
            {
                base[key] = value;
            }
        }

        public static bool GetBoolValue(string key)
        {
            bool value = false;
            bool.TryParse(Settings[key], out value);
            return value;
        }

        public static int GetIntValue(string key)
        {
            int value = 0;
            int.TryParse(Settings[key], out value);
            return value;
        }

    }
}
