using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MrtdCombinedRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class MrtdCombinedRecognizer : Recognizer, IMrtdCombinedRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdCombinedRecognizer nativeRecognizer;

        MrtdCombinedRecognizerResult result;

        public MrtdCombinedRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdCombinedRecognizer;
            result = new MrtdCombinedRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdCombinedRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMrtdCombinedRecognizerResult Result => result;

        
        public bool ReturnFaceImage 
        { 
            get => nativeRecognizer.ShouldReturnFaceImage(); 
            set => nativeRecognizer.SetReturnFaceImage(value);
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
        public bool ReturnMrzImage 
        { 
            get => nativeRecognizer.ShouldReturnMrzImage(); 
            set => nativeRecognizer.SetReturnMrzImage(value);
        }
        
        public bool SignResult 
        { 
            get => nativeRecognizer.ShouldSignResult(); 
            set => nativeRecognizer.SetSignResult(value);
        }
        
    }

    public sealed class MrtdCombinedRecognizerResult : RecognizerResult, IMrtdCombinedRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdCombinedRecognizer.Result nativeResult;

        internal MrtdCombinedRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdCombinedRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string AlienNumber => nativeResult.AlienNumber;
        public string ApplicationReceiptNumber => nativeResult.ApplicationReceiptNumber;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public byte[] DigitalSignature => nativeResult.GetDigitalSignature();
        public uint DigitalSignatureVersion => (uint)nativeResult.DigitalSignatureVersion;
        public string DocumentCode => nativeResult.DocumentCode;
        public bool DocumentDataMatch => nativeResult.IsDocumentDataMatch;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public MrtdDocumentType DocumentType => (MrtdDocumentType)nativeResult.DocumentType.Ordinal();
        public Xamarin.Forms.ImageSource FaceImage => Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap());
        public Xamarin.Forms.ImageSource FullDocumentBackImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentBackImage.ConvertToBitmap());
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentFrontImage.ConvertToBitmap());
        public string ImmigrantCaseNumber => nativeResult.ImmigrantCaseNumber;
        public string Issuer => nativeResult.Issuer;
        public Xamarin.Forms.ImageSource MrzImage => Utils.ConvertAndroidBitmap(nativeResult.MrzImage.ConvertToBitmap());
        public bool MrzParsed => nativeResult.IsMrzParsed;
        public string MrzText => nativeResult.MrzText;
        public bool MrzVerified => nativeResult.IsMrzVerified;
        public string Nationality => nativeResult.Nationality;
        public string Opt1 => nativeResult.Opt1;
        public string Opt2 => nativeResult.Opt2;
        public string PrimaryId => nativeResult.PrimaryId;
        public bool ScanningFirstSideDone => nativeResult.IsScanningFirstSideDone;
        public string SecondaryId => nativeResult.SecondaryId;
        public string Sex => nativeResult.Sex;
    }
}