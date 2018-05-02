using System;
using System.Collections.Generic;
using System.IO;

namespace Parser
{
    /// <summary>
    /// file storage
    /// </summary>
    /// <seealso cref="Parser.IStorage" />
    public class FileStorage : IStorage
    {
        /// <summary>
        /// The path
        /// </summary>
        private string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileStorage"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <exception cref="ArgumentNullException">path is null</exception>
        /// <exception cref="ArgumentException">path does not exist</exception>
        public FileStorage(string path)
        {
            if (path == null) 
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (!File.Exists(path))
            {
                throw new ArgumentException(nameof(path));
            }

            this.path = path;
        }

        /// <summary>
        /// Loads the lines from file.
        /// </summary>
        /// <returns>enumerable of strings</returns>
        public IEnumerable<string> Load()
            => File.ReadAllLines(this.path);
    }
}
