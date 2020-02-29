namespace TextGame.Entities
{
    public class Item 
    {
        private Item() { }

        public string Name { get; private set; }

        public Item Named(string name) 
        {
            return new Item { Name = name };
        }
    }
}