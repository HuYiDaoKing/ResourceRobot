using ResourceRobot.Service.Host.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ResourceRobot.Service.Host
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //1.寻找wcf.dll
            List<string> pluginpaths = PluginHelper.Find();

            //2.遍历并解析
            foreach (string filename in pluginpaths)
            {
                try
                {
                    //获取文件名
                    string asmfile = filename;
                    string asmname = Path.GetFileNameWithoutExtension(asmfile);
                    if (asmname != string.Empty)
                    {
                        //利用反射,构造DLL文件的实例
                        Assembly asm = Assembly.LoadFile(asmfile);

                        //利用反射,从程序集(DLL)中,提取类,并把此类实例化
                        Type[] t = asm.GetExportedTypes();
                        foreach (Type type in t)
                        {
                            //3.注册
                            ServiceHost host = new ServiceHost(type);
                            if (host != null)
                            {
                                host.Open();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
        }

        protected override void OnStop()
        {
        }
    }
}
