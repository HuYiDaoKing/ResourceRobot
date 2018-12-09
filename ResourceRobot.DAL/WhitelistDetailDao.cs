using MySql.Data.MySqlClient;
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
    public class WhitelistDetailDao
    {
        private static WhitelistDetailDao _Instance = null;

        public static WhitelistDetailDao Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new WhitelistDetailDao();
                return _Instance;
            }
        }

        private WhitelistDetailDao()
        {

        }

        public List<WhitelistDetail> GetByAppkey(int wid)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["connectStr"];
            string conStr = SysInfoManage.DENString(settings.ConnectionString);
            using (ResourceRobot.Common.DB.DbHelper db = new ResourceRobot.Common.DB.DbHelper(conStr))
            {
                List<WhitelistDetail> whitelistDetails = new List<WhitelistDetail>();
                try
                {
                    string strCmd = @" SELECT * FROM whitelist_detail WHERE wid=@wid";
                    MySqlParameter[] paramters = new MySqlParameter[]
                {
                       new MySqlParameter("@wid",wid)
                };

                    DataRow dr = db.GetDataRow(strCmd, paramters);
                    DataTable dt = db.GetDataSet(strCmd);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            WhitelistDetail item= RowToObject(row);
                            whitelistDetails.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log4Helper.Error(this.GetType(), String.Format("WhitelistDao.GetByAppkey.{0}", ex.Message), new Exception("error"));
                }

                return whitelistDetails;
            }
        }

        #region Private

        private WhitelistDetail RowToObject(DataRow row)
        {
            return new WhitelistDetail
            {
                Id = row.IsNull("id") ? 0 : int.Parse(row["id"].ToString()),
                Wid = row.IsNull("wid") ? 0 : int.Parse(row["wid"].ToString()),
                IP = row.IsNull("ip") ? String.Empty : row["ip"].ToString()
            };
        }

        #endregion
    }
}
