using Db4objects.Db4o;
using System.Linq;
using Db4objects.Db4o.Linq;
using System.Web;
using System.IO;
using System;
using System.Collections.Generic;

namespace AnyDoubts.Infra.Repository
{
    public static class ContainerFactory
    {
        private static IObjectContainer _current;

        public static IObjectContainer GetObjectContainerManager()
        {
            if (_current == null)
                _current = Db4oFactory.OpenFile("AnyDoubts.db4o");   //_objectContainer = Db4oFactory.OpenFile(ConfigurationSettings.AppSettings["db4o.path"]);
            return _current;
        }
    }
}