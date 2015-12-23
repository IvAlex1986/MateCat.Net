using MateCat.Net.Attributes;
using MateCat.Net.Enums;
using MateCat.Net.Helpers;
using System;

namespace MateCat.Net.Models
{
    /// <summary>
    /// Private key for MyMemory
    /// </summary>
    public class ProjectKey
    {
        private const String New = "new";

        public ProjectKey()
        {
            Key = New;
        }

        public ProjectKey(String key, ProjectKeyMode mode)
        {
            Key = key;
            Mode = mode;
        }

        public ProjectKey(String key)
            : this(key, ProjectKeyMode.ReadWrite)
        {
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public String Key { get; set; }

        /// <summary>
        /// Gets or sets the mode.
        /// </summary>
        /// <value>
        /// The mode.
        /// </value>
        public ProjectKeyMode Mode { get; set; }

        public override String ToString()
        {
            return (Key == New) ? New : String.Format("{0}:{1}", Key, Mode.GetAttribute<CodeAttribute>().Value);
        }
    }
}
