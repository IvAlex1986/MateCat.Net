using MateCat.Net.Attributes;

namespace MateCat.Net.Enums
{
    /// <summary>
    /// Project key usage mode.
    /// </summary>
    public enum ProjectKeyMode
    {
        /// <summary>
        /// Read mode
        /// </summary>
        [Code(Value = "r")]
        Read,

        /// <summary>
        /// Write mode
        /// </summary>
        [Code(Value = "w")]
        Write,

        /// <summary>
        /// Read and Write modes
        /// </summary>
        [Code(Value = "rw")]
        ReadWrite
    }
}
