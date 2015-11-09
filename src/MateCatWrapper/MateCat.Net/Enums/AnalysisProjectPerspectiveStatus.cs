namespace MateCat.Net.Enums
{
    /// <summary>
    /// The status the project is from analysis perspective enum.
    /// </summary>
    public enum AnalysisProjectPerspectiveStatus
    {
        /// <summary>
        /// Just created, not analyzed yet.
        /// </summary>
        New,

        /// <summary>
        /// Preliminary ("fast") analysis completed, now running translations ("TM") analysis.
        /// </summary>
        FastOk,

        /// <summary>
        /// Analysis complete.
        /// </summary>
        Done
    }
}
