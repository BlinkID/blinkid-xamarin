using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BruneiMilitaryIdFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class BruneiMilitaryIdFrontRecognizer : Recognizer, IBruneiMilitaryIdFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiMilitaryIdFrontRecognizer nativeRecognizer;

        BruneiMilitaryIdFrontRecognizerResult result;

        public BruneiMilitaryIdFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiMilitaryIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiMilitaryIdFrontRecognizer;
            result = new BruneiMilitaryIdFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiMilitaryIdFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBruneiMilitaryIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractFullName 
        { 
            get => nativeRecognizer.ShouldExtractFullName(); 
            set => nativeRecognizer.SetExtractFullName(value);
        }
        
        public bool ExtractRank 
        { 
            get => nativeRecognizer.ShouldExtractRank(); 
            set => nativeRecognizer.SetExtractRank(value);
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

    public sealed class BruneiMilitaryIdFrontRecognizerResult : RecognizerResult, IBruneiMilitaryIdFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiMilitaryIdFrontRecognizer.Result nativeResult;

        internal BruneiMilitaryIdFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiMilitaryIdFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string FullName => nativeResult.FullName;
        public string Rank => nativeResult.Rank;
    }
}