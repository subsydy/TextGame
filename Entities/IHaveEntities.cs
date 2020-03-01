using System.Collections.Generic;
using System.Linq;

namespace TextGame.Entities
{
    public interface IHaveEntities
    {
        List<IEntity> Entities { get; }
    }

    public static class IHaveEntitiesExtensions 
    {
        public static IList<IEntity> GetKnownEntities(this IHaveEntities itemBag) 
        {
            return itemBag.Entities
                .Where(i => i.IsKnown)
                .ToList();

        }
    }
}