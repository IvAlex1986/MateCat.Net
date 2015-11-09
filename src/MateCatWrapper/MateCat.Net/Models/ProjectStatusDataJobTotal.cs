using System;
using System.Runtime.Serialization;

namespace MateCat.Net.Models
{
    /// <summary>
    /// Contains all analysis statistics for all files in the current job.
    /// </summary>
    [DataContract]
    public class ProjectStatusDataJobTotal
    {
        /// <summary>
        /// Total word count, after analysis.
        /// </summary>
        /// <value>
        /// The total payable.
        /// </value>
        public ProjectStatusDataJobTotalItem<Decimal> TotalPayable { get; set; }

        /// <summary>
        /// Cumulative word count for the segments that repeat themselves in the file.
        /// </summary>
        /// <value>
        /// The repetitions.
        /// </value>
        public ProjectStatusDataJobTotalItem<Decimal> Repetitions { get; set; }

        /// <summary>
        /// Cumulative word count for the segments that fuzzily overlap with others in the file, while not being an exact repetition.
        /// </summary>
        /// <value>
        /// The mt.
        /// </value>
        public ProjectStatusDataJobTotalItem<Decimal> Mt { get; set; }

        /// <summary>
        /// Cumulative word count for segments that can't be discounted with repetition or internal matches; it's the net translation effort.
        /// </summary>
        /// <value>
        /// The new.
        /// </value>
        public ProjectStatusDataJobTotalItem<Decimal> New { get; set; }

        /// <summary>
        /// Cumulative word count for the exact matches found in TM server.
        /// </summary>
        /// <value>
        /// The TM100.
        /// </value>
        public ProjectStatusDataJobTotalItem<Decimal> Tm100 { get; set; }

        /// <summary>
        /// Cumulative word count for the exact matches found in TM server public.
        /// </summary>
        /// <value>
        /// The TM100 public.
        /// </value>
        public ProjectStatusDataJobTotalItem<Decimal> Tm100Public { get; set; }

        /// <summary>
        /// Cumulative word count for partial matches in the TM that cover 75-99% of each segment.
        /// </summary>
        /// <value>
        /// The TM 75 to 99.
        /// </value>
        public ProjectStatusDataJobTotalItem<Decimal> Tm75To99 { get; set; }

        /// <summary>
        /// Cumulative word count for partial matches in the TM that cover 75-84% of each segment.
        /// </summary>
        /// <value>
        /// The TM 75 to 84.
        /// </value>
        public ProjectStatusDataJobTotalItem<Decimal> Tm75To84 { get; set; }

        /// <summary>
        /// Cumulative word count for partial matches in the TM that cover 85-94% of each segment.
        /// </summary>
        /// <value>
        /// The TM 85 to 94.
        /// </value>
        public ProjectStatusDataJobTotalItem<Decimal> Tm85To94 { get; set; }

        /// <summary>
        /// Cumulative word count for partial matches in the TM that cover 95-99% of each segment.
        /// </summary>
        /// <value>
        /// The TM 95 to 99.
        /// </value>
        public ProjectStatusDataJobTotalItem<Decimal> Tm95To99 { get; set; }

        /// <summary>
        /// Cumulative word count for partial matches in the TM that cover 50-74% of each segment.
        /// </summary>
        /// <value>
        /// The TM 50 to 74.
        /// </value>
        public ProjectStatusDataJobTotalItem<Decimal> Tm50To74 { get; set; }

        /// <summary>
        /// Gets or sets the internal matches.
        /// </summary>
        /// <value>
        /// The internal matches.
        /// </value>
        public ProjectStatusDataJobTotalItem<Decimal> InternalMatches { get; set; }

        /// <summary>
        /// Cumulative word count for 100% TM matches that also share the same context with the TM.
        /// </summary>
        /// <value>
        /// The ice.
        /// </value>
        public ProjectStatusDataJobTotalItem<Decimal> Ice { get; set; }

