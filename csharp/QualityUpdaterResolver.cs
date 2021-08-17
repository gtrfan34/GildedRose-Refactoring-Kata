using csharp.QualityUpdaters;

namespace csharp
{
    class QualityUpdaterResolver : IQualityUpdaterResolver
    {
        public IQualityUpdater Resolve(Item item)
        {
            if (!string.IsNullOrEmpty(item.Name))
            {
                if (item.Name.Contains("Aged Brie"))
                    return new AgedBreeUpdater();
                if (item.Name.Contains("Backstage passes"))
                    return new BackstageUpdater();
                if (item.Name.Contains("Conjured"))
                    return new ConjuredUpdater();
                if (item.Name.Contains("Sulfuras"))
                    return new SulfurasUpdater();
            }
            
            return new DefaultUpdater();
        }
    }
}
