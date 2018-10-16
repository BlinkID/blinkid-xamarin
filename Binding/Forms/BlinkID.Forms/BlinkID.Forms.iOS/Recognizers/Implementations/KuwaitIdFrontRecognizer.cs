using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(KuwaitIdFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class KuwaitIdFrontRecognizer : Recognizer, IKuwaitIdFrontRecognizer
    {
        MBKuwaitIdFrontRecognizer nativeRecognizer;

        KuwaitIdFrontRecognizerResult result;

        public KuwaitIdFrontRecognizer() : base(new MBKuwaitIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBKuwaitIdFrontRecognizer;
            result = new KuwaitIdFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IKuwaitIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractBirthDate 
        { 
            get => nativeRecognizer.ExtractBirthDate; 
            set => nativeRecognizer.ExtractBirthDate = value;
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
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ExtractSex; 
            set => nativeRecognizer.ExtractSex = value;
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

    public sealed class KuwaitIdFrontRecognizerResult : RecognizerResult, IKuwaitIdFrontRecognizerResult
    {
        MBKuwaitIdFrontRecognizerResult nativeResult;

        internal KuwaitIdFrontRecognizerResult(MBKuwaitIdFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate BirthDate => nativeResult.BirthDate != null ? new Date(nativeResult.BirthDate) : null;
        public string CivilIdNumber => nativeResult.CivilIdNumber;
        public IDate ExpiryDate => nativeResult.ExpiryDate != null ? new Date(nativeResult.ExpiryDate) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string Name => nativeResult.Name;
        public string Nationality => nativeResult.Nationality;
        public string Sex => nativeResult.Sex;
    }
}