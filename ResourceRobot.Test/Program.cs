using ResourceRobot.SDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceRobot.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestA();
            TestResourceRobotService();
            //SdkTest();
        }

        public static void TestA()
        {
            using (SR_PluginsAService.BusinessAServiceClient client = new SR_PluginsAService.BusinessAServiceClient())
            {
                string s = client.GetData(1);
                Console.WriteLine("A:" + s);
            }
        }

        public static void TestResourceRobotService()
        {
            using (SR_ResourceRobotWhiteListService.WhiteListServiceClient client = new SR_ResourceRobotWhiteListService.WhiteListServiceClient())
            {
                /*
                 * public string AppKey { get; set; }
        public string SdkVersion { get; set; }
        public string SdkPath { get; set; }
        public string Func { get; set; }
                 */
                Channels.WhiteListRequest req = new Channels.WhiteListRequest
                {
                    AppKey = "123",
                    SdkVersion="v1.0",
                    SdkPath= Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory,"a.sdk"),
                    Func=""
                };
                Channels.RobotReponse<List<string>> robotResults =client.GetWhiteList(req);
                if (robotResults != null)
                {
                    foreach (string ip in robotResults.Data)
                    {
                        Console.WriteLine(ip);
                    }
                }

                Console.ReadLine();
            }
        }


        public static void SdkTest()
        {
           string CONFIG_PATH = @"ResourceRobotSetting.xml";
           var configPath =Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, CONFIG_PATH);


            string appkey = "123";
            //var dbConnInfo = ETCClient.GetMasterConnectionByDeploy(deployname);
            RobotClient.GetWhiteList(appkey);
        }

    }
}
