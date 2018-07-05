using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MrtdCombinedRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class MrtdCombinedRecognizer : Recognizer, IMrtdCombinedRecognizer
    {
        MBMrtdCombinedRecognizer nativeRecognizer;

        MrtdCombinedRecognizerResult result;

        public MrtdCombinedRecognizer() : base(new MBMrtdCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBMrtdCombinedRecognizer;
            result = new MrtdCombinedRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMrtdCombinedRecognizerResult Result => result;

        
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
        
        public bool ReturnMrzImage 
        { 
            get => nativeRecognizer.ReturnMrzImage; 
            set => nativeRecognizer.ReturnMrzImage = value;
        }
        
        public bool SignResult 
        { 
            get => nativeRecognizer.SignResult; 
            set => nativeRecognizer.SignResult = value;
        }
        
    }

    public sealed class MrtdCombinedRecognizerResult : RecognizerResult, IMrtdCombinedRecognizerResult
    {
        MBMrtdCombinedRecognizerResult nativeResult;

        internal MrtdCombinedRecognizerResult(MBMrtdCombinedRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string AlienNumber => nativeResult.AlienNumber;
        public string ApplicationReceiptNumber => nativeResult.ApplicationReceiptNumber;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public byte[] DigitalSignature => nativeResult.DigitalSignature != null ? nativeResult.DigitalSignature.ToArray() : null;
        public uint DigitalSignatureVersion => (uint)nativeResult.DigitalSignatureVersion;
        public string DocumentCode => nativeResult.DocumentCode;
        public bool DocumentDataMatch => nativeResult.DocumentDataMatch;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public MrtdDocumentType DocumentType => (MrtdDocumentType)nativeResult.DocumentType;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentBackImage => nativeResult.FullDocumentBackImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentBackImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => nativeResult.FullDocumentFrontImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentFrontImage.Image) : null;
        public string ImmigrantCaseNumber => nativeResult.ImmigrantCaseNumber;
        public string Issuer => nativeResult.Issuer;
        public Xamarin.Forms.ImageSource MrzImage => nativeResult.MrzImage != null ? Utils.ConvertUIImage(nativeResult.MrzImage.Image) : null;
        public bool MrzParsed => nativeResult.MrzParsed;
        public string MrzText => nativeResult.MrzText;
        public bool MrzVerified => nativeResult.MrzVerified;
        public string Nationality => nativeResult.Nationality;
        public string Opt1 => nativeResult.Opt1;
        public string Opt2 => nativeResult.Opt2;
        public string PrimaryId => nativeResult.PrimaryId;
        public bool ScanningFirstSideDone => nativeResult.ScanningFirstSideDone;
        public string SecondaryId => nativeResult.SecondaryId;
        public string Sex => nativeResult.Sex;
    }
}