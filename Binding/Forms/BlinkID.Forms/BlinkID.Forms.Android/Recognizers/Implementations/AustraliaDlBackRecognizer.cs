using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(AustraliaDlBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class AustraliaDlBackRecognizer : Recognizer, IAustraliaDlBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Australia.AustraliaDlBackRecognizer nativeRecognizer;

        AustraliaDlBackRecognizerResult result;

        public AustraliaDlBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Australia.AustraliaDlBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Australia.AustraliaDlBackRecognizer;
            result = new AustraliaDlBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Australia.AustraliaDlBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IAustraliaDlBackRecognizerResult Result => result;

        
        public bool ExtractAddress 
        { 
            get => nativeRecognizer.ShouldExtractAddress(); 
            set => nativeRecognizer.SetExtractAddress(value);
        }
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ShouldExtractDateOfExpiry(); 
            set => nativeRecognizer.SetExtractDateOfExpiry(value);
        }
        
        public bool ExtractLastName 
        { 
            get => nativeRecognizer.ShouldExtractLastName(); 
            set => nativeRecognizer.SetExtractLastName(value);
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = (int)value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
    }

    public sealed class AustraliaDlBackRecognizerResult : RecognizerResult, IAustraliaDlBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Australia.AustraliaDlBackRecognizer.Result nativeResult;

        internal AustraliaDlBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Australia.AustraliaDlBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string LastName => nativeResult.LastName;
        public string LicenceNumber => nativeResult.LicenceNumber;
    }
}