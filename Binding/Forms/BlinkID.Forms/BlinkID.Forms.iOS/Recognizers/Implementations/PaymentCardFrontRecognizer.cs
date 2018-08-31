using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(PaymentCardFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class PaymentCardFrontRecognizer : Recognizer, IPaymentCardFrontRecognizer
    {
        MBPaymentCardFrontRecognizer nativeRecognizer;

        PaymentCardFrontRecognizerResult result;

        public PaymentCardFrontRecognizer() : base(new MBPaymentCardFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBPaymentCardFrontRecognizer;
            result = new PaymentCardFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IPaymentCardFrontRecognizerResult Result => result;

        
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
        
        public bool ExtractValidThru 
        { 
            get => nativeRecognizer.ExtractValidThru; 
            set => nativeRecognizer.ExtractValidThru = value;
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
    }

    public sealed class PaymentCardFrontRecognizerResult : RecognizerResult, IPaymentCardFrontRecognizerResult
    {
        MBPaymentCardFrontRecognizerResult nativeResult;

        internal PaymentCardFrontRecognizerResult(MBPaymentCardFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string CardNumber => nativeResult.CardNumber;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string Owner => nativeResult.Owner;
        public IDate ValidThru => nativeResult.ValidThru != null ? new Date(nativeResult.ValidThru) : null;
    }
}