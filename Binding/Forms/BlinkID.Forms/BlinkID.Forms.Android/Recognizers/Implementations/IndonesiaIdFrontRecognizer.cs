using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(IndonesiaIdFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class IndonesiaIdFrontRecognizer : Recognizer, IIndonesiaIdFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Indonesia.IndonesiaIdFrontRecognizer nativeRecognizer;

        IndonesiaIdFrontRecognizerResult result;

        public IndonesiaIdFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Indonesia.IndonesiaIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Indonesia.IndonesiaIdFrontRecognizer;
            result = new IndonesiaIdFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Indonesia.IndonesiaIdFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IIndonesiaIdFrontRecognizerResult Result => result;

        
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
        
        public bool ExtractBloodType 
        { 
            get => nativeRecognizer.ShouldExtractBloodType(); 
            set => nativeRecognizer.SetExtractBloodType(value);
        }
        
        public bool ExtractCitizenship 
        { 
            get => nativeRecognizer.ShouldExtractCitizenship(); 
            set => nativeRecognizer.SetExtractCitizenship(value);
        }
        
        public bool ExtractCity 
        { 
            get => nativeRecognizer.ShouldExtractCity(); 
            set => nativeRecognizer.SetExtractCity(value);
        }
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ShouldExtractDateOfExpiry(); 
            set => nativeRecognizer.SetExtractDateOfExpiry(value);
        }
        
        public bool ExtractDistrict 
        { 
            get => nativeRecognizer.ShouldExtractDistrict(); 
            set => nativeRecognizer.SetExtractDistrict(value);
        }
        
        public bool ExtractKelDesa 
        { 
            get => nativeRecognizer.ShouldExtractKelDesa(); 
            set => nativeRecognizer.SetExtractKelDesa(value);
        }
        
        public bool ExtractMaritalStatus 
        { 
            get => nativeRecognizer.ShouldExtractMaritalStatus(); 
            set => nativeRecognizer.SetExtractMaritalStatus(value);
        }
        
        public bool ExtractName 
        { 
            get => nativeRecognizer.ShouldExtractName(); 
            set => nativeRecognizer.SetExtractName(value);
        }
        
        public bool ExtractOccupation 
        { 
            get => nativeRecognizer.ShouldExtractOccupation(); 
            set => nativeRecognizer.SetExtractOccupation(value);
        }
        
        public bool ExtractPlaceOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractPlaceOfBirth(); 
            set => nativeRecognizer.SetExtractPlaceOfBirth(value);
        }
        
        public bool ExtractReligion 
        { 
            get => nativeRecognizer.ShouldExtractReligion(); 
            set => nativeRecognizer.SetExtractReligion(value);
        }
        
        public bool ExtractRt 
        { 
            get => nativeRecognizer.ShouldExtractRt(); 
            set => nativeRecognizer.SetExtractRt(value);
        }
        
        public bool ExtractRw 
        { 
            get => nativeRecognizer.ShouldExtractRw(); 
            set => nativeRecognizer.SetExtractRw(value);
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

    public sealed class IndonesiaIdFrontRecognizerResult : RecognizerResult, IIndonesiaIdFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Indonesia.IndonesiaIdFrontRecognizer.Result nativeResult;

        internal IndonesiaIdFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Indonesia.IndonesiaIdFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public string BloodType => nativeResult.BloodType;
        public string Citizenship => nativeResult.Citizenship;
        public string City => nativeResult.City;
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry.Date != null ? new Date(nativeResult.DateOfExpiry.Date) : null;
        public bool DateOfExpiryPermanent => nativeResult.IsDateOfExpiryPermanent;
        public string District => nativeResult.District;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
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
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap()) : null;
    }
}