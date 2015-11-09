using System;
using System.Runtime.Serialization;

namespace MateCat.Net.Models
{
    /// <summary>
    /// A structure modeling a portion of content to translate. A whole file can be splitted in multiple chunks, to be distributed to multiple translators, or can be enveloped in a single chunk. Each chunk has a password as first level key and a numerical ID as second level key to identify different chunks for the same file.
    /// </summary>
    [DataContract]
    public class ProjectStatusDataJobChunk : ProjectStatusDataJobTotal
    {
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        [DataMember(Name = "FILENAME")]
        public String FileName { get; set; }
    }
}
