using System;
using System.Collections.Generic;

namespace TextGame.Entities 
{
    public class Area : IHaveItems
    {
        private Area() { }

        public string Name { get; private set; }
        public List<Item> Items { get; } = new List<Item>();
        public List<Portal> Portals { get; } = new List<Portal>();

        public static Area Named(string name) => new Area { Name = name };

        public Area WithItem(Item item)
        {
            Items.Add(item);
            return this;
        }

        public Area WithItems(Func<IEnumerable<Item>> item)
        {
            Items.AddRange(item());
            return this;
        }
    }
}