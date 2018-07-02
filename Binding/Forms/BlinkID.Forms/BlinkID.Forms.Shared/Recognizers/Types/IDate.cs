using System;
namespace Microblink.Forms.Shared.Recognizers
{
    public interface IDate
    {
        int Day { get; }
        int Month { get; }
        int Year { get; }
    }
}
