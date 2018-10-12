using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MoroccoIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class MoroccoIdBackRecognizer : Recognizer, IMoroccoIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Morocco.MoroccoIdBackRecognizer nativeRecognizer;

        MoroccoIdBackRecognizerResult result;

        public MoroccoIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Morocco.MoroccoIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Morocco.MoroccoIdBackRecognizer;
            result = new MoroccoIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Morocco.MoroccoIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMoroccoIdBackRecognizerResult Result => result;

        
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
        
        public bool ExtractCivilStatusNumber 
        { 
            get => nativeRecognizer.ShouldExtractCivilStatusNumber(); 
            set => nativeRecognizer.SetExtractCivilStatusNumber(value);
        }
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ShouldExtractDateOfExpiry(); 
            set => nativeRecognizer.SetExtractDateOfExpiry(value);
        }
        
        public bool ExtractFathersName 
        { 
            get => nativeRecognizer.ShouldExtractFathersName(); 
            set => nativeRecognizer.SetExtractFathersName(value);
        }
        
        public bool ExtractMothersName 
        { 
            get => nativeRecognizer.ShouldExtractMothersName(); 
            set => nativeRecognizer.SetExtractMothersName(value);
        }
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ShouldExtractSex(); 
            set => nativeRecognizer.SetExtractSex(value);
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
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
    }

    public sealed class MoroccoIdBackRecognizerResult : RecognizerResult, IMoroccoIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Morocco.MoroccoIdBackRecognizer.Result nativeResult;

        internal MoroccoIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Morocco.MoroccoIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public string CivilStatusNumber => nativeResult.CivilStatusNumber;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry.Date != null ? new Date(nativeResult.DateOfExpiry.Date) : null;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public string FathersName => nativeResult.FathersName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string MothersName => nativeResult.MothersName;
        public string Sex => nativeResult.Sex;
    }
}