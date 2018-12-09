using ResourceRobot.Common.Utility;
using ResourceRobot.Models.DO;
using SysInfoManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceRobot.DAL
{
    public class WhitelistDao
    {
        private static WhitelistDao _Instance = null;

        public static WhitelistDao Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new WhitelistDao();
                return _Instance;
            }
        }

        private WhitelistDao()
        {

        }
        
        public List<Whitelist> GetByAppkey(string appkey)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["connectStr"];
            string conStr = SysInfoManage.DENString(settings.ConnectionString);
            using (ResourceRobot.Common.DB.DbHelper db = new ResourceRobot.Common.DB.DbHelper(conStr))
            {
                List<Whitelist> whitelist = new List<Whitelist>();
                try
                {
                    string strCmd = @" SELECT `wid` FROM `whitelist` WHERE `appkey`=@appkey";

                    DataTable dt = db.GetDataSet(strCmd);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            Whitelist item = RowToObject(row);
                            whitelist.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log4Helper.Error(this.GetType(), String.Format("WhitelistDao.GetByAppkey.{0}", ex.Message), new Exception("error"));
                }

                return whitelist;
            }
        }

        #region Private

        private Whitelist RowToObject(DataRow row)
        {
            return new Whitelist
            {
                Wid = int.Parse(row["wid"].ToString()),
                AppName = row.IsNull("appName")?String.Empty:row["appName"].ToString(),
                MethodName = row.IsNull("methodName") ? String.Empty : row["methodName"].ToString(),
                NodeId =row.IsNull("NodeId")?0:int.Parse(row["NodeId"].ToString()),
                NoType=row.IsNull("NoType")?String.Empty: row["NoType"].ToString(),
                Appkey = row.IsNull("Appkey") ? String.Empty : row["Appkey"].ToString(),
                Discription =row.IsNull("Discription")?String.Empty:row["Discription"].ToString()
            };
        }

        #endregion

    }
}
