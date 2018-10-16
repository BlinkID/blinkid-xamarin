using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(PaymentCardBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class PaymentCardBackRecognizer : Recognizer, IPaymentCardBackRecognizer
    {
        MBPaymentCardBackRecognizer nativeRecognizer;

        PaymentCardBackRecognizerResult result;

        public PaymentCardBackRecognizer() : base(new MBPaymentCardBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBPaymentCardBackRecognizer;
            result = new PaymentCardBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IPaymentCardBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractInventoryNumber 
        { 
            get => nativeRecognizer.ExtractInventoryNumber; 
            set => nativeRecognizer.ExtractInventoryNumber = value;
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

    public sealed class PaymentCardBackRecognizerResult : RecognizerResult, IPaymentCardBackRecognizerResult
    {
        MBPaymentCardBackRecognizerResult nativeResult;

        internal PaymentCardBackRecognizerResult(MBPaymentCardBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Cvv => nativeResult.Cvv;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string InventoryNumber => nativeResult.InventoryNumber;
    }
}