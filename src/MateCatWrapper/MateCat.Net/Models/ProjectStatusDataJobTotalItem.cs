using System;

namespace MateCat.Net.Models
{
    /// <summary>
    /// Contains information about analysis statistics item.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ProjectStatusDataJobTotalItem<T> where T: IConvertible
    {
        public ProjectStatusDataJobTotalItem(Array array)
        {
            Array = array;
        }

        /// <summary>
        /// Gets or sets the array.
        /// </summary>
        /// <value>
        /// The array.
        /// </value>
        public Array Array { get; set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T Value
        {
            get
            {
                return (T)Convert.ChangeType(Array.GetValue(0), typeof(T));
            }
        }

        /// <summary>
        /// Gets the value string.
        /// </summary>
        /// <value>
        /// The value string.
        /// </value>
        public String ValueString
        {
            get
            {
                return Array.GetValue(1).ToString();
            }
        }
    }
}
