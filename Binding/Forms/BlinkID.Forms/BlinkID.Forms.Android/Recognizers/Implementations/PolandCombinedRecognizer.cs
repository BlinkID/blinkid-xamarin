using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(PolandCombinedRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class PolandCombinedRecognizer : Recognizer, IPolandCombinedRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandCombinedRecognizer nativeRecognizer;

        PolandCombinedRecognizerResult result;

        public PolandCombinedRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandCombinedRecognizer;
            result = new PolandCombinedRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandCombinedRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IPolandCombinedRecognizerResult Result => result;

        
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
        
        public bool ExtractFamilyName 
        { 
            get => nativeRecognizer.ShouldExtractFamilyName(); 
            set => nativeRecognizer.SetExtractFamilyName(value);
        }
        
        public bool ExtractGivenNames 
        { 
            get => nativeRecognizer.ShouldExtractGivenNames(); 
            set => nativeRecognizer.SetExtractGivenNames(value);
        }
        
        public bool ExtractParentsGivenNames 
        { 
            get => nativeRecognizer.ShouldExtractParentsGivenNames(); 
            set => nativeRecognizer.SetExtractParentsGivenNames(value);
        }
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ShouldExtractSex(); 
            set => nativeRecognizer.SetExtractSex(value);
        }
        
        public bool ExtractSurname 
        { 
            get => nativeRecognizer.ShouldExtractSurname(); 
            set => nativeRecognizer.SetExtractSurname(value);
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
        
        public bool SignResult 
        { 
            get => nativeRecognizer.ShouldSignResult(); 
            set => nativeRecognizer.SetSignResult(value);
        }
        
    }

    public sealed class PolandCombinedRecognizerResult : RecognizerResult, IPolandCombinedRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandCombinedRecognizer.Result nativeResult;

        internal PolandCombinedRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandCombinedRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public byte[] DigitalSignature => nativeResult.GetDigitalSignature();
        public uint DigitalSignatureVersion => (uint)nativeResult.DigitalSignatureVersion;
        public bool DocumentDataMatch => nativeResult.IsDocumentDataMatch;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public string FamilyName => nativeResult.FamilyName;
        public Xamarin.Forms.ImageSource FullDocumentBackImage => nativeResult.FullDocumentBackImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentBackImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => nativeResult.FullDocumentFrontImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentFrontImage.ConvertToBitmap()) : null;
        public string GivenNames => nativeResult.GivenNames;
        public string Issuer => nativeResult.Issuer;
        public bool MrzVerified => nativeResult.IsMrzVerified;
        public string Nationality => nativeResult.Nationality;
        public string ParentsGivenNames => nativeResult.ParentsGivenNames;
        public string PersonalNumber => nativeResult.PersonalNumber;
        public bool ScanningFirstSideDone => nativeResult.IsScanningFirstSideDone;
        public string Sex => nativeResult.Sex;
        public string Surname => nativeResult.Surname;
    }
}