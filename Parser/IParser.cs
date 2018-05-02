using System;

namespace Parser
{
    /// <summary>
    /// Parser interface
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Parses the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>Uniform Resource Identifier</returns>
        Uri Parse(string source);
    }
}
