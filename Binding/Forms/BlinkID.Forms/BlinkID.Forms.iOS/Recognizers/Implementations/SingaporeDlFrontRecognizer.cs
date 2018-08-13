using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SingaporeDlFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class SingaporeDlFrontRecognizer : Recognizer, ISingaporeDlFrontRecognizer
    {
        MBSingaporeDlFrontRecognizer nativeRecognizer;

        SingaporeDlFrontRecognizerResult result;

        public SingaporeDlFrontRecognizer() : base(new MBSingaporeDlFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBSingaporeDlFrontRecognizer;
            result = new SingaporeDlFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISingaporeDlFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractBirthDate 
        { 
            get => nativeRecognizer.ExtractBirthDate; 
            set => nativeRecognizer.ExtractBirthDate = value;
        }
        
        public bool ExtractIssueDate 
        { 
            get => nativeRecognizer.ExtractIssueDate; 
            set => nativeRecognizer.ExtractIssueDate = value;
        }
        
        public bool ExtractName 
        { 
            get => nativeRecognizer.ExtractName; 
            set => nativeRecognizer.ExtractName = value;
        }
        
        public bool ExtractValidTill 
        { 
            get => nativeRecognizer.ExtractValidTill; 
            set => nativeRecognizer.ExtractValidTill = value;
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

    public sealed class SingaporeDlFrontRecognizerResult : RecognizerResult, ISingaporeDlFrontRecognizerResult
    {
        MBSingaporeDlFrontRecognizerResult nativeResult;

        internal SingaporeDlFrontRecognizerResult(MBSingaporeDlFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate BirthDate => nativeResult.BirthDate != null ? new Date(nativeResult.BirthDate) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public IDate IssueDate => nativeResult.IssueDate != null ? new Date(nativeResult.IssueDate) : null;
        public string LicenceNumber => nativeResult.LicenceNumber;
        public string Name => nativeResult.Name;
        public IDate ValidTill => nativeResult.ValidTill != null ? new Date(nativeResult.ValidTill) : null;
    }
}