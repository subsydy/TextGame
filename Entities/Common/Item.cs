namespace TextGame.Entities.Common
{
    public class Item : Entity
    {
        private Item() { }

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