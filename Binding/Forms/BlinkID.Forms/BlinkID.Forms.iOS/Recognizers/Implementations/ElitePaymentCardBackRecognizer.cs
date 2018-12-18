using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(ElitePaymentCardBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class ElitePaymentCardBackRecognizer : Recognizer, IElitePaymentCardBackRecognizer
    {
        MBElitePaymentCardBackRecognizer nativeRecognizer;

        ElitePaymentCardBackRecognizerResult result;

        public ElitePaymentCardBackRecognizer() : base(new MBElitePaymentCardBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBElitePaymentCardBackRecognizer;
            result = new ElitePaymentCardBackRecognizerResult(nativeRecognizer.Result);
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
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractInventoryNumber 
        { 
            get => nativeRecognizer.ExtractInventoryNumber; 
            set => nativeRecognizer.ExtractInventoryNumber = value;
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

    public sealed class ElitePaymentCardBackRecognizerResult : RecognizerResult, IElitePaymentCardBackRecognizerResult
    {
        MBElitePaymentCardBackRecognizerResult nativeResult;

        internal ElitePaymentCardBackRecognizerResult(MBElitePaymentCardBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string CardNumber => nativeResult.CardNumber;
        public string Cvv => nativeResult.Cvv;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string InventoryNumber => nativeResult.InventoryNumber;
        public IDate ValidThru => nativeResult.ValidThru != null ? new Date(nativeResult.ValidThru) : null;
    }
}