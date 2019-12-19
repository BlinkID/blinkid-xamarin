using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BlinkIdCombinedRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class BlinkIdCombinedRecognizer : Recognizer, IBlinkIdCombinedRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Generic.BlinkIdCombinedRecognizer nativeRecognizer;

        BlinkIdCombinedRecognizerResult result;

        public BlinkIdCombinedRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Generic.BlinkIdCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Generic.BlinkIdCombinedRecognizer;
            result = new BlinkIdCombinedRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Generic.BlinkIdCombinedRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBlinkIdCombinedRecognizerResult Result => result;

        
        public bool AllowBlurFilter 
        { 
            get => nativeRecognizer.ShouldAllowBlurFilter(); 
            set => nativeRecognizer.SetAllowBlurFilter(value);
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
        
    }

    public sealed class BlinkIdCombinedRecognizerResult : RecognizerResult, IBlinkIdCombinedRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Generic.BlinkIdCombinedRecognizer.Result nativeResult;

        internal BlinkIdCombinedRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Generic.BlinkIdCombinedRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string AdditionalAddressInformation => nativeResult.AdditionalAddressInformation;
        public string AdditionalNameInformation => nativeResult.AdditionalNameInformation;
        public string Address => nativeResult.Address;
        public string Conditions => nativeResult.Conditions;
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry.Date != null ? new Date(nativeResult.DateOfExpiry.Date) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue.Date != null ? new Date(nativeResult.DateOfIssue.Date) : null;
        public string DocumentAdditionalNumber => nativeResult.DocumentAdditionalNumber;
        public DataMatchResult DocumentDataMatch => (DataMatchResult)nativeResult.DocumentDataMatch.Ordinal();
        public string DocumentNumber => nativeResult.DocumentNumber;
        public IDriverLicenseDetailedInfo DriverLicenseDetailedInfo => new DriverLicenseDetailedInfo(nativeResult.DriverLicenseDetailedInfo);
        public string Employer => nativeResult.Employer;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentBackImage => nativeResult.FullDocumentBackImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentBackImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => nativeResult.FullDocumentFrontImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentFrontImage.ConvertToBitmap()) : null;
        public string FullName => nativeResult.FullName;
        public string IssuingAuthority => nativeResult.IssuingAuthority;
        public string LastName => nativeResult.LastName;
        public string MaritalStatus => nativeResult.MaritalStatus;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string Nationality => nativeResult.Nationality;
        public string PersonalIdNumber => nativeResult.PersonalIdNumber;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public string Profession => nativeResult.Profession;
        public string Race => nativeResult.Race;
        public string Religion => nativeResult.Religion;
        public string ResidentialStatus => nativeResult.ResidentialStatus;
        public bool ScanningFirstSideDone => nativeResult.IsScanningFirstSideDone;
        public string Sex => nativeResult.Sex;
    }
}