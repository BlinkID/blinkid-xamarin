using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BelgiumCombinedRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class BelgiumCombinedRecognizer : Recognizer, IBelgiumCombinedRecognizer
    {
        MBBelgiumCombinedRecognizer nativeRecognizer;

        BelgiumCombinedRecognizerResult result;

        public BelgiumCombinedRecognizer() : base(new MBBelgiumCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBBelgiumCombinedRecognizer;
            result = new BelgiumCombinedRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBelgiumCombinedRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
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

    public sealed class BelgiumCombinedRecognizerResult : RecognizerResult, IBelgiumCombinedRecognizerResult
    {
        MBBelgiumCombinedRecognizerResult nativeResult;

        internal BelgiumCombinedRecognizerResult(MBBelgiumCombinedRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string CardNumber => nativeResult.CardNumber;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public byte[] DigitalSignature => nativeResult.DigitalSignature != null ? nativeResult.DigitalSignature.ToArray() : null;
        public uint DigitalSignatureVersion => (uint)nativeResult.DigitalSignatureVersion;
        public DataMatchResult DocumentDataMatch => (DataMatchResult)nativeResult.DocumentDataMatch;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentBackImage => nativeResult.FullDocumentBackImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentBackImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => nativeResult.FullDocumentFrontImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentFrontImage.Image) : null;
        public string IssuedBy => nativeResult.IssuedBy;
        public string LastName => nativeResult.LastName;
        public bool MrzVerified => nativeResult.MrzVerified;
        public string NationalRegisterNumber => nativeResult.NationalRegisterNumber;
        public string Nationality => nativeResult.Nationality;
        public bool ScanningFirstSideDone => nativeResult.ScanningFirstSideDone;
        public string Sex => nativeResult.Sex;
    }
}