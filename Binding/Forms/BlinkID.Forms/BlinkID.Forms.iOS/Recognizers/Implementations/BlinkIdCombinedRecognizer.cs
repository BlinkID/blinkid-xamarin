using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BlinkIdCombinedRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class BlinkIdCombinedRecognizer : Recognizer, IBlinkIdCombinedRecognizer
    {
        MBBlinkIdCombinedRecognizer nativeRecognizer;

        BlinkIdCombinedRecognizerResult result;

        public BlinkIdCombinedRecognizer() : base(new MBBlinkIdCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBBlinkIdCombinedRecognizer;
            result = new BlinkIdCombinedRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBlinkIdCombinedRecognizerResult Result => result;

        
        public uint FaceImageDpi 
        { 
            get => (uint)nativeRecognizer.FaceImageDpi; 
            set => nativeRecognizer.FaceImageDpi = value;
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
        
        public bool SignResult 
        { 
            get => nativeRecognizer.SignResult; 
            set => nativeRecognizer.SignResult = value;
        }
        
    }

    public sealed class BlinkIdCombinedRecognizerResult : RecognizerResult, IBlinkIdCombinedRecognizerResult
    {
        MBBlinkIdCombinedRecognizerResult nativeResult;

        internal BlinkIdCombinedRecognizerResult(MBBlinkIdCombinedRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public byte[] DigitalSignature => nativeResult.DigitalSignature != null ? nativeResult.DigitalSignature.ToArray() : null;
        public uint DigitalSignatureVersion => (uint)nativeResult.DigitalSignatureVersion;
        public bool DocumentDataMatch => nativeResult.DocumentDataMatch;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public IDriverLicenseDetailedInfo DriverLicenseDetailedInfo => new DriverLicenseDetailedInfo(nativeResult.DriverLicenseDetailedInfo);
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string FullName => nativeResult.FullName;
        public string LastName => nativeResult.LastName;
        public bool ScanningFirstSideDone => nativeResult.ScanningFirstSideDone;
        public string Sex => nativeResult.Sex;
    }
}