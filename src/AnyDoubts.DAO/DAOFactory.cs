using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnyDoubts.Domain.Repositoy;

namespace AnyDoubts.DAO
{
    public static class DAOFactory
    {
        public static T Get<T>()
            where T : IRepository
        {
            return Instances<T>.GetConcretRepository(typeof(T));
        }

        private class Instances<T>
        {
            public static T GetConcretRepository(Type typeInterfaceRepository)
            {
                foreach (Type type in typeof(DAOFactory).Assembly.GetTypes())
                {
                    if (typeInterfaceRepository.IsAssignableFrom(type))
                        return (T)Activator.CreateInstance(type);
                }
                return default(T);
            }
        }
    }
}
