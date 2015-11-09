using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MateCat.Net.Models
{
    /// <summary>
    /// Holds statistict for all the job objects.
    /// </summary>
    [DataContract]
    public class ProjectStatusDataJob
    {
        /// <summary>
        /// A structure modeling a portion of content to translate.
        /// </summary>
        /// <value>
        /// The chunks.
        /// </value>
        [DataMember(Name = "chunks")]
        public Dictionary<String, Dictionary<Int32, ProjectStatusDataJobChunk>> Chunks { get; set; }

        /// <summary>
        /// Contains all analysis statistics for all files in the current job.
        /// </summary>
        /// <value>
        /// The totals.
        /// </value>
        [DataMember(Name = "totals")]
        public Dictionary<String, ProjectStatusDataJobTotal> Totals { get; set; }
    }
}
