using System;
using Xamarin.Forms;

namespace Microblink.Forms.Core.Recognizers
{
    public interface IMrtdRecognizer : IRecognizer
    {
        IMrtdRecognizerResult Result { get; }

        bool AllowUnparsedResults { get; set; }
        bool AllowUnverifiedResults { get; set; }
        bool DetectGlare { get; set; }
        bool ReturnFullDocumentImage { get; set; }
        bool ReturnMrzImage { get; set; }
        int SaveImageDPI { get; set; }
    }

    public interface IMrtdRecognizerResult : IRecognizerResult {
        ImageSource FullDocumentImage { get; }
        ImageSource MrzImage { get; }
        IMrzResult MrzResult { get; }
    }
}
