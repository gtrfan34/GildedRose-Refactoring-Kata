using System.Collections.Generic;
using System.Linq;

namespace csharp.QualityUpdaters
{
    /// <summary>
    /// Updater for "Backstage passes" items
    /// </summary>
    class BackstageUpdater : DefaultRangeChecker, IQualityUpdater
    {
        /// <summary>
        /// Contains pairs of SellIn/Increase increment.
        /// </summary>
        private SortedDictionary<int, int> SellInAndIncreaseCollection = new SortedDictionary<int, int>()
        { 
            { 10, 1 },
            { 5, 2 }, 
            { 0, 3 } 
        };

        public void UpdateQuality(Item item)
        {
            foreach(var pair in SellInAndIncreaseCollection.Reverse())
            {
                if (item.SellIn > pair.Key)
                {
                    item.Quality += pair.Value;
                    break;
                }
            }

            if (item.SellIn == 0)
            {
                item.Quality = 0;
            }

            item.SellIn--;

            EnsureQualityRange(item);
        }
    }
}
