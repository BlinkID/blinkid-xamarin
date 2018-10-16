using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(IndonesiaIdFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class IndonesiaIdFrontRecognizer : Recognizer, IIndonesiaIdFrontRecognizer
    {
        MBIndonesiaIdFrontRecognizer nativeRecognizer;

        IndonesiaIdFrontRecognizerResult result;

        public IndonesiaIdFrontRecognizer() : base(new MBIndonesiaIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBIndonesiaIdFrontRecognizer;
            result = new IndonesiaIdFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IIndonesiaIdFrontRecognizerResult Result => result;

        
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
        
        public bool ExtractBloodType 
        { 
            get => nativeRecognizer.ExtractBloodType; 
            set => nativeRecognizer.ExtractBloodType = value;
        }
        
        public bool ExtractCitizenship 
        { 
            get => nativeRecognizer.ExtractCitizenship; 
            set => nativeRecognizer.ExtractCitizenship = value;
        }
        
        public bool ExtractCity 
        { 
            get => nativeRecognizer.ExtractCity; 
            set => nativeRecognizer.ExtractCity = value;
        }
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ExtractDateOfExpiry; 
            set => nativeRecognizer.ExtractDateOfExpiry = value;
        }
        
        public bool ExtractDistrict 
        { 
            get => nativeRecognizer.ExtractDistrict; 
            set => nativeRecognizer.ExtractDistrict = value;
        }
        
        public bool ExtractKelDesa 
        { 
            get => nativeRecognizer.ExtractKelDesa; 
            set => nativeRecognizer.ExtractKelDesa = value;
        }
        
        public bool ExtractMaritalStatus 
        { 
            get => nativeRecognizer.ExtractMaritalStatus; 
            set => nativeRecognizer.ExtractMaritalStatus = value;
        }
        
        public bool ExtractName 
        { 
            get => nativeRecognizer.ExtractName; 
            set => nativeRecognizer.ExtractName = value;
        }
        
        public bool ExtractOccupation 
        { 
            get => nativeRecognizer.ExtractOccupation; 
            set => nativeRecognizer.ExtractOccupation = value;
        }
        
        public bool ExtractPlaceOfBirth 
        { 
            get => nativeRecognizer.ExtractPlaceOfBirth; 
            set => nativeRecognizer.ExtractPlaceOfBirth = value;
        }
        
        public bool ExtractReligion 
        { 
            get => nativeRecognizer.ExtractReligion; 
            set => nativeRecognizer.ExtractReligion = value;
        }
        
        public bool ExtractRt 
        { 
            get => nativeRecognizer.ExtractRt; 
            set => nativeRecognizer.ExtractRt = value;
        }
        
        public bool ExtractRw 
        { 
            get => nativeRecognizer.ExtractRw; 
            set => nativeRecognizer.ExtractRw = value;
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

    public sealed class IndonesiaIdFrontRecognizerResult : RecognizerResult, IIndonesiaIdFrontRecognizerResult
    {
        MBIndonesiaIdFrontRecognizerResult nativeResult;

        internal IndonesiaIdFrontRecognizerResult(MBIndonesiaIdFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public string BloodType => nativeResult.BloodType;
        public string Citizenship => nativeResult.Citizenship;
        public string City => nativeResult.City;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public bool DateOfExpiryPermanent => nativeResult.DateOfExpiryPermanent;
        public string District => nativeResult.District;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string KelDesa => nativeResult.KelDesa;
        public string MaritalStatus => nativeResult.MaritalStatus;
        public string Name => nativeResult.Name;
        public string Occupation => nativeResult.Occupation;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public string Province => nativeResult.Province;
        public string Religion => nativeResult.Religion;
        public string Rt => nativeResult.Rt;
        public string Rw => nativeResult.Rw;
        public string Sex => nativeResult.Sex;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertUIImage(nativeResult.SignatureImage.Image) : null;
    }
}