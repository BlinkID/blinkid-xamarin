using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(PaymentCardCombinedRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class PaymentCardCombinedRecognizer : Recognizer, IPaymentCardCombinedRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Paymentcard.PaymentCardCombinedRecognizer nativeRecognizer;

        PaymentCardCombinedRecognizerResult result;

        public PaymentCardCombinedRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Paymentcard.PaymentCardCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Paymentcard.PaymentCardCombinedRecognizer;
            result = new PaymentCardCombinedRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Paymentcard.PaymentCardCombinedRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IPaymentCardCombinedRecognizerResult Result => result;

        
        public bool AnonymizeCardNumber 
        { 
            get => nativeRecognizer.AnonymizeCardNumber; 
            set => nativeRecognizer.AnonymizeCardNumber = value;
        }
        
        public bool AnonymizeCvv 
        { 
            get => nativeRecognizer.AnonymizeCvv; 
            set => nativeRecognizer.AnonymizeCvv = value;
        }
        
        public bool AnonymizeOwner 
        { 
            get => nativeRecognizer.AnonymizeOwner; 
            set => nativeRecognizer.AnonymizeOwner = value;
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
        
        public bool SignResult 
        { 
            get => nativeRecognizer.ShouldSignResult(); 
            set => nativeRecognizer.SetSignResult(value);
        }
        
    }

    public sealed class PaymentCardCombinedRecognizerResult : RecognizerResult, IPaymentCardCombinedRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Paymentcard.PaymentCardCombinedRecognizer.Result nativeResult;

        internal PaymentCardCombinedRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Paymentcard.PaymentCardCombinedRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string CardNumber => nativeResult.CardNumber;
        public string Cvv => nativeResult.Cvv;
        public byte[] DigitalSignature => nativeResult.GetDigitalSignature();
        public uint DigitalSignatureVersion => (uint)nativeResult.DigitalSignatureVersion;
        public bool DocumentDataMatch => nativeResult.IsDocumentDataMatch;
        public Xamarin.Forms.ImageSource FullDocumentBackImage => nativeResult.FullDocumentBackImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentBackImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => nativeResult.FullDocumentFrontImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentFrontImage.ConvertToBitmap()) : null;
        public string InventoryNumber => nativeResult.InventoryNumber;
        public string Owner => nativeResult.Owner;
        public bool ScanningFirstSideDone => nativeResult.IsScanningFirstSideDone;
        public IDate ValidThru => nativeResult.ValidThru.Date != null ? new Date(nativeResult.ValidThru.Date) : null;
    }
}