        /// <summary>
        /// Cumulative word counts for segments made of numberings, dates and similar not translatable data (i.e.: 93/127).
        /// </summary>
        /// <value>
        /// The numbers only.
        /// </value>
        public ProjectStatusDataJobTotalItem<Decimal> NumbersOnly { get; set; }

        #region Private

        [DataMember(Name = "TOTAL_PAYABLE")]
        private Array TotalPayableArray
        {
            get
            {
                return TotalPayable.Array;
            }
            set
            {
                TotalPayable = new ProjectStatusDataJobTotalItem<Decimal>(value);
            }
        }

        [DataMember(Name = "REPETITIONS")]
        private Array RepetitionsArray
        {
            get
            {
                return Repetitions.Array;
            }
            set
            {
                Repetitions = new ProjectStatusDataJobTotalItem<Decimal>(value);
            }
        }

        [DataMember(Name = "MT")]
        private Array MtArray
        {
            get
            {
                return Mt.Array;
            }
            set
            {
                Mt = new ProjectStatusDataJobTotalItem<Decimal>(value);
            }
        }

        [DataMember(Name = "NEW")]
        private Array NewArray
        {
            get
            {
                return New.Array;
            }
            set
            {
                New = new ProjectStatusDataJobTotalItem<Decimal>(value);
            }
        }

        [DataMember(Name = "TM_100")]
        private Array Tm100Array
        {
            get
            {
                return Tm100.Array;
            }
            set
            {
                Tm100 = new ProjectStatusDataJobTotalItem<Decimal>(value);
            }
        }

        [DataMember(Name = "TM_100_PUBLIC")]
        private Array Tm100PublicArray
        {
            get
            {
                return Tm100Public.Array;
            }
            set
            {
                Tm100Public = new ProjectStatusDataJobTotalItem<Decimal>(value);
            }
        }

        [DataMember(Name = "TM_75_99")]
        private Array Tm75To99Array
        {
            get
            {
                return Tm75To99.Array;
            }
            set
            {
                Tm75To99 = new ProjectStatusDataJobTotalItem<Decimal>(value);
            }
        }

        [DataMember(Name = "TM_75_84")]
        private Array Tm75To84Array
        {
            get
            {
                return Tm75To84.Array;
            }
            set
            {
                Tm75To84 = new ProjectStatusDataJobTotalItem<Decimal>(value);
            }
        }

        [DataMember(Name = "TM_85_94")]
        private Array Tm85To94Array
        {
            get
            {
                return Tm85To94.Array;
            }
            set
            {
                Tm85To94 = new ProjectStatusDataJobTotalItem<Decimal>(value);
            }
        }

        [DataMember(Name = "TM_95_99")]
        private Array Tm95To99Array
        {
            get
            {
                return Tm95To99.Array;
            }
            set
            {
                Tm95To99 = new ProjectStatusDataJobTotalItem<Decimal>(value);
            }
        }

        [DataMember(Name = "TM_50_74")]
        private Array Tm50To74Array
        {
            get
            {
                return Tm50To74.Array;
            }
            set
            {
                Tm50To74 = new ProjectStatusDataJobTotalItem<Decimal>(value);
            }
        }

        [DataMember(Name = "INTERNAL_MATCHES")]
        private Array InternalMatchesArray
        {
            get
            {
                return InternalMatches.Array;
            }
            set
            {
                InternalMatches = new ProjectStatusDataJobTotalItem<Decimal>(value);
            }
        }

        [DataMember(Name = "ICE")]
        private Array IceArray
        {
            get
            {
                return Ice.Array;
            }
            set
            {
                Ice = new ProjectStatusDataJobTotalItem<Decimal>(value);
            }
        }

        [DataMember(Name = "NUMBERS_ONLY")]
        private Array NumbersOnlyArray
        {
            get
            {
                return NumbersOnly.Array;
            }
            set
            {
                NumbersOnly = new ProjectStatusDataJobTotalItem<Decimal>(value);
            }
        }

        #endregion Private
    }
}
