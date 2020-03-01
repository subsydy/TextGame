namespace TextGame.Entities
{
    public class Item 
    {
        private Item() { }

        public string Name { get; private set; }
        public bool IsKnown { get; private set; } = false;

        public static Item Named(string name) 
        {
            return new Item { Name = name };
        }

        public Item IsHidden()
        {
            IsKnown = false;
            return this;
        }
    }
}