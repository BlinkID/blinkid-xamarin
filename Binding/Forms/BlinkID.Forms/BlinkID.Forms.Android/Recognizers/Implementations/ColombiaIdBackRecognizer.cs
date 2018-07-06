using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(ColombiaIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class ColombiaIdBackRecognizer : Recognizer, IColombiaIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Colombia.ColombiaIdBackRecognizer nativeRecognizer;

        ColombiaIdBackRecognizerResult result;

        public ColombiaIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Colombia.ColombiaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Colombia.ColombiaIdBackRecognizer;
            result = new ColombiaIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Colombia.ColombiaIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IColombiaIdBackRecognizerResult Result => result;

        
        public bool NullQuietZoneAllowed 
        { 
            get => nativeRecognizer.NullQuietZoneAllowed; 
            set => nativeRecognizer.NullQuietZoneAllowed = value;
        }
        
        public bool ScanUncertain 
        { 
            get => nativeRecognizer.ShouldScanUncertain(); 
            set => nativeRecognizer.SetScanUncertain(value);
        }
        
    }

    public sealed class ColombiaIdBackRecognizerResult : RecognizerResult, IColombiaIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Colombia.ColombiaIdBackRecognizer.Result nativeResult;

        internal ColombiaIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Colombia.ColombiaIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string BloodGroup => nativeResult.BloodGroup;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public byte[] Fingerprint => nativeResult.GetFingerprint();
        public string FirstName => nativeResult.FirstName;
        public string LastName => nativeResult.LastName;
        public string Sex => nativeResult.Sex;
    }
}