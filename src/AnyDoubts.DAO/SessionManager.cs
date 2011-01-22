using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;

namespace AnyDoubts.DAO
{
    public  class SessionManager : ISessionManager
    {
        private static IObjectContainer _Db4oManager = ContainerFactory.GetObjectContainerManager();

        public bool IsClosed()
        {
            return _Db4oManager.Ext().IsClosed();
        }

        public void Refresh(Object obj, int deep)
        {
            _Db4oManager.Ext().Refresh(obj, deep);
        }

        public void Commit()
        {
            _Db4oManager.Ext().Commit();
        }

        public void Dispose()
        {
            _Db4oManager.Ext().Dispose();
        }

        public void Close()
        {
            _Db4oManager.Ext().Close();
        }

        public void Rollback()
        {
            _Db4oManager.Ext().Rollback();
        }
    }
}
