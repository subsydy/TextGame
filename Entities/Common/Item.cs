namespace TextGame.Entities.Common
{
    public class Item : IEntity
    {
        private Item() { }

        public string Name { get; private set; }
        public bool IsKnown { get; set; }

        public static Item Named(string name) 
        {
            return new Item 
            {
                Name = name,
                IsKnown = true
            };
        }
    }
}