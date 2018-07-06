using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SingaporeIdFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class SingaporeIdFrontRecognizer : Recognizer, ISingaporeIdFrontRecognizer
    {
        MBSingaporeIdFrontRecognizer nativeRecognizer;

        SingaporeIdFrontRecognizerResult result;

        public SingaporeIdFrontRecognizer() : base(new MBSingaporeIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBSingaporeIdFrontRecognizer;
            result = new SingaporeIdFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISingaporeIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractCountryOfBirth 
        { 
            get => nativeRecognizer.ExtractCountryOfBirth; 
            set => nativeRecognizer.ExtractCountryOfBirth = value;
        }
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ExtractDateOfBirth; 
            set => nativeRecognizer.ExtractDateOfBirth = value;
        }
        
        public bool ExtractRace 
        { 
            get => nativeRecognizer.ExtractRace; 
            set => nativeRecognizer.ExtractRace = value;
        }
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ExtractSex; 
            set => nativeRecognizer.ExtractSex = value;
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

    public sealed class SingaporeIdFrontRecognizerResult : RecognizerResult, ISingaporeIdFrontRecognizerResult
    {
        MBSingaporeIdFrontRecognizerResult nativeResult;

        internal SingaporeIdFrontRecognizerResult(MBSingaporeIdFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string CardNumber => nativeResult.CardNumber;
        public string CountryOfBirth => nativeResult.CountryOfBirth;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string Name => nativeResult.Name;
        public string Race => nativeResult.Race;
        public string Sex => nativeResult.Sex;
    }
}