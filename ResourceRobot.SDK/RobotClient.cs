using ResourceRobot.Channels;
using ResourceRobot.Channels.Enums;
using ResourceRobot.SDK.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ResourceRobot.SDK
{
    public class RobotClient
    {
        internal static Utils util = new Utils();
        protected static EndpointAddress endpoint = new EndpointAddress(util.ServiceAddr);
        protected static NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
        protected static BasicHttpBinding wshttp = new BasicHttpBinding();

        /// <summary>
        /// 获取版本列表
        /// </summary>
        /// <param name="productid">产品id</param>
        /// <returns> List<ProductVersion> </returns>
        public static List<string> GetWhiteList(string appKey)
        {
            using (var fac = new ChannelFactory<IWhiteListService>(binding, endpoint))
            {
                var proxy = fac.CreateChannel();
                WhiteListRequest request = new WhiteListRequest();
                request.AppKey = appKey;
                request.SdkPath = util.SdkPath;
                request.SdkVersion = util.SdkVersion;
                request.Func = MethodBase.GetCurrentMethod().Name;

                RobotReponse<List<string>> response = proxy.GetWhiteList(request);
                if (response.StatusCode == (int)StatusCodeEnum.Success)
                {
                    return response.Data;
                }
                else
                {
                    throw new Exception(response.Message);
                }
            }
        }

    }
}
