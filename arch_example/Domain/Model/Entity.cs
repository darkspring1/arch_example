using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public abstract class Entity<TState>
    {
        internal TState State { get; private set; }

        protected Entity(TState state)
        {
            State = state;
        }

        private Entity() { }


        protected static void ThrowIfArgumentNull<T>(T arg, string argName) where T : class
        {
            if (arg == null)
            {
                throw new ArgumentNullException(argName);
            }
        }

    }
}
