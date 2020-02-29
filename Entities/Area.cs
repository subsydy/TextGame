using System.Collections.Generic;

namespace TextGame.Entities 
{
    public class Area 
    {
        private Area() { }

        public string Name { get; private set; }
        public List<string> Items { get; } = new List<string>();
        public List<Portal> Portals { get; } = new List<Portal>();

        public static Area Named(string name) => new Area { Name = name };
    }

    public static class AreaExtensions 
    {
        public static Area WithItem(this Area area, string item)
        {
            area.Items.Add(item);
            return area;
        }
    }
}