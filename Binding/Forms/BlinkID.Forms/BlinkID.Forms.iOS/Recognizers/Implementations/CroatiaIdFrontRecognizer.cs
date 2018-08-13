using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(CroatiaIdFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class CroatiaIdFrontRecognizer : Recognizer, ICroatiaIdFrontRecognizer
    {
        MBCroatiaIdFrontRecognizer nativeRecognizer;

        CroatiaIdFrontRecognizerResult result;

        public CroatiaIdFrontRecognizer() : base(new MBCroatiaIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBCroatiaIdFrontRecognizer;
            result = new CroatiaIdFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ICroatiaIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractCitizenship 
        { 
            get => nativeRecognizer.ExtractCitizenship; 
            set => nativeRecognizer.ExtractCitizenship = value;
        }
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ExtractDateOfBirth; 
            set => nativeRecognizer.ExtractDateOfBirth = value;
        }
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ExtractDateOfExpiry; 
            set => nativeRecognizer.ExtractDateOfExpiry = value;
        }
        
        public bool ExtractFirstName 
        { 
            get => nativeRecognizer.ExtractFirstName; 
            set => nativeRecognizer.ExtractFirstName = value;
        }
        
        public bool ExtractLastName 
        { 
            get => nativeRecognizer.ExtractLastName; 
            set => nativeRecognizer.ExtractLastName = value;
        }
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ExtractSex; 
            set => nativeRecognizer.ExtractSex = value;
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

    public sealed class CroatiaIdFrontRecognizerResult : RecognizerResult, ICroatiaIdFrontRecognizerResult
    {
        MBCroatiaIdFrontRecognizerResult nativeResult;

        internal CroatiaIdFrontRecognizerResult(MBCroatiaIdFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Citizenship => nativeResult.Citizenship;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public bool DateOfExpiryPermanent => nativeResult.DateOfExpiryPermanent;
        public bool DocumentBilingual => nativeResult.DocumentBilingual;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string LastName => nativeResult.LastName;
        public string Sex => nativeResult.Sex;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertUIImage(nativeResult.SignatureImage.Image) : null;
    }
}