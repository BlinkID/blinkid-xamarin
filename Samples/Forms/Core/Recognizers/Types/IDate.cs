using System;
namespace BlinkIDFormsSample.Recognizers
{
    public interface IDate
    {
        int Day { get; }
        int Month { get; }
        int Year { get; }
    }
}
