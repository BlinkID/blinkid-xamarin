using BlinkIDFormsSample.iOS.Recognizers;
using BlinkIDFormsSample.Recognizers;
using Microblink;

[assembly: Xamarin.Forms.Dependency(typeof(Date))]
namespace BlinkIDFormsSample.iOS.Recognizers
{
	public class Date : IDate
    {
        MBDateResult nativeDate;

        public Date(MBDateResult nativeDate)
        {
            this.nativeDate = nativeDate;
        }

        public int Day => (int) nativeDate.Day;

        public int Month => (int) nativeDate.Month;

        public int Year => (int) nativeDate.Year;
    }
}
