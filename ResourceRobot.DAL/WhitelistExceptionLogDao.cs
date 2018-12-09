using MySql.Data.MySqlClient;
using ResourceRobot.Common.Utility;
using ResourceRobot.Models.DO;
using SysInfoManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceRobot.DAL
{
    public class WhitelistExceptionLogDao
    {
        private static WhitelistExceptionLogDao _Instance = null;

        public static WhitelistExceptionLogDao Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new WhitelistExceptionLogDao();
                return _Instance;
            }
        }

        private WhitelistExceptionLogDao()
        {

        }

        public bool Create(WhitelistExceptionLog model)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["connectStr"];
            string conStr = SysInfoManage.DENString(settings.ConnectionString);
            using (ResourceRobot.Common.DB.DbHelper db = new ResourceRobot.Common.DB.DbHelper(conStr))
            {
                try
                {
                    string strCmd = @"INSERT INTO `whitelist_exception_log` (
  `wid`,
  `sdkversion`,
  `sdkpath`,
  `sdkip`,
  `exceptioninfo`,
  `dt`
) 
VALUES
  (
    @wid,
    @sdkversion,
    @sdkpath,
    @sdkip,
    @exceptioninfo,
    @dt
  ) ;
";

                    MySqlParameter[] paramters = new MySqlParameter[]
             {
                       new MySqlParameter("@wid",model.Wid),
                       new MySqlParameter("@sdkip",model.SdkIP),
                       new MySqlParameter("@sdkversion",model.SdkVersion),
                       new MySqlParameter("@sdkpath",model.SdkPath),
                       new MySqlParameter("@exceptioninfo",model.ExceptionInfo),
                       new MySqlParameter("@dt",model.DT)
             };

                    int count = db.ExecuteNonQuery(strCmd, paramters);
                    return count > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    Log4Helper.Error(this.GetType(), String.Format("WhitelistExceptionLogDao.Create.{0}", ex.Message), new Exception("error"));
                    return false;
                }
            }
        }


    }
}
