using ResourceRobot.DAL;
using ResourceRobot.Models.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceRobot.BLL
{
    public class WhitelistGetLogService
    {
        private static WhitelistGetLogService _Instance = null;

        public static WhitelistGetLogService Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new WhitelistGetLogService();
                return _Instance;
            }
        }

        private WhitelistGetLogService()
        {

        }

        public bool Create(WhitelistGetLog model)
        {
            return WhitelistGetLogDao.Instance.Create(model);
        }
    }
}
