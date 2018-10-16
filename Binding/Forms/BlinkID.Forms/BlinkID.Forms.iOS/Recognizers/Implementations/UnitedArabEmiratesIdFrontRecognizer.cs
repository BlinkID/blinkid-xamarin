using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(UnitedArabEmiratesIdFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class UnitedArabEmiratesIdFrontRecognizer : Recognizer, IUnitedArabEmiratesIdFrontRecognizer
    {
        MBUnitedArabEmiratesIdFrontRecognizer nativeRecognizer;

        UnitedArabEmiratesIdFrontRecognizerResult result;

        public UnitedArabEmiratesIdFrontRecognizer() : base(new MBUnitedArabEmiratesIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBUnitedArabEmiratesIdFrontRecognizer;
            result = new UnitedArabEmiratesIdFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IUnitedArabEmiratesIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractName 
        { 
            get => nativeRecognizer.ExtractName; 
            set => nativeRecognizer.ExtractName = value;
        }
        
        public bool ExtractNationality 
        { 
            get => nativeRecognizer.ExtractNationality; 
            set => nativeRecognizer.ExtractNationality = value;
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

    public sealed class UnitedArabEmiratesIdFrontRecognizerResult : RecognizerResult, IUnitedArabEmiratesIdFrontRecognizerResult
    {
        MBUnitedArabEmiratesIdFrontRecognizerResult nativeResult;

        internal UnitedArabEmiratesIdFrontRecognizerResult(MBUnitedArabEmiratesIdFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string IdNumber => nativeResult.IdNumber;
        public string Name => nativeResult.Name;
        public string Nationality => nativeResult.Nationality;
    }
}