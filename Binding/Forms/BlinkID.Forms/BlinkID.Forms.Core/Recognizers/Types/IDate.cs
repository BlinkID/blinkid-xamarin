using System;
namespace Microblink.Forms.Core.Recognizers
{
    public interface IDate
    {
        int Day { get; }
        int Month { get; }
        int Year { get; }
    }
}
