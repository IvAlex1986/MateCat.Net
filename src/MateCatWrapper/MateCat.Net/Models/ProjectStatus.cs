using MateCat.Net.Enums;
using MateCat.Net.Helpers;
using System;
using System.Runtime.Serialization;

namespace MateCat.Net.Models
{
    /// <summary>
    /// The metadata for the created project containing the status of the project.
    /// </summary>
    [DataContract]
    public class ProjectStatus
    {
        /// <summary>
        /// Holds all progress statisticts for every job and for overall project.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [DataMember(Name = "data")]
        public ProjectStatusData Data { get; set; }

        /// <summary>
        /// Return the analysis status of the project.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public AnalysisProjectStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the message. Error description for <see cref="Status"/> is Failed
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [DataMember(Name = "message")]
        public String Message { get; set; }

        /// <summary>
        /// A link to the analyze page; it's a human readable version of this API output.
        /// </summary>
        /// <value>
        /// The analyze link.
        /// </value>
        [DataMember(Name = "analyze")]
        public String AnalyzeLink { get; set; }

        /// <summary>
        /// Section Jobs contains all metadata about job (like URIs, quality reports and languages).
        /// </summary>
        /// <value>
        /// The job data.
        /// </value>
        [DataMember(Name = "jobs")]
        public ProjectStatusJob Jobs { get; set; }

        #region Private

        [DataMember(Name = "status")]
        private String StatusString
        {
            get
            {
                return Status.ToString();
            }
            set
            {
                Status = EnumHelper.Parse<AnalysisProjectStatus>(value);
            }
        }

        #endregion Private
    }
}
