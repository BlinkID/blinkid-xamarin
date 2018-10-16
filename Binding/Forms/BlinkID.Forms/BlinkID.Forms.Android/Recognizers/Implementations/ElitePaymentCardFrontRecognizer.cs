using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(ElitePaymentCardFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class ElitePaymentCardFrontRecognizer : Recognizer, IElitePaymentCardFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Elitepaymentcard.ElitePaymentCardFrontRecognizer nativeRecognizer;

        ElitePaymentCardFrontRecognizerResult result;

        public ElitePaymentCardFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Elitepaymentcard.ElitePaymentCardFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Elitepaymentcard.ElitePaymentCardFrontRecognizer;
            result = new ElitePaymentCardFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Elitepaymentcard.ElitePaymentCardFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IElitePaymentCardFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractOwner 
        { 
            get => nativeRecognizer.ShouldExtractOwner(); 
            set => nativeRecognizer.SetExtractOwner(value);
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = (int)value;
        }
        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeImageExtensionFactors;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
    }

    public sealed class ElitePaymentCardFrontRecognizerResult : RecognizerResult, IElitePaymentCardFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Elitepaymentcard.ElitePaymentCardFrontRecognizer.Result nativeResult;

        internal ElitePaymentCardFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Elitepaymentcard.ElitePaymentCardFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string Owner => nativeResult.Owner;
    }
}