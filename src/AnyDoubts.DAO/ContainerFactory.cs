using Db4objects.Db4o;
using System.Linq;
using Db4objects.Db4o.Linq;
using System.Web;
using System.IO;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace AnyDoubts.DAO
{
    public static class ContainerFactory
    {
        private static IObjectServer _server;

        public static IObjectServer CreateSession()
        {
            if (_server == null)
            {
                string dbPath = System.Configuration.ConfigurationManager.ConnectionStrings["ObjectStore"].ConnectionString;

                if (dbPath.Contains("|DataDirectoryWebApp|"))
                {
                    dbPath = dbPath.Replace("|DataDirectoryWebApp|", "");
                    string appDir = HttpContext.Current.Server.MapPath("~/App_Data/");
                    dbPath = Path.Combine(appDir, dbPath);
                }
                                
                _server = Db4oFactory.OpenServer(dbPath, 0);
            }

            return _server;
        }
    }
}