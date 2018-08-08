using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SingaporeCombinedRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SingaporeCombinedRecognizer : Recognizer, ISingaporeCombinedRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeCombinedRecognizer nativeRecognizer;

        SingaporeCombinedRecognizerResult result;

        public SingaporeCombinedRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeCombinedRecognizer;
            result = new SingaporeCombinedRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeCombinedRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISingaporeCombinedRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
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

    public sealed class SingaporeCombinedRecognizerResult : RecognizerResult, ISingaporeCombinedRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeCombinedRecognizer.Result nativeResult;

        internal SingaporeCombinedRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeCombinedRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public string BloodGroup => nativeResult.BloodGroup;
        public string CardNumber => nativeResult.CardNumber;
        public string CountryOfBirth => nativeResult.CountryOfBirth;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public byte[] DigitalSignature => nativeResult.GetDigitalSignature();
        public uint DigitalSignatureVersion => (uint)nativeResult.DigitalSignatureVersion;
        public bool DocumentDataMatch => nativeResult.IsDocumentDataMatch;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentBackImage => nativeResult.FullDocumentBackImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentBackImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => nativeResult.FullDocumentFrontImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentFrontImage.ConvertToBitmap()) : null;
        public string Name => nativeResult.Name;
        public string Race => nativeResult.Race;
        public bool ScanningFirstSideDone => nativeResult.IsScanningFirstSideDone;
        public string Sex => nativeResult.Sex;
    }
}