using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ServicoCore.EntityBase.EntityBase
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }

        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            var CompareTo = obj as EntityBase;

            if (ReferenceEquals(this, CompareTo)) return true;
            if (ReferenceEquals(null, obj)) return false;

            return Id.Equals(CompareTo);
        }

        public static bool operator ==(EntityBase a, EntityBase b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EntityBase a, EntityBase b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [id= {Id}]";
        }
    }
}
