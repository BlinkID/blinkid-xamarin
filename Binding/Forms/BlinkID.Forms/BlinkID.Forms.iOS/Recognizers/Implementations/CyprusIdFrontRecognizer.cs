using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(CyprusIdFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class CyprusIdFrontRecognizer : Recognizer, ICyprusIdFrontRecognizer
    {
        MBCyprusIdFrontRecognizer nativeRecognizer;

        CyprusIdFrontRecognizerResult result;

        public CyprusIdFrontRecognizer() : base(new MBCyprusIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBCyprusIdFrontRecognizer;
            result = new CyprusIdFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ICyprusIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractDocumentNumber 
        { 
            get => nativeRecognizer.ExtractDocumentNumber; 
            set => nativeRecognizer.ExtractDocumentNumber = value;
        }
        
        public bool ExtractName 
        { 
            get => nativeRecognizer.ExtractName; 
            set => nativeRecognizer.ExtractName = value;
        }
        
        public bool ExtractSurname 
        { 
            get => nativeRecognizer.ExtractSurname; 
            set => nativeRecognizer.ExtractSurname = value;
        }
        
        public uint FaceImageDpi 
        { 
            get => (uint)nativeRecognizer.FaceImageDpi; 
            set => nativeRecognizer.FaceImageDpi = value;
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = value;
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

    public sealed class CyprusIdFrontRecognizerResult : RecognizerResult, ICyprusIdFrontRecognizerResult
    {
        MBCyprusIdFrontRecognizerResult nativeResult;

        internal CyprusIdFrontRecognizerResult(MBCyprusIdFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string IdNumber => nativeResult.IdNumber;
        public string Name => nativeResult.Name;
        public string Surname => nativeResult.Surname;
    }
}