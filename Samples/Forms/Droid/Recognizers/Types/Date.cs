using BlinkIDFormsSample.Droid.Recognizers;
using BlinkIDFormsSample.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(Date))]
namespace BlinkIDFormsSample.Droid.Recognizers
{
	public class Date : IDate
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
}
