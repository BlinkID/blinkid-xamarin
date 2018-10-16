using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SwitzerlandDlFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SwitzerlandDlFrontRecognizer : Recognizer, ISwitzerlandDlFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandDlFrontRecognizer nativeRecognizer;

        SwitzerlandDlFrontRecognizerResult result;

        public SwitzerlandDlFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandDlFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandDlFrontRecognizer;
            result = new SwitzerlandDlFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandDlFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISwitzerlandDlFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
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
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ShouldExtractDateOfIssue(); 
            set => nativeRecognizer.SetExtractDateOfIssue(value);
        }
        
        public bool ExtractFirstName 
        { 
            get => nativeRecognizer.ShouldExtractFirstName(); 
            set => nativeRecognizer.SetExtractFirstName(value);
        }
        
        public bool ExtractIssuingAuthority 
        { 
            get => nativeRecognizer.ShouldExtractIssuingAuthority(); 
            set => nativeRecognizer.SetExtractIssuingAuthority(value);
        }
        
        public bool ExtractLastName 
        { 
            get => nativeRecognizer.ShouldExtractLastName(); 
            set => nativeRecognizer.SetExtractLastName(value);
        }
        
        public bool ExtractPlaceOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractPlaceOfBirth(); 
            set => nativeRecognizer.SetExtractPlaceOfBirth(value);
        }
        
        public bool ExtractVehicleCategories 
        { 
            get => nativeRecognizer.ShouldExtractVehicleCategories(); 
            set => nativeRecognizer.SetExtractVehicleCategories(value);
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
        
        public uint SignatureImageDpi 
        { 
            get => (uint)nativeRecognizer.SignatureImageDpi; 
            set => nativeRecognizer.SignatureImageDpi = (int)value;
        }
        
    }

    public sealed class SwitzerlandDlFrontRecognizerResult : RecognizerResult, ISwitzerlandDlFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandDlFrontRecognizer.Result nativeResult;

        internal SwitzerlandDlFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandDlFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry.Date != null ? new Date(nativeResult.DateOfExpiry.Date) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue.Date != null ? new Date(nativeResult.DateOfIssue.Date) : null;
        public bool ExpiryDatePermanent => nativeResult.IsExpiryDatePermanent;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string IssuingAuthority => nativeResult.IssuingAuthority;
        public string LastName => nativeResult.LastName;
        public string LicenseNumber => nativeResult.LicenseNumber;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap()) : null;
        public string VehicleCategories => nativeResult.VehicleCategories;
    }
}