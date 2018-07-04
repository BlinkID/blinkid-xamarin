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
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        Xamarin.Forms.ImageSource MrzImage { get; }
        IMrzResult MrzResult { get; }
    }
}
