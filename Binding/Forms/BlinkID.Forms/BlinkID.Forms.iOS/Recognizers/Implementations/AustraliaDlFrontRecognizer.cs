using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(AustraliaDlFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class AustraliaDlFrontRecognizer : Recognizer, IAustraliaDlFrontRecognizer
    {
        MBAustraliaDlFrontRecognizer nativeRecognizer;

        AustraliaDlFrontRecognizerResult result;

        public AustraliaDlFrontRecognizer() : base(new MBAustraliaDlFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBAustraliaDlFrontRecognizer;
            result = new AustraliaDlFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IAustraliaDlFrontRecognizerResult Result => result;

        
        public bool ExtractAddress 
        { 
            get => nativeRecognizer.ExtractAddress; 
            set => nativeRecognizer.ExtractAddress = value;
        }
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ExtractDateOfBirth; 
            set => nativeRecognizer.ExtractDateOfBirth = value;
        }
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ExtractDateOfExpiry; 
            set => nativeRecognizer.ExtractDateOfExpiry = value;
        }
        
        public bool ExtractLicenceNumber 
        { 
            get => nativeRecognizer.ExtractLicenceNumber; 
            set => nativeRecognizer.ExtractLicenceNumber = value;
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = value;
        }
        
        public bool ReturnFaceImage 
        { 
            get => nativeRecognizer.ReturnFaceImage; 
            set => nativeRecognizer.ReturnFaceImage = value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
        public bool ReturnSignatureImage 
        { 
            get => nativeRecognizer.ReturnSignatureImage; 
            set => nativeRecognizer.ReturnSignatureImage = value;
        }
        
    }

    public sealed class AustraliaDlFrontRecognizerResult : RecognizerResult, IAustraliaDlFrontRecognizerResult
    {
        MBAustraliaDlFrontRecognizerResult nativeResult;

        internal AustraliaDlFrontRecognizerResult(MBAustraliaDlFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string LicenceNumber => nativeResult.LicenceNumber;
        public string LicenceType => nativeResult.LicenceType;
        public string Name => nativeResult.Name;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertUIImage(nativeResult.SignatureImage.Image) : null;
    }
}