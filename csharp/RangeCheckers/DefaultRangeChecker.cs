namespace csharp
{
    /// <summary>
    /// Checker for default range of Quality
    /// </summary>
    class DefaultRangeChecker
    {
        /// <summary>
        /// Minimum value of allowed Quality
        /// </summary>
        public const int MinimumQuality = 0;

        /// <summary>
        /// Maximum value of allowed Quality
        /// </summary>
        private const int MaximumQuality = 50;

        /// <summary>
        /// Check if Quality value inside the default range. Updates Quality if not
        /// </summary>
        public void EnsureQualityRange(Item item)
        {
            if (item.Quality < MinimumQuality)
            {
                item.Quality = MinimumQuality;
            } 
            else if (item.Quality > MaximumQuality)
            {
                item.Quality = MaximumQuality;
            }
        }
    }
}
