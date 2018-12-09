using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ResourceRobot.Common.DB
{
    public class DbHelper : IDisposable
    {
        private MySqlConnection Conn = null;
        private string _connectionString = String.Empty;

        public DbHelper(string connectionString)
        {
            _connectionString = connectionString;
            Conn = new MySqlConnection(connectionString);
            Conn.Open();
        }

        public DataRow GetDataRow(string cmdText, params MySqlParameter[] commandParameters)
        {
            DataRow dr = null;
            try
            {
                dr = MySqlHelper.ExecuteDataRow(_connectionString, cmdText, commandParameters);
                return dr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataSet(string cmdText, params MySqlParameter[] commandParameters)
        {
            DataSet retSet = null;
            try
            {
                retSet = MySqlHelper.ExecuteDataset(Conn, cmdText, commandParameters);
                if (retSet != null && retSet.Tables[0] != null && retSet.Tables[0].Rows.Count != 0)
                {
                    return retSet.Tables[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExecuteNonQuery(string cmdText, params MySqlParameter[] commandParameters)
        {
            try
            {
                return MySqlHelper.ExecuteNonQuery(Conn, cmdText, commandParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            if (Conn != null)
            {
                Conn.Close();
                Conn.Dispose();
            }
        }
    }
}
