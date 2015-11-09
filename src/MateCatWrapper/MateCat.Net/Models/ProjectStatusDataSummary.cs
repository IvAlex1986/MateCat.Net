using MateCat.Net.Enums;
using System;
using System.Runtime.Serialization;
using MateCat.Net.Helpers;

namespace MateCat.Net.Models
{
    /// <summary>
    /// Holds statistict for the whole project that are not related to single job objects.
    /// </summary>
    [DataContract]
    public class ProjectStatusDataSummary
    {
        /// <summary>
        /// The name of your project.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember(Name = "NAME")]
        public String Name { get; set; }

        /// <summary>
        /// The status the project is from analysis perspective.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public AnalysisProjectPerspectiveStatus Status { get; set; }

        /// <summary>
        /// Number of segments belonging to other projects that are being analyzed before yours; it's the wait time for you.
        /// </summary>
        /// <value>
        /// The in queus before.
        /// </value>
        [DataMember(Name = "IN_QUEUE_BEFORE")]
        public Int32? InQueusBefore { get; set; }

        /// <summary>
        /// Number of segments belonging to your project.
        /// </summary>
        /// <value>
        /// The total segments.
        /// </value>
        [DataMember(Name = "TOTAL_SEGMENTS")]
        public Int32 TotalSegments { get; set; }

        /// <summary>
        /// Analysis progress, on TotalSegments.
        /// </summary>
        /// <value>
        /// The segments analyzed.
        /// </value>
        [DataMember(Name = "SEGMENTS_ANALYZED")]
        public Int32 SegmentsAnalyzed { get; set; }

        /// <summary>
        /// Number of words (word count) of your project, as extracted by the textual parsers.
        /// </summary>
        /// <value>
        /// The word count of your project.
        /// </value>
        [DataMember(Name = "TOTAL_RAW_WC")]
        public Decimal TotalRawWordCount { get; set; }

        /// <summary>
        /// Word count, minus the sentences that are repeated.
        /// </summary>
        /// <value>
        /// The word count.
        /// </value>
        [DataMember(Name = "TOTAL_STANDARD_WC")]
        public Decimal TotalStandardWordCount { get; set; }

        /// <summary>
        /// Word count, minus the sentences that are partially repeated.
        /// </summary>
        /// <value>
        /// The word count.
        /// </value>
        [DataMember(Name = "TOTAL_FAST_WC")]
        public Decimal TotalFastWordCount { get; set; }

        /// <summary>
        /// Word count, with sentences found in the cloud translation memory discounted from the total; this depends on the percentage of overlapping between the sentences of your project and the past translations.
        /// </summary>
        /// <value>
        /// The word count.
        /// </value>
        [DataMember(Name = "TOTAL_TM_WC")]
        public Decimal TotalTmWordCount { get; set; }

        /// <summary>
        /// Total word count, after analysis.
        /// </summary>
        /// <value>
        /// The word count.
        /// </value>
        [DataMember(Name = "TOTAL_PAYABLE")]
        public Decimal TotalPayable { get; set; }

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
                Status = EnumHelper.Parse<AnalysisProjectPerspectiveStatus>(value);
            }
        }

        #endregion Private
    }
}
