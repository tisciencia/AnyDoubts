using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using AnyDoubts.Domain.Repository;

namespace AnyDoubts.DAO
{
    public class SessionManager : ISessionManager
    {
        private static IObjectContainer _Db4oManager;

        public SessionManager()
        {
            _Db4oManager = ContainerFactory.CreateSession().OpenClient();
        }

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
            _Db4oManager = null;
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
