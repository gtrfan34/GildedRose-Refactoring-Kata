using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    public class GildedRose
    {
        private IList<Item> _items;
        private IQualityUpdaterResolver _qualityUpdaterResolver;

        public GildedRose(IList<Item> Items, IQualityUpdaterResolver qualityUpdaterResolver)
        {
            _items = Items;
            _qualityUpdaterResolver = qualityUpdaterResolver;
        }

        public void UpdateQuality()
        {
            if (_items == null)
            {
                return;
            }

            foreach (var item in _items.Where(i => i != null))
            {
                var updater = _qualityUpdaterResolver.Resolve(item);
                updater.UpdateQuality(item);
            }
        }
    }
}
