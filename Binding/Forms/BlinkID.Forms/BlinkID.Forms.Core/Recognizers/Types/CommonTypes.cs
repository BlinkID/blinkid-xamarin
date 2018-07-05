namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Represents the type of scanned barcode
    /// </summary>
    public enum BarcodeType
    {
        /// <summary>
        /// No barcode was scanned
        /// </summary>
        None,

        /// <summary>
        /// QR code was scanned
        /// </summary>
        QRCode,

        /// <summary>
        /// Data Matrix 2D barcode was scanned
        /// </summary>
        DataMatrix,

        /// <summary>
        /// UPC E barcode was scanned
        /// </summary>
        UPCE,

        /// <summary>
        /// UPC A barcode was scanned
        /// </summary>
        UPCA,

        /// <summary>
        /// EAN 8 barcode was scanned
        /// </summary>
        EAN8,

        /// <summary>
        /// EAN 13 barcode was scanned
        /// </summary>
        EAN13,

        /// <summary>
        /// Code 128 barcode was scanned
        /// </summary>
        Code128,

        /// <summary>
        /// Code 39 barcode was scanned
        /// </summary>
        Code39,

        /// <summary>
        /// ITF barcode was scanned
        /// </summary>
        ITF,

        /// <summary>
        /// Aztec 2D barcode was scanned
        /// </summary>
        Aztec,

        /// <summary>
        /// PDF417 2D barcode was scanned
        /// </summary>
        PDF417
    }

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
