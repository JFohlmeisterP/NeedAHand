using System;

namespace NeedAHand.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; protected set;} = Guid.NewGuid();
    }
}