namespace csharp.QualityUpdaters
{
    /// <summary>
    /// Updater for Conjured items
    /// </summary>
    class ConjuredUpdater : IQualityUpdater
    {
        private DefaultUpdater _updater = new DefaultUpdater(2);

        public void UpdateQuality(Item item)
        {
            _updater.UpdateQuality(item);
        }
    }
}
