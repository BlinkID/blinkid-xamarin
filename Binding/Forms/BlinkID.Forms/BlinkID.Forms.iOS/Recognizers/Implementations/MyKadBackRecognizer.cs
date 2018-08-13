using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MyKadBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class MyKadBackRecognizer : Recognizer, IMyKadBackRecognizer
    {
        MBMyKadBackRecognizer nativeRecognizer;

        MyKadBackRecognizerResult result;

        public MyKadBackRecognizer() : base(new MBMyKadBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBMyKadBackRecognizer;
            result = new MyKadBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMyKadBackRecognizerResult Result => result;

        
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

    public sealed class MyKadBackRecognizerResult : RecognizerResult, IMyKadBackRecognizerResult
    {
        MBMyKadBackRecognizerResult nativeResult;

        internal MyKadBackRecognizerResult(MBMyKadBackRecognizerResult nativeResult) : base(nativeResult)
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