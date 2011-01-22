using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyDoubts.Infra.Repository
{
    public interface ISessionManager
    {
        void Refresh(Object obj, int deep);

        void Close();

        void Commit();

        void Dispose();

        bool IsClosed();

        void Rollback();
    }
}
