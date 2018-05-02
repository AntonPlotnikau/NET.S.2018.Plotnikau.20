using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Serializer
{
    /// <summary>
    /// Uri serializer
    /// </summary>
    /// <seealso cref="Serializer.ISerializer" />
    public class UriSerializer : ISerializer
    {
        /// <summary>
        /// The file name
        /// </summary>
        private readonly string fileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="UriSerializer"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <exception cref="ArgumentNullException">file name is null</exception>
        public UriSerializer(string fileName)
        {
            this.fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
        }

        /// <summary>
        /// Serializes the specified URI collection.
        /// </summary>
        /// <param name="uriCollection">The URI collection.</param>
        public void Serialize(IEnumerable<Uri> uriCollection)
        {
            XDocument document = new XDocument();
            var rootElement = new XElement("urlAddresses");
            foreach (var item in uriCollection) 
            {
                var element = new XElement("urlAddress");
                this.AddHost(element, item);
                this.AddUri(element, item);
                this.AddParameters(element, item);
                rootElement.Add(element);
            }

            document.Add(rootElement);
            document.Save(this.fileName);
        }

        /// <summary>
        /// Adds the host.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <param name="uri">The URI.</param>
        private void AddHost(XElement root, Uri uri)
        {
            var element = new XElement("host");
            var attribute = new XAttribute("name", uri.Host);
            element.Add(attribute);
            root.Add(element);
        }

        /// <summary>
        /// Adds the URI.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <param name="uri">The URI.</param>
        private void AddUri(XElement root, Uri uri)
        {
            var element = new XElement("uri");
            foreach (var item in uri.Segments.Where(x => x != "/"))
            {
                element.Add(new XElement("segment", item.Where(x => x != '/')));
            }

            root.Add(element);
        }

        /// <summary>
        /// Adds the parameters.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <param name="uri">The URI.</param>
        private void AddParameters(XElement root, Uri uri)
        {
            var element = new XElement("parameters");
            var queryDictionary = HttpUtility.ParseQueryString(uri.Query);

            foreach (var key in queryDictionary.Keys) 
            {
                var parametr = new XElement("parametr");
                var attribute = new XAttribute((string)key, queryDictionary[(string)key]);
                parametr.Add(attribute);
                element.Add(parametr);
            }

            if (queryDictionary.Keys.Count > 0)
            {
                root.Add(element);
            }
        }
    }
}
