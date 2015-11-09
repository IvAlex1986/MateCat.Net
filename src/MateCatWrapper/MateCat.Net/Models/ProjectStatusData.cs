using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MateCat.Net.Models
{
    /// <summary>
    /// Holds all progress statisticts for every job and for overall project.
    /// </summary>
    [DataContract]
    public class ProjectStatusData
    {
        /// <summary>
        /// Sub-section jobs holds statistict for all the job objects.
        /// </summary>
        /// <value>
        /// The jobs.
        /// </value>
        [DataMember(Name = "jobs")]
        public Dictionary<Int32, ProjectStatusDataJob> Jobs { get; set; }

        /// <summary>
        /// Sub-section summary holds statistict for the whole project that are not related to single job objects.
        /// </summary>
        /// <value>
        /// The summary.
        /// </value>
        [DataMember(Name = "summary")]
        public ProjectStatusDataSummary Summary { get; set; }
    }
}
