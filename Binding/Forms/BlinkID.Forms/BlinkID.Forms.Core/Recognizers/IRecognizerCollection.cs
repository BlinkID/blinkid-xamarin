using System;
namespace Microblink.Forms.Core.Recognizers
{
    public interface IRecognizerCollection
    {
        bool AllowMultipleResults { get; set; }
        uint MilisecondsBeforeTimeout { get; set; }

        IRecognizer[] Recognizers { get; }
    }

    public interface IRecognizerCollectionFactory
    {
        IRecognizerCollection CreateRecognizerCollection(params IRecognizer[] recognizers);
    }
}
