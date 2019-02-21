using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BlinkCardRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class BlinkCardRecognizer : Recognizer, IBlinkCardRecognizer
    {
        MBBlinkCardRecognizer nativeRecognizer;

        BlinkCardRecognizerResult result;

        public BlinkCardRecognizer() : base(new MBBlinkCardRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBBlinkCardRecognizer;
            result = new BlinkCardRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBlinkCardRecognizerResult Result => result;

        
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
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractCvv 
        { 
            get => nativeRecognizer.ExtractCvv; 
            set => nativeRecognizer.ExtractCvv = value;
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
        
        public bool SignResult 
        { 
            get => nativeRecognizer.SignResult; 
            set => nativeRecognizer.SignResult = value;
        }
        
    }

    public sealed class BlinkCardRecognizerResult : RecognizerResult, IBlinkCardRecognizerResult
    {
        MBBlinkCardRecognizerResult nativeResult;

        internal BlinkCardRecognizerResult(MBBlinkCardRecognizerResult nativeResult) : base(nativeResult)
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
        public CardIssuer Issuer => (CardIssuer)nativeResult.Issuer;
        public string Owner => nativeResult.Owner;
        public bool ScanningFirstSideDone => nativeResult.ScanningFirstSideDone;
        public IDate ValidThru => nativeResult.ValidThru != null ? new Date(nativeResult.ValidThru) : null;
    }
}