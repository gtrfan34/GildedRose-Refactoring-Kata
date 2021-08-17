namespace csharp
{
    /// <summary>
    /// Checker of Sulfuras item Quality range
    /// </summary>
    class SulfurasRangeChecker
    {
        private const int SulfurasQuality = 80;

        /// <summary>
        /// Checks if Quality equals default quality. Updates Quality if not
        /// </summary>
        public void EnsureQualityRange(Item item)
        {
            if (item.Quality != SulfurasQuality)
            {
                item.Quality = SulfurasQuality;
            }
        }
    }
}
