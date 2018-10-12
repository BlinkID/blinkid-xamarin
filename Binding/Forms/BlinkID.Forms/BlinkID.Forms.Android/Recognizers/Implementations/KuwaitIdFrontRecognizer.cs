using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(KuwaitIdFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class KuwaitIdFrontRecognizer : Recognizer, IKuwaitIdFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Kuwait.KuwaitIdFrontRecognizer nativeRecognizer;

        KuwaitIdFrontRecognizerResult result;

        public KuwaitIdFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Kuwait.KuwaitIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Kuwait.KuwaitIdFrontRecognizer;
            result = new KuwaitIdFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Kuwait.KuwaitIdFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IKuwaitIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractBirthDate 
        { 
            get => nativeRecognizer.ShouldExtractBirthDate(); 
            set => nativeRecognizer.SetExtractBirthDate(value);
        }
        
        public bool ExtractName 
        { 
            get => nativeRecognizer.ShouldExtractName(); 
            set => nativeRecognizer.SetExtractName(value);
        }
        
        public bool ExtractNationality 
        { 
            get => nativeRecognizer.ShouldExtractNationality(); 
            set => nativeRecognizer.SetExtractNationality(value);
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

    public sealed class KuwaitIdFrontRecognizerResult : RecognizerResult, IKuwaitIdFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Kuwait.KuwaitIdFrontRecognizer.Result nativeResult;

        internal KuwaitIdFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Kuwait.KuwaitIdFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate BirthDate => nativeResult.BirthDate.Date != null ? new Date(nativeResult.BirthDate.Date) : null;
        public string CivilIdNumber => nativeResult.CivilIdNumber;
        public IDate ExpiryDate => nativeResult.ExpiryDate.Date != null ? new Date(nativeResult.ExpiryDate.Date) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string Name => nativeResult.Name;
        public string Nationality => nativeResult.Nationality;
        public string Sex => nativeResult.Sex;
    }
}