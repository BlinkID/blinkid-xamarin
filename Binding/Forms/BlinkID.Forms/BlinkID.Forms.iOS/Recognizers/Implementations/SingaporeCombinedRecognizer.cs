using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SingaporeCombinedRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class SingaporeCombinedRecognizer : Recognizer, ISingaporeCombinedRecognizer
    {
        MBSingaporeCombinedRecognizer nativeRecognizer;

        SingaporeCombinedRecognizerResult result;

        public SingaporeCombinedRecognizer() : base(new MBSingaporeCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBSingaporeCombinedRecognizer;
            result = new SingaporeCombinedRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISingaporeCombinedRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractAddress 
        { 
            get => nativeRecognizer.ExtractAddress; 
            set => nativeRecognizer.ExtractAddress = value;
        }
        
        public bool ExtractAddressChangeDate 
        { 
            get => nativeRecognizer.ExtractAddressChangeDate; 
            set => nativeRecognizer.ExtractAddressChangeDate = value;
        }
        
        public bool ExtractBloodGroup 
        { 
            get => nativeRecognizer.ExtractBloodGroup; 
            set => nativeRecognizer.ExtractBloodGroup = value;
        }
        
        public bool ExtractCountryOfBirth 
        { 
            get => nativeRecognizer.ExtractCountryOfBirth; 
            set => nativeRecognizer.ExtractCountryOfBirth = value;
        }
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ExtractDateOfBirth; 
            set => nativeRecognizer.ExtractDateOfBirth = value;
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ExtractDateOfIssue; 
            set => nativeRecognizer.ExtractDateOfIssue = value;
        }
        
        public bool ExtractName 
        { 
            get => nativeRecognizer.ExtractName; 
            set => nativeRecognizer.ExtractName = value;
        }
        
        public bool ExtractRace 
        { 
            get => nativeRecognizer.ExtractRace; 
            set => nativeRecognizer.ExtractRace = value;
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
        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeFactors;
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
        
        public bool SignResult 
        { 
            get => nativeRecognizer.SignResult; 
            set => nativeRecognizer.SignResult = value;
        }
        
    }

    public sealed class SingaporeCombinedRecognizerResult : RecognizerResult, ISingaporeCombinedRecognizerResult
    {
        MBSingaporeCombinedRecognizerResult nativeResult;

        internal SingaporeCombinedRecognizerResult(MBSingaporeCombinedRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate AddressChangeDate => nativeResult.AddressChangeDate != null ? new Date(nativeResult.AddressChangeDate) : null;
        public string BloodGroup => nativeResult.BloodGroup;
        public string CountryOfBirth => nativeResult.CountryOfBirth;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public byte[] DigitalSignature => nativeResult.DigitalSignature != null ? nativeResult.DigitalSignature.ToArray() : null;
        public uint DigitalSignatureVersion => (uint)nativeResult.DigitalSignatureVersion;
        public bool DocumentDataMatch => nativeResult.DocumentDataMatch;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentBackImage => nativeResult.FullDocumentBackImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentBackImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => nativeResult.FullDocumentFrontImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentFrontImage.Image) : null;
        public string IdentityCardNumber => nativeResult.IdentityCardNumber;
        public string Name => nativeResult.Name;
        public string Race => nativeResult.Race;
        public bool ScanningFirstSideDone => nativeResult.ScanningFirstSideDone;
        public string Sex => nativeResult.Sex;
    }
}