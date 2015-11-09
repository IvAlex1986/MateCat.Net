namespace MateCat.Net.Enums
{
    /// <summary>
    /// The analysis status of the project enum
    /// </summary>
    public enum AnalysisProjectStatus
    {
        /// <summary>
        /// Analysis/creation still in progress.
        /// </summary>
        Analyzing,

        /// <summary>
        /// The project has no segments to analyze (have you uploaded a file containing only images?).
        /// </summary>
        NoSegmentsFound,

        /// <summary>
        /// No analysis will be performed because of Matecat configuration.
        /// </summary>
        AnalysisNotEnabled,

        /// <summary>
        /// The analysis/creation is completed.
        /// </summary>
        Done,

        /// <summary>
        /// The analysis/creation is failed.
        /// </summary>
        Fail
    }
}
