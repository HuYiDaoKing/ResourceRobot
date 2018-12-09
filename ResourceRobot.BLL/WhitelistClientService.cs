using ResourceRobot.DAL;
using ResourceRobot.Models.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceRobot.BLL
{
    public class WhitelistClientService
    {
        private static WhitelistClientService _Instance = null;

        public static WhitelistClientService Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new WhitelistClientService();
                return _Instance;
            }
        }

        private WhitelistClientService()
        {

        }

        public bool Create(WhitelistClient model)
        {
            return WhitelistClientDao.Instance.Create(model);
        }

    }
}
