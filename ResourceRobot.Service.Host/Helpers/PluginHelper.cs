using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ResourceRobot.Service.Host.Helpers
{
    public class PluginHelper
    {
        //查找所有插件的路径
        public static List<string> Find()
        {
            List<string> pluginpath = new List<string>();
            try
            {
                //获取程序的基目录
                string path = AppDomain.CurrentDomain.BaseDirectory;
                //合并路径，指向插件所在目录。
                path = Path.Combine(path, "Plugins");
                foreach (string filename in Directory.GetFiles(path, "*.dll"))
                {
                    pluginpath.Add(filename);
                }
            }
            catch (Exception ex)
            {
                //Console.Write(ex.Message);
                throw ex;
            }
            return pluginpath;
        }
        //载入插件，在Assembly中查找类型
        public static object LoadObject(Assembly asm, string className, string interfacename
                        , object[] param)
        {
            try
            {
                //取得className的类型
                Type t = asm.GetType(className);
                if (t == null
                    || !t.IsClass
                    || !t.IsPublic
                    || t.IsAbstract
                    || t.GetInterface(interfacename) == null
                   )
                {
                    return null;
                }
                //创建对象
                Object o = Activator.CreateInstance(t, param);
                if (o == null)
                {
                    //创建失败，返回null
                    return null;
                }
                return o;
            }
            catch
            {
                return null;
            }
        }
    }
}
