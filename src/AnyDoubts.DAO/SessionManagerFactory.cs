using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnyDoubts.Domain.Repository;

namespace AnyDoubts.DAO
{
    public static class SessionManagerFactory
    {
        private static ISessionManager _instance;

        public static ISessionManager GetInstance()
        {
            if (_instance == null)
                _instance = new SessionManager();
            return _instance;
        }
    }
}
