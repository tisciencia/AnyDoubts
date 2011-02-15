using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyDoubts.Domain.Model
{
    public abstract class EntityBase
    {
        public abstract override int GetHashCode();

        public override sealed bool Equals(object obj)
        {
            EntityBase compareTo = obj as EntityBase;

            return ((compareTo != null) && this.GetHashCode().Equals(compareTo.GetHashCode()));
        }
    }
}
