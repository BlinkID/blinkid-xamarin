using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BruneiMilitaryIdFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class BruneiMilitaryIdFrontRecognizer : Recognizer, IBruneiMilitaryIdFrontRecognizer
    {
        MBBruneiMilitaryIdFrontRecognizer nativeRecognizer;

        BruneiMilitaryIdFrontRecognizerResult result;

        public BruneiMilitaryIdFrontRecognizer() : base(new MBBruneiMilitaryIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBBruneiMilitaryIdFrontRecognizer;
            result = new BruneiMilitaryIdFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBruneiMilitaryIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractFullName 
        { 
            get => nativeRecognizer.ExtractFullName; 
            set => nativeRecognizer.ExtractFullName = value;
        }
        
        public bool ExtractRank 
        { 
            get => nativeRecognizer.ExtractRank; 
            set => nativeRecognizer.ExtractRank = value;
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
        
    }

    public sealed class BruneiMilitaryIdFrontRecognizerResult : RecognizerResult, IBruneiMilitaryIdFrontRecognizerResult
    {
        MBBruneiMilitaryIdFrontRecognizerResult nativeResult;

        internal BruneiMilitaryIdFrontRecognizerResult(MBBruneiMilitaryIdFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string FullName => nativeResult.FullName;
        public string Rank => nativeResult.Rank;
    }
}