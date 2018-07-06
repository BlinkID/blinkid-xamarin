using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(HongKongIdFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class HongKongIdFrontRecognizer : Recognizer, IHongKongIdFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Hongkong.HongKongIdFrontRecognizer nativeRecognizer;

        HongKongIdFrontRecognizerResult result;

        public HongKongIdFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Hongkong.HongKongIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Hongkong.HongKongIdFrontRecognizer;
            result = new HongKongIdFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Hongkong.HongKongIdFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IHongKongIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractCommercialCode 
        { 
            get => nativeRecognizer.ShouldExtractCommercialCode(); 
            set => nativeRecognizer.SetExtractCommercialCode(value);
        }
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractDateOfBirth(); 
            set => nativeRecognizer.SetExtractDateOfBirth(value);
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ShouldExtractDateOfIssue(); 
            set => nativeRecognizer.SetExtractDateOfIssue(value);
        }
        
        public bool ExtractFullName 
        { 
            get => nativeRecognizer.ShouldExtractFullName(); 
            set => nativeRecognizer.SetExtractFullName(value);
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

    public sealed class HongKongIdFrontRecognizerResult : RecognizerResult, IHongKongIdFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Hongkong.HongKongIdFrontRecognizer.Result nativeResult;

        internal HongKongIdFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Hongkong.HongKongIdFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string CommercialCode => nativeResult.CommercialCode;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FaceImage => Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap());
        public Xamarin.Forms.ImageSource FullDocumentImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap());
        public string FullName => nativeResult.FullName;
        public string Sex => nativeResult.Sex;
    }
}