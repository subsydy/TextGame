using System.Collections.Generic;
using System.Linq;

namespace TextGame.Entities
{
    public interface IHaveItems
    {
        List<Item> Items { get; }
    }

    public static class IHaveItemsExtensions 
    {
        public static IList<Item> GetKnownItems(this IHaveItems itemBag) 
        {
            return itemBag.Items
                .Where(i => i.IsKnown)
                .ToList();

        }
    }
}