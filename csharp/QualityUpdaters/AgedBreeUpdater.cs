namespace csharp.QualityUpdaters
{
    /// <summary>
    /// Updater for Aged Bree
    /// </summary>
    class AgedBreeUpdater : DefaultRangeChecker, IQualityUpdater
    {
        public void UpdateQuality(Item item)
        {
            item.Quality++;

            EnsureQualityRange(item);
        }
    }
}
