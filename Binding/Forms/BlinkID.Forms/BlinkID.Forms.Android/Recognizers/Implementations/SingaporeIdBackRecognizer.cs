using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SingaporeIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SingaporeIdBackRecognizer : Recognizer, ISingaporeIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeIdBackRecognizer nativeRecognizer;

        SingaporeIdBackRecognizerResult result;

        public SingaporeIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeIdBackRecognizer;
            result = new SingaporeIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISingaporeIdBackRecognizerResult Result => result;

        
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
        
        public bool ExtractAddressChangeDate 
        { 
            get => nativeRecognizer.ShouldExtractAddressChangeDate(); 
            set => nativeRecognizer.SetExtractAddressChangeDate(value);
        }
        
        public bool ExtractBloodGroup 
        { 
            get => nativeRecognizer.ShouldExtractBloodGroup(); 
            set => nativeRecognizer.SetExtractBloodGroup(value);
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ShouldExtractDateOfIssue(); 
            set => nativeRecognizer.SetExtractDateOfIssue(value);
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
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
    }

    public sealed class SingaporeIdBackRecognizerResult : RecognizerResult, ISingaporeIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeIdBackRecognizer.Result nativeResult;

        internal SingaporeIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate AddressChangeDate => nativeResult.AddressChangeDate.Date != null ? new Date(nativeResult.AddressChangeDate.Date) : null;
        public string BloodGroup => nativeResult.BloodGroup;
        public string CardNumber => nativeResult.CardNumber;
        public IDate DateOfIssue => nativeResult.DateOfIssue.Date != null ? new Date(nativeResult.DateOfIssue.Date) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
    }
}