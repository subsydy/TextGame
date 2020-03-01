namespace TextGame.Entities
{
    public interface IEntity
    {
        string Name { get; }
        bool IsKnown { get; set; }
    }

    public static class IEntityExtensions 
    {
        public static IEntity IsHidden(this IEntity entity) 
        {
            entity.IsKnown = true;
            return entity;
        }
    }
}