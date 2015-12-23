using MateCat.Net.Attributes;

namespace MateCat.Net.Enums
{
    /// <summary>
    /// The segmentation rule you want to use to parse your file.
    /// </summary>
    public enum SegmentationRule
    {
        /// <summary>
        /// General
        /// </summary>
        [Code(Value = "")]
        General,

        /// <summary>
        /// Patent
        /// </summary>
        [Code(Value = "patent")]
        Patent
    }
}
