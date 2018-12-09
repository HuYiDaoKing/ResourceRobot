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
    public class WhitelistGetLogDao
    {
        private static WhitelistGetLogDao _Instance = null;

        public static WhitelistGetLogDao Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new WhitelistGetLogDao();
                return _Instance;
            }
        }

        private WhitelistGetLogDao()
        {

        }

        public bool Create(WhitelistGetLog model)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["connectStr"];
            string conStr = SysInfoManage.DENString(settings.ConnectionString);
            using (ResourceRobot.Common.DB.DbHelper db = new ResourceRobot.Common.DB.DbHelper(conStr))
            {
                try
                {
                    string strCmd = @"INSERT INTO `whitelist_get_log` (
  `wid`,
  `sdkip`,
  `sdkversion`,
  `sdkpath`,
  `dt`
) 
VALUES
  (
    @wid,
    @sdkip,
    @sdkversion,
    @sdkpath,
    NOW()
  )";

                    MySqlParameter[] paramters = new MySqlParameter[]
             {
                       new MySqlParameter("@wid",model.Wid),
                       new MySqlParameter("@sdkip",model.SdkIP),
                       new MySqlParameter("@sdkversion",model.SdkVersion),
                       new MySqlParameter("@sdkpath",model.SdkPath),
                       new MySqlParameter("@dt",model.DT)
             };

                    int count = db.ExecuteNonQuery(strCmd, paramters);
                    return count > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    Log4Helper.Error(this.GetType(), String.Format("WhitelistGetLogDao.Create.{0}", ex.Message), new Exception("error"));
                    return false;
                }
            }
        }
    }
}
