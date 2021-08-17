using System.Collections.Generic;

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
            foreach (var item in _items)
            {
                var updater = _qualityUpdaterResolver.Resolve(item);
                updater.UpdateQuality(item);
            }
        }
    }
}
