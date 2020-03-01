using System;
using System.Collections.Generic;
using TextGame.Flow;

namespace TextGame.Entities
{
    public abstract class Entity
    {
        public string Name { get; protected set; }
        public bool IsKnown { get; set; }

        public Dictionary<Action, Func<ITakeAFrame>> ActionMap { get; set; }
    }

    public static class IEntityExtensions 
    {
        public static T AsHidden<T>(this T entity) where T : Entity
        {
            entity.IsKnown = true;
            return entity;
        }
    }

    public enum Action 
    {
        Examine,
        Search,
        Grab,
        Go
    }
}