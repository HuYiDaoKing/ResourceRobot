using ResourceRobot.DAL;
using ResourceRobot.Models.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceRobot.BLL
{
    public class WhitelistService
    {
        private static WhitelistService _Instance = null;

        public static WhitelistService Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new WhitelistService();
                return _Instance;
            }
        }

        private WhitelistService()
        {

        }

        public List<Whitelist> GetByAppkey(string appkey)
        {
            return WhitelistDao.Instance.GetByAppkey(appkey);
        }
    }
}
