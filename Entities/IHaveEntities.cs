using System.Collections.Generic;
using System.Linq;

namespace TextGame.Entities
{
    public interface IHaveEntities
    {
        List<Entity> Entities { get; }
    }

    public static class IHaveEntitiesExtensions 
    {
        public static IList<Entity> GetKnownEntities(this IHaveEntities hasEntities) 
        {
            return hasEntities.Entities
                .Where(i => i.IsKnown)
                .ToList();

        }

        public static T WithEntity<T>(this T hasEntities, Entity entity) where T : IHaveEntities
        {
            hasEntities.Entities.Add(entity);
            return hasEntities;
        }

        public static T ContainingEntities<T>(this T hasEntities, params Entity[] entities) where T : IHaveEntities
        {
            hasEntities.Entities.AddRange(entities);
            return hasEntities;
        }
    }
}