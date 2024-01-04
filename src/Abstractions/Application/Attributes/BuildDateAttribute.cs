using System;
using System.Globalization;

namespace BindOpen.Labs.Application
{
    /// <summary>
    /// This class represents a build date attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class BuildDateAttribute : Attribute
    {
        /// <summary>
        /// The date time of this instance.
        /// </summary>
        public DateTime DateTime { get; }

        /// <summary>
        /// Instantiates a new instance of the BuildDateAttribute class.
        /// </summary>
        /// <param name="value"></param>
        public BuildDateAttribute(string value)
        {
            DateTime = DateTime.ParseExact(
                value,
                "yyyyMMddHHmmss",
                CultureInfo.InvariantCulture, DateTimeStyles.None);
        }
    }
}