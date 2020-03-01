using System.Collections.Generic;

namespace TextGame.Entities.Common
{
    public class Area : Entity, IHaveEntities
    {
        private Area() { }

        // IHaveEntities
        public List<Entity> Entities { get; }= new List<Entity>();

        public static Area Named(string name) => new Area { Name = name };
    }
}