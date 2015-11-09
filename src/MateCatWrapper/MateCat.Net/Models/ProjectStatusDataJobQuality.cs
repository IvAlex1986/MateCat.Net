using MateCat.Net.Enums;
using MateCat.Net.Helpers;
using System;
using System.Runtime.Serialization;

namespace MateCat.Net.Models
{
    /// <summary>
    /// Each object is a quality check performed on the job; the object contains the type of the check (Typing, Translation, Terminology, Language Quality, Style), the quantity of errors found, the allowed errors threshold and the rating given by the errors/threshold ratio
    /// </summary>
    [DataContract]
    public class ProjectStatusDataJobQuality
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public QualityProjectType Type { get; set; }

        /// <summary>
        /// Gets or sets the allowed.
        /// </summary>
        /// <value>
        /// The allowed.
        /// </value>
        [DataMember(Name = "allowed")]
        public Decimal Allowed { get; set; }

        /// <summary>
        /// Gets or sets the found.
        /// </summary>
        /// <value>
        /// The found.
        /// </value>
        [DataMember(Name = "found")]
        public Decimal Found { get; set; }

        /// <summary>
        /// Gets or sets the vote.
        /// </summary>
        /// <value>
        /// The vote.
        /// </value>
        public QualityProjectStatus Vote { get; set; }

        #region Private

        [DataMember(Name = "type")]
        private String TypeString
        {
            get
            {
                return Type.ToString();
            }
            set
            {
                Type = EnumHelper.Parse<QualityProjectType>(value);
            }
        }

        [DataMember(Name = "vote")]
        private String VoteString
        {
            get
            {
                return Vote.ToString();
            }
            set
            {
                Vote = EnumHelper.Parse<QualityProjectStatus>(value);
            }
        }

        #endregion Private
    }
}
