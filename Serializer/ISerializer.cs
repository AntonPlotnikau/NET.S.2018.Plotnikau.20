using System;
using System.Collections.Generic;

namespace Serializer
{
    /// <summary>
    /// serializer interface
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Serializes the specified URI collection.
        /// </summary>
        /// <param name="uriCollection">The URI collection.</param>
        void Serialize(IEnumerable<Uri> uriCollection);
    }
}
