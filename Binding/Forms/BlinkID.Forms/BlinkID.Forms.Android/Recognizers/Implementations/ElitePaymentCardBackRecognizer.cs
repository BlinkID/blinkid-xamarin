using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(ElitePaymentCardBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class ElitePaymentCardBackRecognizer : Recognizer, IElitePaymentCardBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Elitepaymentcard.ElitePaymentCardBackRecognizer nativeRecognizer;

        ElitePaymentCardBackRecognizerResult result;

        public ElitePaymentCardBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Elitepaymentcard.ElitePaymentCardBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Elitepaymentcard.ElitePaymentCardBackRecognizer;
            result = new ElitePaymentCardBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Elitepaymentcard.ElitePaymentCardBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IElitePaymentCardBackRecognizerResult Result => result;

        
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
        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractCvv 
        { 
            get => nativeRecognizer.ShouldExtractCvv(); 
            set => nativeRecognizer.SetExtractCvv(value);
        }
        
        public bool ExtractInventoryNumber 
        { 
            get => nativeRecognizer.ShouldExtractInventoryNumber(); 
            set => nativeRecognizer.SetExtractInventoryNumber(value);
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
        
    }

    public sealed class ElitePaymentCardBackRecognizerResult : RecognizerResult, IElitePaymentCardBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Elitepaymentcard.ElitePaymentCardBackRecognizer.Result nativeResult;

        internal ElitePaymentCardBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Elitepaymentcard.ElitePaymentCardBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string CardNumber => nativeResult.CardNumber;
        public string Cvv => nativeResult.Cvv;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string InventoryNumber => nativeResult.InventoryNumber;
        public IDate ValidThru => nativeResult.ValidThru.Date != null ? new Date(nativeResult.ValidThru.Date) : null;
    }
}