namespace TextGame.Entities.Common
{
    public class Portal : IEntity
    {
        private Portal() { }

        // IEntity
        public string Name { get; private set; }
        public bool IsKnown { get; set; }

        public IEntity ToArea {get; private set;}

        public static Portal To(Area toArea)
        {
            return new Portal 
            { 
                Name    = $"portal to {toArea.Name}",
                ToArea  = toArea,
                IsKnown = true,
            };
        }
    }
}