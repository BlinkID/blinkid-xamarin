using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BruneiTemporaryResidencePermitFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class BruneiTemporaryResidencePermitFrontRecognizer : Recognizer, IBruneiTemporaryResidencePermitFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiTemporaryResidencePermitFrontRecognizer nativeRecognizer;

        BruneiTemporaryResidencePermitFrontRecognizerResult result;

        public BruneiTemporaryResidencePermitFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiTemporaryResidencePermitFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiTemporaryResidencePermitFrontRecognizer;
            result = new BruneiTemporaryResidencePermitFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiTemporaryResidencePermitFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBruneiTemporaryResidencePermitFrontRecognizerResult Result => result;

        
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
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractDateOfBirth(); 
            set => nativeRecognizer.SetExtractDateOfBirth(value);
        }
        
        public bool ExtractFullName 
        { 
            get => nativeRecognizer.ShouldExtractFullName(); 
            set => nativeRecognizer.SetExtractFullName(value);
        }
        
        public bool ExtractPlaceOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractPlaceOfBirth(); 
            set => nativeRecognizer.SetExtractPlaceOfBirth(value);
        }
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ShouldExtractSex(); 
            set => nativeRecognizer.SetExtractSex(value);
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

    public sealed class BruneiTemporaryResidencePermitFrontRecognizerResult : RecognizerResult, IBruneiTemporaryResidencePermitFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiTemporaryResidencePermitFrontRecognizer.Result nativeResult;

        internal BruneiTemporaryResidencePermitFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiTemporaryResidencePermitFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string FullName => nativeResult.FullName;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public string Sex => nativeResult.Sex;
    }
}