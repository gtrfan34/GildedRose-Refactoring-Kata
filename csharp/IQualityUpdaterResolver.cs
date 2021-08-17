namespace csharp
{
    public interface IQualityUpdaterResolver
    {
        /// <summary>
        /// Resolves which updater should be apllied to the Item
        /// </summary>
        IQualityUpdater Resolve(Item item);
    }
}
