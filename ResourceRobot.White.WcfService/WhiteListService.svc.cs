using ResourceRobot.Channels;
using ResourceRobot.Channels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ResourceRobot.White.WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class WhiteListService : IWhiteListService
    {
        /// <summary>
        /// 获取ip白名单
        /// </summary>
        /// <param name="appkey"></param>
        /// <param name="sdkversion"></param>
        /// <param name="sdkpath"></param>
        /// <returns></returns>
        public RobotReponse<List<string>> GetWhiteList(WhiteListRequest req)
        {
            //Test
            RobotReponse<List<string>> robotResult = new RobotReponse<List<string>>();

            List<string> ips = new List<string>();
            ips.Add("127.0.0.1");
            robotResult = new RobotReponse<List<string>>
            {
                StatusCode = (int)StatusCodeEnum.Success,
                Message= StatusCodeEnum.ParameterError.GetEnumText(),
                Data=ips
            };
            return robotResult;
        }

        /// <summary>
        /// 白名单监听
        /// </summary>
        /// <param name="appkey"></param>
        /// <param name="sdkversion"></param>
        /// <param name="sdkpath"></param>
        /// <returns></returns>
        public RobotReponse<bool> RegistWhiteListClient(RegistWhiteListRequest req)
        {
            return new RobotReponse<bool>();
        }

        /// <summary>
        /// 异常报告
        /// </summary>
        /// <param name="appkey"></param>
        /// <param name="sdkversion"></param>
        /// <param name="sdkpath"></param>
        /// <param name="exceptionInfo"></param>
        /// <returns></returns>
        public RobotReponse<bool> ReportException(ReportExceptionRequest req)
        {
            return new RobotReponse<bool>();
        }
    }
}
