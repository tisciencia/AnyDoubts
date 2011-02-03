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
        private static IObjectContainer _instance;
        public static IObjectContainer GetInstance()
        {            
            if (_instance == null)
            {
                string dbPath = System.Configuration.ConfigurationManager.ConnectionStrings["ObjectStore"].ConnectionString;

                if (dbPath.Contains("|DataDirectoryWebApp|"))
                {
                    dbPath = dbPath.Replace("|DataDirectoryWebApp|", "");
                    string appDir = HttpContext.Current.Server.MapPath("~/App_Data/");
                    dbPath = Path.Combine(appDir, dbPath);
                }

                _instance = Db4oFactory.OpenFile(Db4oFactory.NewConfiguration(), dbPath);
            }

            return _instance;
        }
    }
}