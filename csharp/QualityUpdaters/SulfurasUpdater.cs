namespace csharp.QualityUpdaters
{
    /// <summary>
    /// Updater for Sulfuras items
    /// </summary>
    class SulfurasUpdater : SulfurasRangeChecker, IQualityUpdater
    {
        public void UpdateQuality(Item item)
        {
            EnsureQualityRange(item);
        }
    }
}
