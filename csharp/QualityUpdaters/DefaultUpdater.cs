namespace csharp.QualityUpdaters
{
    /// <summary>
    /// Default updater for items
    /// </summary>
    class DefaultUpdater : DefaultRangeChecker, IQualityUpdater
    {
        /// <summary>
        /// Multiplier of increment
        /// </summary>
        private int _incrementCoefficient = 1;

        public DefaultUpdater() { }

        public DefaultUpdater(int coefficient)
        {
            _incrementCoefficient = coefficient;
        }

        public void UpdateQuality(Item item)
        {
            if (item.Quality == MinimumQuality)
            {
                return;
            }

            if (item.SellIn > 0)
            {
                item.SellIn--;
                item.Quality -= 1 * _incrementCoefficient;
            }
            else
            {
                item.Quality -= 2 * _incrementCoefficient;
            }

            EnsureQualityRange(item);
        }
    }
}
