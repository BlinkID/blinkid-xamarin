using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(ColombiaIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class ColombiaIdBackRecognizer : Recognizer, IColombiaIdBackRecognizer
    {
        MBColombiaIdBackRecognizer nativeRecognizer;

        ColombiaIdBackRecognizerResult result;

        public ColombiaIdBackRecognizer() : base(new MBColombiaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBColombiaIdBackRecognizer;
            result = new ColombiaIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IColombiaIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
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
        
        public bool NullQuietZoneAllowed 
        { 
            get => nativeRecognizer.NullQuietZoneAllowed; 
            set => nativeRecognizer.NullQuietZoneAllowed = value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
        public bool ScanUncertain 
        { 
            get => nativeRecognizer.ScanUncertain; 
            set => nativeRecognizer.ScanUncertain = value;
        }
        
    }

    public sealed class ColombiaIdBackRecognizerResult : RecognizerResult, IColombiaIdBackRecognizerResult
    {
        MBColombiaIdBackRecognizerResult nativeResult;

        internal ColombiaIdBackRecognizerResult(MBColombiaIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate BirthDate => nativeResult.BirthDate != null ? new Date(nativeResult.BirthDate) : null;
        public string BloodGroup => nativeResult.BloodGroup;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public byte[] Fingerprint => nativeResult.Fingerprint != null ? nativeResult.Fingerprint.ToArray() : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string LastName => nativeResult.LastName;
        public string Sex => nativeResult.Sex;
    }
}