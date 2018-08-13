using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MoroccoIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class MoroccoIdBackRecognizer : Recognizer, IMoroccoIdBackRecognizer
    {
        MBMoroccoIdBackRecognizer nativeRecognizer;

        MoroccoIdBackRecognizerResult result;

        public MoroccoIdBackRecognizer() : base(new MBMoroccoIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBMoroccoIdBackRecognizer;
            result = new MoroccoIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMoroccoIdBackRecognizerResult Result => result;

        
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
        
        public bool ExtractCivilStatusNumber 
        { 
            get => nativeRecognizer.ExtractCivilStatusNumber; 
            set => nativeRecognizer.ExtractCivilStatusNumber = value;
        }
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ExtractDateOfExpiry; 
            set => nativeRecognizer.ExtractDateOfExpiry = value;
        }
        
        public bool ExtractFathersName 
        { 
            get => nativeRecognizer.ExtractFathersName; 
            set => nativeRecognizer.ExtractFathersName = value;
        }
        
        public bool ExtractMothersName 
        { 
            get => nativeRecognizer.ExtractMothersName; 
            set => nativeRecognizer.ExtractMothersName = value;
        }
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ExtractSex; 
            set => nativeRecognizer.ExtractSex = value;
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
    }

    public sealed class MoroccoIdBackRecognizerResult : RecognizerResult, IMoroccoIdBackRecognizerResult
    {
        MBMoroccoIdBackRecognizerResult nativeResult;

        internal MoroccoIdBackRecognizerResult(MBMoroccoIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public string CivilStatusNumber => nativeResult.CivilStatusNumber;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public string FathersName => nativeResult.FathersName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string MothersName => nativeResult.MothersName;
        public string Sex => nativeResult.Sex;
    }
}