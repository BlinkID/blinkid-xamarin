using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MalaysiaMyKadBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class MalaysiaMyKadBackRecognizer : Recognizer, IMalaysiaMyKadBackRecognizer
    {
        MBMalaysiaMyKadBackRecognizer nativeRecognizer;

        MalaysiaMyKadBackRecognizerResult result;

        public MalaysiaMyKadBackRecognizer() : base(new MBMalaysiaMyKadBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBMalaysiaMyKadBackRecognizer;
            result = new MalaysiaMyKadBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMalaysiaMyKadBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractOldNric 
        { 
            get => nativeRecognizer.ExtractOldNric; 
            set => nativeRecognizer.ExtractOldNric = value;
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
        
        public bool ReturnSignatureImage 
        { 
            get => nativeRecognizer.ReturnSignatureImage; 
            set => nativeRecognizer.ReturnSignatureImage = value;
        }
        
        public uint SignatureImageDpi 
        { 
            get => (uint)nativeRecognizer.SignatureImageDpi; 
            set => nativeRecognizer.SignatureImageDpi = value;
        }
        
    }

    public sealed class MalaysiaMyKadBackRecognizerResult : RecognizerResult, IMalaysiaMyKadBackRecognizerResult
    {
        MBMalaysiaMyKadBackRecognizerResult nativeResult;

        internal MalaysiaMyKadBackRecognizerResult(MBMalaysiaMyKadBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public string ExtendedNric => nativeResult.ExtendedNric;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string Nric => nativeResult.Nric;
        public string OldNric => nativeResult.OldNric;
        public string Sex => nativeResult.Sex;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertUIImage(nativeResult.SignatureImage.Image) : null;
    }
}