using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(AustraliaDlFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class AustraliaDlFrontRecognizer : Recognizer, IAustraliaDlFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Australia.AustraliaDlFrontRecognizer nativeRecognizer;

        AustraliaDlFrontRecognizerResult result;

        public AustraliaDlFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Australia.AustraliaDlFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Australia.AustraliaDlFrontRecognizer;
            result = new AustraliaDlFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Australia.AustraliaDlFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IAustraliaDlFrontRecognizerResult Result => result;

        
        public bool ExtractAddress 
        { 
            get => nativeRecognizer.ShouldExtractAddress(); 
            set => nativeRecognizer.SetExtractAddress(value);
        }
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractDateOfBirth(); 
            set => nativeRecognizer.SetExtractDateOfBirth(value);
        }
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ShouldExtractDateOfExpiry(); 
            set => nativeRecognizer.SetExtractDateOfExpiry(value);
        }
        
        public bool ExtractLicenceNumber 
        { 
            get => nativeRecognizer.ShouldExtractLicenceNumber(); 
            set => nativeRecognizer.SetExtractLicenceNumber(value);
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = (int)value;
        }
        
        public bool ReturnFaceImage 
        { 
            get => nativeRecognizer.ShouldReturnFaceImage(); 
            set => nativeRecognizer.SetReturnFaceImage(value);
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
        public bool ReturnSignatureImage 
        { 
            get => nativeRecognizer.ShouldReturnSignatureImage(); 
            set => nativeRecognizer.SetReturnSignatureImage(value);
        }
        
    }

    public sealed class AustraliaDlFrontRecognizerResult : RecognizerResult, IAustraliaDlFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Australia.AustraliaDlFrontRecognizer.Result nativeResult;

        internal AustraliaDlFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Australia.AustraliaDlFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public Xamarin.Forms.ImageSource FaceImage => Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap());
        public Xamarin.Forms.ImageSource FullDocumentImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap());
        public string LicenceNumber => nativeResult.LicenceNumber;
        public string LicenceType => nativeResult.LicenceType;
        public string Name => nativeResult.Name;
        public Xamarin.Forms.ImageSource SignatureImage => Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap());
    }
}