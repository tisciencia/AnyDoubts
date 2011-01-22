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
        private static IObjectContainer _current;

        public static IObjectContainer GetObjectContainerManager()
        {
            if (_current == null)
                _current = Db4oFactory.OpenFile("AnyDoubtsDB.db4o"); //_current = Db4oFactory.OpenFile(ConfigurationSettings.AppSettings["Db4o.path"]);
            return _current;
        }
    }
}