using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(GermanyCombinedRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class GermanyCombinedRecognizer : Recognizer, IGermanyCombinedRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyCombinedRecognizer nativeRecognizer;

        GermanyCombinedRecognizerResult result;

        public GermanyCombinedRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyCombinedRecognizer;
            result = new GermanyCombinedRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyCombinedRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IGermanyCombinedRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractAddress 
        { 
            get => nativeRecognizer.ShouldExtractAddress(); 
            set => nativeRecognizer.SetExtractAddress(value);
        }
        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeImageExtensionFactors;
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
        
        public bool SignResult 
        { 
            get => nativeRecognizer.ShouldSignResult(); 
            set => nativeRecognizer.SetSignResult(value);
        }
        
    }

    public sealed class GermanyCombinedRecognizerResult : RecognizerResult, IGermanyCombinedRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyCombinedRecognizer.Result nativeResult;

        internal GermanyCombinedRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyCombinedRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public string CanNumber => nativeResult.CanNumber;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public byte[] DigitalSignature => nativeResult.GetDigitalSignature();
        public uint DigitalSignatureVersion => (uint)nativeResult.DigitalSignatureVersion;
        public bool DocumentDataMatch => nativeResult.IsDocumentDataMatch;
        public string EyeColor => nativeResult.EyeColor;
        public Xamarin.Forms.ImageSource FaceImage => Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap());
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentBackImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentBackImage.ConvertToBitmap());
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentFrontImage.ConvertToBitmap());
        public string Height => nativeResult.Height;
        public string IdentityCardNumber => nativeResult.IdentityCardNumber;
        public string IssuingAuthority => nativeResult.IssuingAuthority;
        public string LastName => nativeResult.LastName;
        public bool MrzVerified => nativeResult.IsMrzVerified;
        public string Nationality => nativeResult.Nationality;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public bool ScanningFirstSideDone => nativeResult.IsScanningFirstSideDone;
        public string Sex => nativeResult.Sex;
        public Xamarin.Forms.ImageSource SignatureImage => Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap());
    }
}