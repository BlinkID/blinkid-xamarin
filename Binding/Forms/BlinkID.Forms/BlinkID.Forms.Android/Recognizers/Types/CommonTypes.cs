using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

namespace Microblink.Forms.Droid.Recognizers
{
	public sealed class Date : IDate
    {
        Com.Microblink.Results.Date.Date nativeDate;

        public Date(Com.Microblink.Results.Date.Date nativeDate)
        {
            this.nativeDate = nativeDate;
        }

        public int Day => nativeDate.Day;

        public int Month => nativeDate.Month;

        public int Year => nativeDate.Year;
    }

    public sealed class Point : IPoint
    {
        Com.Microblink.Geometry.Point nativePoint;

        public Point(Com.Microblink.Geometry.Point nativePoint) 
        {
            this.nativePoint = nativePoint;
        }

        public float X { get => nativePoint.GetX(); set => nativePoint.SetX(value); }
        public float Y { get => nativePoint.GetY(); set => nativePoint.SetY(value); }
    }

    public sealed class Quadrilateral : IQuadrilateral
    {
        Com.Microblink.Geometry.Quadrilateral nativeQuad;

        public Quadrilateral(Com.Microblink.Geometry.Quadrilateral nativeQuad) 
        {
            this.nativeQuad = nativeQuad;
        }

        public IPoint UpperLeft { get => new Point(nativeQuad.UpperLeft); }
        public IPoint UpperRight { get => new Point(nativeQuad.UpperRight); }
        public IPoint LowerLeft { get => new Point(nativeQuad.LowerLeft); }
        public IPoint LowerRight { get => new Point(nativeQuad.LowerRight); }
    }
}
