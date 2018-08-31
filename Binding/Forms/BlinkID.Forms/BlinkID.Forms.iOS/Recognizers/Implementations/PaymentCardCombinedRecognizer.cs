using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(PaymentCardCombinedRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class PaymentCardCombinedRecognizer : Recognizer, IPaymentCardCombinedRecognizer
    {
        MBPaymentCardCombinedRecognizer nativeRecognizer;

        PaymentCardCombinedRecognizerResult result;

        public PaymentCardCombinedRecognizer() : base(new MBPaymentCardCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBPaymentCardCombinedRecognizer;
            result = new PaymentCardCombinedRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IPaymentCardCombinedRecognizerResult Result => result;

        
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
        
        public bool SignResult 
        { 
            get => nativeRecognizer.SignResult; 
            set => nativeRecognizer.SignResult = value;
        }
        
    }

    public sealed class PaymentCardCombinedRecognizerResult : RecognizerResult, IPaymentCardCombinedRecognizerResult
    {
        MBPaymentCardCombinedRecognizerResult nativeResult;

        internal PaymentCardCombinedRecognizerResult(MBPaymentCardCombinedRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string CardNumber => nativeResult.CardNumber;
        public string Cvv => nativeResult.Cvv;
        public byte[] DigitalSignature => nativeResult.DigitalSignature != null ? nativeResult.DigitalSignature.ToArray() : null;
        public uint DigitalSignatureVersion => (uint)nativeResult.DigitalSignatureVersion;
        public bool DocumentDataMatch => nativeResult.DocumentDataMatch;
        public Xamarin.Forms.ImageSource FullDocumentBackImage => nativeResult.FullDocumentBackImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentBackImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => nativeResult.FullDocumentFrontImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentFrontImage.Image) : null;
        public string InventoryNumber => nativeResult.InventoryNumber;
        public string Owner => nativeResult.Owner;
        public bool ScanningFirstSideDone => nativeResult.ScanningFirstSideDone;
        public IDate ValidThru => nativeResult.ValidThru != null ? new Date(nativeResult.ValidThru) : null;
    }
}