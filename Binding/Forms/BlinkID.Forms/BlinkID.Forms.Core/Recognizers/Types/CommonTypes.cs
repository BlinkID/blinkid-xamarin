namespace BlinkID.Forms.Core.Recognizers
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

    /// <summary>
    /// Represents a point in image.
    /// </summary>
    public interface IPoint 
    {
        /// <summary>
        /// Gets the x coordinate of the point.
        /// </summary>
        /// <value>The x.</value>
        float X { get; }

        /// <summary>
        /// Gets the y coordinate of the point.
        /// </summary>
        /// <value>The y.</value>
        float Y { get; }
    }

    public interface IQuadrilateral
    {
        /// <summary>
        /// Gets the upper left point of the quadrilateral.
        /// </summary>
        /// <value>The upper left.</value>
        IPoint UpperLeft { get; }

        /// <summary>
        /// Gets the upper right point of the quadrilateral.
        /// </summary>
        /// <value>The upper right.</value>
        IPoint UpperRight { get; }

        /// <summary>
        /// Gets the lower left point of the quadrilateral.
        /// </summary>
        /// <value>The lower left.</value>
        IPoint LowerLeft { get; }

        /// <summary>
        /// Gets the lower right point of the quadrilateral.
        /// </summary>
        /// <value>The lower right.</value>
        IPoint LowerRight { get; }
    }
}