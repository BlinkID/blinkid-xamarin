using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(NigeriaVoterIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class NigeriaVoterIdBackRecognizer : Recognizer, INigeriaVoterIdBackRecognizer
    {
        MBNigeriaVoterIdBackRecognizer nativeRecognizer;

        NigeriaVoterIdBackRecognizerResult result;

        public NigeriaVoterIdBackRecognizer() : base(new MBNigeriaVoterIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBNigeriaVoterIdBackRecognizer;
            result = new NigeriaVoterIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public INigeriaVoterIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
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
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
    }

    public sealed class NigeriaVoterIdBackRecognizerResult : RecognizerResult, INigeriaVoterIdBackRecognizerResult
    {
        MBNigeriaVoterIdBackRecognizerResult nativeResult;

        internal NigeriaVoterIdBackRecognizerResult(MBNigeriaVoterIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string RawBarcodeData => nativeResult.RawBarcodeData;
        public string Sex => nativeResult.Sex;
        public string Surname => nativeResult.Surname;
    }
}