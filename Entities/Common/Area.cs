using System.Collections.Generic;

namespace TextGame.Entities.Common
{
    public class Area : IHaveEntities, IEntity
    {
        private Area() { }

        // IEntity
        public string Name { get; private set; }
        public bool IsKnown { get; set; }

        // IHaveEntities
        public List<IEntity> Entities { get; }= new List<IEntity>();

        public static Area Named(string name) => new Area { Name = name };
    }
}