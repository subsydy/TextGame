using System;
using System.Collections.Generic;

namespace TextGame.Entities.Common
{
    public class Area : IHaveEntities, IEntity
    {
        private Area() { }

        public string Name { get; private set; }
        public bool IsKnown { get; set; }

        public List<IEntity> Entities { get; }= new List<IEntity>();
        public List<Portal> Portals { get; } = new List<Portal>();

        public static Area Named(string name) => new Area { Name = name };

        public Area WithEntity(IEntity entity)
        {
            Entities.Add(entity);
            return this;
        }

        public Area ContainingEntities(Func<IEnumerable<Item>> getEntities)
        {
            Entities.AddRange(getEntities());
            return this;
        }
    }
}