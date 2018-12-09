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
    public class WhitelistClientDao
    {
        private static WhitelistClientDao _Instance = null;

        public static WhitelistClientDao Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new WhitelistClientDao();
                return _Instance;
            }
        }

        private WhitelistClientDao()
        {

        }

        public bool Create(WhitelistClient model)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["connectStr"];
            string conStr = SysInfoManage.DENString(settings.ConnectionString);
            using (ResourceRobot.Common.DB.DbHelper db = new ResourceRobot.Common.DB.DbHelper(conStr))
            {
                try
                {
                    string strCmd = @"INSERT INTO whitelist_client (
  wid,
  sdkversion,
  sdkpath,
  sdkip,
  registtime
) 
VALUES
  (
    @wid,
    @sdkversion,
    @sdkpath,
    @sdkip,
    @registtime
  ) 
  ON DUPLICATE KEY 
  UPDATE 
    sdkversion = @sdkversion,
    registtime = NOW()";

                    MySqlParameter[] paramters = new MySqlParameter[]
             {
                       new MySqlParameter("@wid",model.Wid),
                       new MySqlParameter("@sdkip",model.SdkIP),
                       new MySqlParameter("@sdkversion",model.SdkVersion),
                       new MySqlParameter("@sdkpath",model.SdkPath),
                       new MySqlParameter("@registtime",model.RegistTime)
             };

                    int count = db.ExecuteNonQuery(strCmd, paramters);
                    return count > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    Log4Helper.Error(this.GetType(), String.Format("WhitelistClientDao.Create.{0}", ex.Message), new Exception("error"));
                    return false;
                }
            }
        }
    }
}
