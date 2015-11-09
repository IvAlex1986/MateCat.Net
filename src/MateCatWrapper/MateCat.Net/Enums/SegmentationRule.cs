using MateCat.Net.Attributes;

namespace MateCat.Net.Enums
{
    /// <summary>
    /// The segmentation rule you want to use to parse your file.
    /// </summary>
    public enum SegmentationRule
    {
        [Code(Value = "")]
        General,

        [Code(Value = "patent")]
        Patent
    }
}
