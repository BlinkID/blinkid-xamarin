using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MexicoVoterIdFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class MexicoVoterIdFrontRecognizer : Recognizer, IMexicoVoterIdFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Mexico.MexicoVoterIdFrontRecognizer nativeRecognizer;

        MexicoVoterIdFrontRecognizerResult result;

        public MexicoVoterIdFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Mexico.MexicoVoterIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Mexico.MexicoVoterIdFrontRecognizer;
            result = new MexicoVoterIdFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Mexico.MexicoVoterIdFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMexicoVoterIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractAddress 
        { 
            get => nativeRecognizer.ShouldExtractAddress(); 
            set => nativeRecognizer.SetExtractAddress(value);
        }
        
        public bool ExtractCurp 
        { 
            get => nativeRecognizer.ShouldExtractCurp(); 
            set => nativeRecognizer.SetExtractCurp(value);
        }
        
        public bool ExtractFullName 
        { 
            get => nativeRecognizer.ShouldExtractFullName(); 
            set => nativeRecognizer.SetExtractFullName(value);
        }
        
        public uint FaceImageDpi 
        { 
            get => (uint)nativeRecognizer.FaceImageDpi; 
            set => nativeRecognizer.FaceImageDpi = (int)value;
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
        
        public bool ReturnSignatureImage 
        { 
            get => nativeRecognizer.ShouldReturnSignatureImage(); 
            set => nativeRecognizer.SetReturnSignatureImage(value);
        }
        
        public uint SignatureImageDpi 
        { 
            get => (uint)nativeRecognizer.SignatureImageDpi; 
            set => nativeRecognizer.SignatureImageDpi = (int)value;
        }
        
    }

    public sealed class MexicoVoterIdFrontRecognizerResult : RecognizerResult, IMexicoVoterIdFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Mexico.MexicoVoterIdFrontRecognizer.Result nativeResult;

        internal MexicoVoterIdFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Mexico.MexicoVoterIdFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public string Curp => nativeResult.Curp;
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public string ElectorKey => nativeResult.ElectorKey;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string FullName => nativeResult.FullName;
        public string Sex => nativeResult.Sex;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap()) : null;
    }
}