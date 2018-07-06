using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SingaporeIdFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SingaporeIdFrontRecognizer : Recognizer, ISingaporeIdFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeIdFrontRecognizer nativeRecognizer;

        SingaporeIdFrontRecognizerResult result;

        public SingaporeIdFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeIdFrontRecognizer;
            result = new SingaporeIdFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeIdFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISingaporeIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractCountryOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractCountryOfBirth(); 
            set => nativeRecognizer.SetExtractCountryOfBirth(value);
        }
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractDateOfBirth(); 
            set => nativeRecognizer.SetExtractDateOfBirth(value);
        }
        
        public bool ExtractRace 
        { 
            get => nativeRecognizer.ShouldExtractRace(); 
            set => nativeRecognizer.SetExtractRace(value);
        }
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ShouldExtractSex(); 
            set => nativeRecognizer.SetExtractSex(value);
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

    public sealed class SingaporeIdFrontRecognizerResult : RecognizerResult, ISingaporeIdFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeIdFrontRecognizer.Result nativeResult;

        internal SingaporeIdFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeIdFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string CardNumber => nativeResult.CardNumber;
        public string CountryOfBirth => nativeResult.CountryOfBirth;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public Xamarin.Forms.ImageSource FaceImage => Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap());
        public Xamarin.Forms.ImageSource FullDocumentImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap());
        public string Name => nativeResult.Name;
        public string Race => nativeResult.Race;
        public string Sex => nativeResult.Sex;
    }
}