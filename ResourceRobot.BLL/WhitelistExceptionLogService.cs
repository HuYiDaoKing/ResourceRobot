using ResourceRobot.DAL;
using ResourceRobot.Models.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceRobot.BLL
{
    public class WhitelistExceptionLogService
    {
        private static WhitelistExceptionLogService _Instance = null;

        public static WhitelistExceptionLogService Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new WhitelistExceptionLogService();
                return _Instance;
            }
        }

        private WhitelistExceptionLogService()
        {

        }

        public bool Create(WhitelistExceptionLog model)
        {
            return WhitelistExceptionLogDao.Instance.Create(model);
        }

    }
}
