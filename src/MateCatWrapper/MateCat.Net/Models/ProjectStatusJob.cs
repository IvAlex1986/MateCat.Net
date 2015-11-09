using MateCat.Net.Enums;
using MateCat.Net.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace MateCat.Net.Models
{
    [DataContract]
    public class ProjectStatusJob
    {
        /// <summary>
        /// The language pairs for your project; an entry for every chunk in the project, with the id-password combination as key and the language pair as the value.
        /// </summary>
        /// <value>
        /// The language pairs.
        /// </value>
        [DataMember(Name = "langpairs")]
        public Dictionary<String, String> LanguagePairs { get; set; }

        /// <summary>
        /// The links to the chunks of the project; an entry for every chunk in the project, with the id-password combination as key and the link to the chunk as the value.
        /// </summary>
        /// <value>
        /// The language pairs.
        /// </value>
        [DataMember(Name = "job-url")]
        public Dictionary<String, String> JobUrl { get; set; }

        /// <summary>
        /// A structure containing, for each chunk, an array of 5 objects: each object is a quality check performed on the job; the object contains the type of the check (Typing, Translation, Terminology, Language Quality, Style), the quantity of errors found, the allowed errors threshold and the rating given by the errors/threshold ratio.
        /// </summary>
        /// <value>
        /// The jo quality details.
        /// </value>
        [DataMember(Name = "job-quality-details")]
        public Dictionary<String, List<ProjectStatusDataJobQuality>> JobQualityDetails { get; set; }

        /// <summary>
        /// The overall quality rating for each chunk (Very good, Good, Acceptable, Poor, Fail).
        /// </summary>
        /// <value>
        /// The quality overall.
        /// </value>
        public Dictionary<String, QualityProjectStatus> QualityOverall { get; set; }

        #region Private

        [DataMember(Name = "quality-overall")]
        public Dictionary<String, String> QualityOverallStrings
        {
            get
            {
                return QualityOverall.ToDictionary(
                    n => n.Key,
                    n => n.Value.ToString());
            }
            set
            {
                QualityOverall = value.ToDictionary(
                    n => n.Key,
                    n => EnumHelper.Parse<QualityProjectStatus>(n.Value));
            }
        }

        #endregion Private
    }
}
