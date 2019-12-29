using System;
using System.Collections.Generic;

namespace XML.Logic
{
    /// <summary>
    /// Class describing URL models.
    /// </summary>
    public class URL
    {
        /// <summary>
        /// This property gets transmission protocol from url and sets transmission protocol.
        /// </summary>
        public string TransmissionProtocol { get; set; }

        /// <summary>
        /// This property gets host name from url and sets host name.
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// This property gets list of segments from url and sets list of segments.
        /// </summary>
        public List<string> Segments { get; set; } = new List<string>();

        /// <summary>
        /// This property gets list of parameters key-value from url and sets list of list of parameters key-value.
        /// </summary>
        public List<KeyValuePair<string, string>> ParametersKeyValue { get; set; } = new List<KeyValuePair<string, string>>();
    }
}
