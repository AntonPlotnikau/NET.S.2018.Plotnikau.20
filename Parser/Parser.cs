using System;
using System.Collections.Generic;
using Logger;

namespace Parser
{
    /// <summary>
    /// Parser for string
    /// </summary>
    /// <seealso cref="Parser.IParser" />
    public class Parser : IParser
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Parser"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentNullException">logger is null</exception>
        public Parser(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parser"/> class.
        /// </summary>
        public Parser() : this(new NLogger(nameof(Parser))) { }

        /// <summary>
        /// Parses the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>
        /// Uniform Resource Identifier
        /// </returns>
        public Uri Parse(string source)
        {
            try
            {
                return new Uri(source);
            }
            catch (UriFormatException)
            {
                this.logger.Warn(source + "can not be represented as uri");
                return null;
            }
        }

        /// <summary>
        /// Parses from storage.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <returns>enumerable of uris</returns>
        public IEnumerable<Uri> ParseFromStorage(IStorage storage)
        {
            IEnumerable<string> strings = storage.Load();
            foreach (var item in strings) 
            {
                Uri uri = this.Parse(item);
                if (uri != null)
                {
                    yield return uri;
                }
            }
        }
    }
}
