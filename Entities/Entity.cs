using System;
using System.Collections.Generic;
using TextGame.Flow;

namespace TextGame.Entities
{
    public abstract class Entity
    {
        public string Name { get; protected set; }
        public bool IsKnown { get; set; }

        public Dictionary<Command, Func<ITakeAFrame, Character, ITakeAFrame>> ActionMap { get; set; } 
            = new Dictionary<Command, Func<ITakeAFrame, Character, ITakeAFrame>>();
    }

    public static class IEntityExtensions 
    {
        public static T AsHidden<T>(this T entity) where T : Entity
        {
            entity.IsKnown = true;
            return entity;
        }

        public static T AddHandler<T>(this T entity, Command command, Func<ITakeAFrame, Character, ITakeAFrame> handler) where T : Entity
        {
            entity.ActionMap.Add(command, handler);
            return entity;
        }

        public static ITakeAFrame HandleCommand(this Entity entity, Command command, ITakeAFrame currentFrame, Character character)
        {
            Func<ITakeAFrame, Character, ITakeAFrame> handler;
            var hasHandler = entity.ActionMap.TryGetValue(command, out handler);
            if(!hasHandler) return currentFrame;
            return handler.Invoke(currentFrame, character);
        }
    }

    public enum Command 
    {
        Examine,
        Search,
        Grab,
        Go
    }
}