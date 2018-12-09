using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ResourceRobot.Channels
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IWhiteListService
    {
        // TODO: 在此添加您的服务操作
        [OperationContract]
        RobotReponse<List<string>>  GetWhiteList(WhiteListRequest req);

        [OperationContract]
        RobotReponse<bool> RegistWhiteListClient(RegistWhiteListRequest req);

        [OperationContract]
        RobotReponse<bool> ReportException(ReportExceptionRequest req);
    }
}
