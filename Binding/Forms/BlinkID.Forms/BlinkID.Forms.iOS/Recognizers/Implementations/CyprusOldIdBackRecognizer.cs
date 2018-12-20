using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(CyprusOldIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class CyprusOldIdBackRecognizer : Recognizer, ICyprusOldIdBackRecognizer
    {
        MBCyprusOldIdBackRecognizer nativeRecognizer;

        CyprusOldIdBackRecognizerResult result;

        public CyprusOldIdBackRecognizer() : base(new MBCyprusOldIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBCyprusOldIdBackRecognizer;
            result = new CyprusOldIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ICyprusOldIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractExpiresOn 
        { 
            get => nativeRecognizer.ExtractExpiresOn; 
            set => nativeRecognizer.ExtractExpiresOn = value;
        }
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ExtractSex; 
            set => nativeRecognizer.ExtractSex = value;
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

    public sealed class CyprusOldIdBackRecognizerResult : RecognizerResult, ICyprusOldIdBackRecognizerResult
    {
        MBCyprusOldIdBackRecognizerResult nativeResult;

        internal CyprusOldIdBackRecognizerResult(MBCyprusOldIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate ExpiresOn => nativeResult.ExpiresOn != null ? new Date(nativeResult.ExpiresOn) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string Sex => nativeResult.Sex;
    }
}