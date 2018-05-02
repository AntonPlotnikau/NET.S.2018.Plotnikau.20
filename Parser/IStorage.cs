using System.Collections.Generic;

namespace Parser
{
    /// <summary>
    /// storage interface
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Loads data from storage.
        /// </summary>
        /// <returns>enumerable of strings</returns>
        IEnumerable<string> Load();
    }
}
