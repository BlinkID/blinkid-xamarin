using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(PolandIdFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class PolandIdFrontRecognizer : Recognizer, IPolandIdFrontRecognizer
    {
        MBPolandIdFrontRecognizer nativeRecognizer;

        PolandIdFrontRecognizerResult result;

        public PolandIdFrontRecognizer() : base(new MBPolandIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBPolandIdFrontRecognizer;
            result = new PolandIdFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IPolandIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ExtractDateOfBirth; 
            set => nativeRecognizer.ExtractDateOfBirth = value;
        }
        
        public bool ExtractFamilyName 
        { 
            get => nativeRecognizer.ExtractFamilyName; 
            set => nativeRecognizer.ExtractFamilyName = value;
        }
        
        public bool ExtractGivenNames 
        { 
            get => nativeRecognizer.ExtractGivenNames; 
            set => nativeRecognizer.ExtractGivenNames = value;
        }
        
        public bool ExtractParentsGivenNames 
        { 
            get => nativeRecognizer.ExtractParentsGivenNames; 
            set => nativeRecognizer.ExtractParentsGivenNames = value;
        }
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ExtractSex; 
            set => nativeRecognizer.ExtractSex = value;
        }
        
        public bool ExtractSurname 
        { 
            get => nativeRecognizer.ExtractSurname; 
            set => nativeRecognizer.ExtractSurname = value;
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

    public sealed class PolandIdFrontRecognizerResult : RecognizerResult, IPolandIdFrontRecognizerResult
    {
        MBPolandIdFrontRecognizerResult nativeResult;

        internal PolandIdFrontRecognizerResult(MBPolandIdFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public string FamilyName => nativeResult.FamilyName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string GivenNames => nativeResult.GivenNames;
        public string ParentsGivenNames => nativeResult.ParentsGivenNames;
        public string Sex => nativeResult.Sex;
        public string Surname => nativeResult.Surname;
    }
}