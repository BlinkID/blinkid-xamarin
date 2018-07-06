using Microblink.Forms.Core.Recognizers;
using CoreGraphics;
using Foundation;

namespace Microblink.Forms.iOS.Recognizers
{
	public sealed class Date : IDate
    {
        MBDateResult nativeDate;

        public Date(MBDateResult nativeDate)
        {
            this.nativeDate = nativeDate;
        }

        public Date(NSDate nsDate)
        {
            NSDateComponents components = NSCalendar.CurrentCalendar.Components(NSCalendarUnit.Day | NSCalendarUnit.Month | NSCalendarUnit.Year, nsDate);
            nativeDate = new MBDateResult(components.Day, components.Month, components.Year, "");
        }

        public int Day => (int) nativeDate.Day;

        public int Month => (int) nativeDate.Month;

        public int Year => (int) nativeDate.Year;
    }

    public sealed class Point : IPoint
    {
        CGPoint nativePoint;

        public Point(CGPoint point)
        {
            nativePoint = point;
        }

        public float X => (float)nativePoint.X;

        public float Y => (float)nativePoint.Y;
    }

    public sealed class Quadrilateral : IQuadrilateral
    {
        MBQuadrangle nativeQuad;

        public Quadrilateral(MBQuadrangle nativeQuad)
        {
            this.nativeQuad = nativeQuad;
        }

        public IPoint UpperLeft => new Point(nativeQuad.UpperLeft);

        public IPoint UpperRight => new Point(nativeQuad.UpperRight);

        public IPoint LowerLeft => new Point(nativeQuad.LowerLeft);

        public IPoint LowerRight => new Point(nativeQuad.LowerRight);
    }
}
