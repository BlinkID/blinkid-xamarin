﻿using BlinkID.Forms.Droid.Recognizers;
using BlinkID.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MrtdCombinedRecognizer))]
namespace BlinkID.Forms.Droid.Recognizers
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

        
        public bool AllowSpecialCharacters 
        { 
            get => nativeRecognizer.AllowSpecialCharacters; 
            set => nativeRecognizer.AllowSpecialCharacters = value;
        }
        
        public bool AllowUnparsedResults 
        { 
            get => nativeRecognizer.AllowUnparsedResults; 
            set => nativeRecognizer.AllowUnparsedResults = value;
        }
        
        public bool AllowUnverifiedResults 
        { 
            get => nativeRecognizer.AllowUnverifiedResults; 
            set => nativeRecognizer.AllowUnverifiedResults = value;
        }
        
        public DocumentFaceDetectorType DetectorType 
        { 
            get => (DocumentFaceDetectorType)nativeRecognizer.DetectorType.Ordinal(); 
            set => nativeRecognizer.DetectorType = Com.Microblink.Entities.Recognizers.Blinkid.Documentface.DocumentFaceDetectorType.Values()[(int)value];
        }
        
        public int FaceImageDpi 
        { 
            get => nativeRecognizer.FaceImageDpi; 
            set => nativeRecognizer.FaceImageDpi = (int)value;
        }
        
        public int FullDocumentImageDpi 
        { 
            get => nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = (int)value;
        }
        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeImageExtensionFactors;
        }
        
        public int NumStableDetectionsThreshold 
        { 
            get => nativeRecognizer.NumStableDetectionsThreshold; 
            set => nativeRecognizer.NumStableDetectionsThreshold = (int)value;
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
        public byte[] DigitalSignature => nativeResult.GetDigitalSignature();
        public int DigitalSignatureVersion => (int)nativeResult.DigitalSignatureVersion;
        public DataMatchResult DocumentDataMatch => (DataMatchResult)nativeResult.DocumentDataMatch.Ordinal();
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentBackImage => nativeResult.FullDocumentBackImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentBackImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => nativeResult.FullDocumentFrontImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentFrontImage.ConvertToBitmap()) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public bool ScanningFirstSideDone => nativeResult.IsScanningFirstSideDone;
    }
}