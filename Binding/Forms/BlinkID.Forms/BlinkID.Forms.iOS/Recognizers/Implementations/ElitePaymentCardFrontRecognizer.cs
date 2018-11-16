using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(ElitePaymentCardFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class ElitePaymentCardFrontRecognizer : Recognizer, IElitePaymentCardFrontRecognizer
    {
        MBElitePaymentCardFrontRecognizer nativeRecognizer;

        ElitePaymentCardFrontRecognizerResult result;

        public ElitePaymentCardFrontRecognizer() : base(new MBElitePaymentCardFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBElitePaymentCardFrontRecognizer;
            result = new ElitePaymentCardFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IElitePaymentCardFrontRecognizerResult Result => result;

        
        public bool AnonymizeOwner 
        { 
            get => nativeRecognizer.AnonymizeOwner; 
            set => nativeRecognizer.AnonymizeOwner = value;
        }
        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractOwner 
        { 
            get => nativeRecognizer.ExtractOwner; 
            set => nativeRecognizer.ExtractOwner = value;
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = value;
        }
        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeFactors;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
    }

    public sealed class ElitePaymentCardFrontRecognizerResult : RecognizerResult, IElitePaymentCardFrontRecognizerResult
    {
        MBElitePaymentCardFrontRecognizerResult nativeResult;

        internal ElitePaymentCardFrontRecognizerResult(MBElitePaymentCardFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string Owner => nativeResult.Owner;
    }
}