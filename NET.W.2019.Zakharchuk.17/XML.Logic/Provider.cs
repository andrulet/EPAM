using System;
using System.Collections.Generic;
using System.IO;

namespace XML.Logic
{
    /// <summary>
    /// This class give list of URL to other class.
    /// </summary>    
    public class Provider : IProvider
    {
        /// <summary>
        /// Field of path to file with string representation urls.
        /// </summary>    
        private readonly string filePath;

        /// <summary>
        /// Field reference of <see cref="Parser"/>.
        /// </summary>    
        private readonly Parser parser;

        /// <summary>
        /// Initializes new instance of <see cref="Provider"/> with specified <paramref name="filePath"/> and <paramref name="parser"/>.
        /// </summary>
        /// <param name="filePath">Path to the file that cantains urls.</param>
        /// <param name="parser">Parser.</param>
        public Provider(string filePath, Parser parser)
        {
            this.filePath = filePath ?? throw new ArgumentNullException($"{nameof(filePath)} is null");
            this.parser = parser ?? throw new ArgumentNullException($"{nameof(parser)} is null");
            
        }

        /// <summary>
        /// This methods louds urls from file.
        /// </summary>
        /// <returns>list of URLs</returns>
        public IEnumerable<URL> Load()
        {
            IEnumerable<string> urlList = File.ReadLines(filePath);
            var parsedUrls = new List<URL>();

            foreach (var item in urlList)
            {
                if (IsValid(item))
                {
                    parsedUrls.Add(parser.Parse(item));
                }                
            }

            return parsedUrls;
        }

        /// <summary>
        /// This method checks string representation on transmission protocol.
        /// </summary>
        /// <param name="url">String representation url.</param>
        /// <returns>True if <paramref name="url"/> doesn't have transmission protocol, false if it has.</returns>
        private bool IsValid(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            if (url.Contains("http://") || url.Contains("https://"))
            {
                return true;
            }

            return false;
        }
    }
}
