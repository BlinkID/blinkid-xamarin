using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(NigeriaVoterIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class NigeriaVoterIdBackRecognizer : Recognizer, INigeriaVoterIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Nigeria.NigeriaVoterIdBackRecognizer nativeRecognizer;

        NigeriaVoterIdBackRecognizerResult result;

        public NigeriaVoterIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Nigeria.NigeriaVoterIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Nigeria.NigeriaVoterIdBackRecognizer;
            result = new NigeriaVoterIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Nigeria.NigeriaVoterIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public INigeriaVoterIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
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

    public sealed class NigeriaVoterIdBackRecognizerResult : RecognizerResult, INigeriaVoterIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Nigeria.NigeriaVoterIdBackRecognizer.Result nativeResult;

        internal NigeriaVoterIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Nigeria.NigeriaVoterIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string RawBarcodeData => nativeResult.RawBarcodeData;
        public string Sex => nativeResult.Sex;
        public string Surname => nativeResult.Surname;
    }
}