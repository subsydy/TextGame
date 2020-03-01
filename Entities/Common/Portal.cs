namespace TextGame.Entities.Common
{
    public class Portal : Entity
    {
        private Portal() { }

        public Entity ToArea {get; private set;}

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