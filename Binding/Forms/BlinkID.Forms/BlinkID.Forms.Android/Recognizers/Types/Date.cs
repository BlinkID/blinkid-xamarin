using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(Date))]
namespace Microblink.Forms.Droid.Recognizers
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
