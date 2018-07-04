using System;
namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Represents a date extracted from image.
    /// </summary>
    public interface IDate
    {
        /// <summary>
        /// Gets the day in month.
        /// </summary>
        /// <value>The day in month.</value>
        int Day { get; }

        /// <summary>
        /// Gets the month in year.
        /// </summary>
        /// <value>The month in year.</value>
        int Month { get; }

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>The year.</value>
        int Year { get; }
    }
}
