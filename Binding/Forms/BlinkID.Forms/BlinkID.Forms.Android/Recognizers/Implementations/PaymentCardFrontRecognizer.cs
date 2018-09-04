using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(PaymentCardFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class PaymentCardFrontRecognizer : Recognizer, IPaymentCardFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Paymentcard.PaymentCardFrontRecognizer nativeRecognizer;

        PaymentCardFrontRecognizerResult result;

        public PaymentCardFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Paymentcard.PaymentCardFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Paymentcard.PaymentCardFrontRecognizer;
            result = new PaymentCardFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Paymentcard.PaymentCardFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IPaymentCardFrontRecognizerResult Result => result;

        
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
        
        public bool ExtractValidThru 
        { 
            get => nativeRecognizer.ShouldExtractValidThru(); 
            set => nativeRecognizer.SetExtractValidThru(value);
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = (int)value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
    }

    public sealed class PaymentCardFrontRecognizerResult : RecognizerResult, IPaymentCardFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Paymentcard.PaymentCardFrontRecognizer.Result nativeResult;

        internal PaymentCardFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Paymentcard.PaymentCardFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string CardNumber => nativeResult.CardNumber;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string Owner => nativeResult.Owner;
        public IDate ValidThru => nativeResult.ValidThru.Date != null ? new Date(nativeResult.ValidThru.Date) : null;
    }
}