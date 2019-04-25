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
        
        public bool ExtractAuthority 
        { 
            get => nativeRecognizer.ShouldExtractAuthority(); 
            set => nativeRecognizer.SetExtractAuthority(value);
        }
        
        public bool ExtractCanNumber 
        { 
            get => nativeRecognizer.ShouldExtractCanNumber(); 
            set => nativeRecognizer.SetExtractCanNumber(value);
        }
        
        public bool ExtractColourOfEyes 
        { 
            get => nativeRecognizer.ShouldExtractColourOfEyes(); 
            set => nativeRecognizer.SetExtractColourOfEyes(value);
        }
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ShouldExtractDateOfExpiry(); 
            set => nativeRecognizer.SetExtractDateOfExpiry(value);
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ShouldExtractDateOfIssue(); 
            set => nativeRecognizer.SetExtractDateOfIssue(value);
        }
        
        public bool ExtractDocumentNumber 
        { 
            get => nativeRecognizer.ShouldExtractDocumentNumber(); 
            set => nativeRecognizer.SetExtractDocumentNumber(value);
        }
        
        public bool ExtractGivenName 
        { 
            get => nativeRecognizer.ShouldExtractGivenName(); 
            set => nativeRecognizer.SetExtractGivenName(value);
        }
        
        public bool ExtractGivenNames 
        { 
            get => nativeRecognizer.ShouldExtractGivenNames(); 
            set => nativeRecognizer.SetExtractGivenNames(value);
        }
        
        public bool ExtractHeight 
        { 
            get => nativeRecognizer.ShouldExtractHeight(); 
            set => nativeRecognizer.SetExtractHeight(value);
        }
        
        public bool ExtractNationality 
        { 
            get => nativeRecognizer.ShouldExtractNationality(); 
            set => nativeRecognizer.SetExtractNationality(value);
        }
        
        public bool ExtractPlaceOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractPlaceOfBirth(); 
            set => nativeRecognizer.SetExtractPlaceOfBirth(value);
        }
        
        public bool ExtractSurname 
        { 
            get => nativeRecognizer.ShouldExtractSurname(); 
            set => nativeRecognizer.SetExtractSurname(value);
        }
        
        public uint FaceImageDpi 
        { 
            get => (uint)nativeRecognizer.FaceImageDpi; 
            set => nativeRecognizer.FaceImageDpi = (int)value;
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
        
        public uint SignatureImageDpi 
        { 
            get => (uint)nativeRecognizer.SignatureImageDpi; 
            set => nativeRecognizer.SignatureImageDpi = (int)value;
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
        public string Authority => nativeResult.Authority;
        public string CanNumber => nativeResult.CanNumber;
        public string ColourOfEyes => nativeResult.ColourOfEyes;
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry.Date != null ? new Date(nativeResult.DateOfExpiry.Date) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue.Date != null ? new Date(nativeResult.DateOfIssue.Date) : null;
        public byte[] DigitalSignature => nativeResult.GetDigitalSignature();
        public uint DigitalSignatureVersion => (uint)nativeResult.DigitalSignatureVersion;
        public bool DocumentDataMatch => nativeResult.IsDocumentDataMatch;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentBackImage => nativeResult.FullDocumentBackImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentBackImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => nativeResult.FullDocumentFrontImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentFrontImage.ConvertToBitmap()) : null;
        public string GivenNames => nativeResult.GivenNames;
        public string Height => nativeResult.Height;
        public bool MrzVerified => nativeResult.IsMrzVerified;
        public string Nationality => nativeResult.Nationality;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public string RawMrzString => nativeResult.RawMrzString;
        public bool ScanningFirstSideDone => nativeResult.IsScanningFirstSideDone;
        public string Sex => nativeResult.Sex;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap()) : null;
        public string Surname => nativeResult.Surname;
    }
}