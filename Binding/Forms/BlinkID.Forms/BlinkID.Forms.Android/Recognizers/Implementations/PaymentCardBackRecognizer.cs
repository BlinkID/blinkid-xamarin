using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(PaymentCardBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class PaymentCardBackRecognizer : Recognizer, IPaymentCardBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Paymentcard.PaymentCardBackRecognizer nativeRecognizer;

        PaymentCardBackRecognizerResult result;

        public PaymentCardBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Paymentcard.PaymentCardBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Paymentcard.PaymentCardBackRecognizer;
            result = new PaymentCardBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Paymentcard.PaymentCardBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IPaymentCardBackRecognizerResult Result => result;

        
        public bool AnonymizeCvv 
        { 
            get => nativeRecognizer.AnonymizeCvv; 
            set => nativeRecognizer.AnonymizeCvv = value;
        }
        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractInventoryNumber 
        { 
            get => nativeRecognizer.ShouldExtractInventoryNumber(); 
            set => nativeRecognizer.SetExtractInventoryNumber(value);
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

    public sealed class PaymentCardBackRecognizerResult : RecognizerResult, IPaymentCardBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Paymentcard.PaymentCardBackRecognizer.Result nativeResult;

        internal PaymentCardBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Paymentcard.PaymentCardBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Cvv => nativeResult.Cvv;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string InventoryNumber => nativeResult.InventoryNumber;
    }
}