namespace TextGame.Entities
{
    public interface IEntity
    {
        string Name { get; }
        bool IsKnown { get; set; }
    }

    public static class IEntityExtensions 
    {
        public static T AsHidden<T>(this T entity) where T : IEntity
        {
            entity.IsKnown = true;
            return entity;
        }
    }
}