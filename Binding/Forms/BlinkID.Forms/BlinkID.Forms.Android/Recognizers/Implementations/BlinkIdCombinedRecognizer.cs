﻿using BlinkID.Forms.Droid.Recognizers;
using BlinkID.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BlinkIdCombinedRecognizer))]
namespace BlinkID.Forms.Droid.Recognizers
{
    public sealed class BlinkIdCombinedRecognizer : Recognizer, IBlinkIdCombinedRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Generic.BlinkIdCombinedRecognizer nativeRecognizer;

        BlinkIdCombinedRecognizerResult result;

        public BlinkIdCombinedRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Generic.BlinkIdCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Generic.BlinkIdCombinedRecognizer;
            result = new BlinkIdCombinedRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Generic.BlinkIdCombinedRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBlinkIdCombinedRecognizerResult Result => result;

        
        public bool AllowBlurFilter 
        { 
            get => nativeRecognizer.ShouldAllowBlurFilter(); 
            set => nativeRecognizer.SetAllowBlurFilter(value);
        }
        
        public bool AllowUncertainFrontSideScan 
        { 
            get => nativeRecognizer.ShouldAllowUncertainFrontSideScan(); 
            set => nativeRecognizer.SetAllowUncertainFrontSideScan(value);
        }
        
        public bool AllowUnparsedMrzResults 
        { 
            get => nativeRecognizer.ShouldAllowUnparsedMrzResults(); 
            set => nativeRecognizer.SetAllowUnparsedMrzResults(value);
        }
        
        public bool AllowUnverifiedMrzResults 
        { 
            get => nativeRecognizer.ShouldAllowUnverifiedMrzResults(); 
            set => nativeRecognizer.SetAllowUnverifiedMrzResults(value);
        }
        
        public AnonymizationMode AnonymizationMode 
        { 
            get => (AnonymizationMode)nativeRecognizer.AnonymizationMode.Ordinal(); 
            set => nativeRecognizer.AnonymizationMode = Com.Microblink.Entities.Recognizers.Blinkid.Generic.AnonymizationMode.Values()[(int)value];
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
        
        public int MaxAllowedMismatchesPerField 
        { 
            get => nativeRecognizer.MaxAllowedMismatchesPerField; 
            set => nativeRecognizer.MaxAllowedMismatchesPerField = (int)value;
        }
        
        public float PaddingEdge 
        { 
            get => nativeRecognizer.PaddingEdge; 
            set => nativeRecognizer.PaddingEdge = value;
        }
        
        public IRecognitionModeFilter RecognitionModeFilter 
        { 
            get => new RecognitionModeFilter(nativeRecognizer.RecognitionModeFilter); 
            set => nativeRecognizer.RecognitionModeFilter = (value as RecognitionModeFilter).NativeFilter;
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
        
        public bool SaveCameraFrames 
        { 
            get => nativeRecognizer.ShouldSaveCameraFrames(); 
            set => nativeRecognizer.SetSaveCameraFrames(value);
        }
        
        public bool ScanCroppedDocumentImage 
        { 
            get => nativeRecognizer.ShouldScanCroppedDocumentImage(); 
            set => nativeRecognizer.SetScanCroppedDocumentImage(value);
        }
        
        public int SignatureImageDpi 
        { 
            get => nativeRecognizer.SignatureImageDpi; 
            set => nativeRecognizer.SignatureImageDpi = (int)value;
        }
        
        public bool SkipUnsupportedBack 
        { 
            get => nativeRecognizer.ShouldSkipUnsupportedBack(); 
            set => nativeRecognizer.SetSkipUnsupportedBack(value);
        }
        
        public bool ValidateResultCharacters 
        { 
            get => nativeRecognizer.ShouldValidateResultCharacters(); 
            set => nativeRecognizer.SetValidateResultCharacters(value);
        }
        
    }

    public sealed class BlinkIdCombinedRecognizerResult : RecognizerResult, IBlinkIdCombinedRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Generic.BlinkIdCombinedRecognizer.Result nativeResult;

        internal BlinkIdCombinedRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Generic.BlinkIdCombinedRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string AdditionalAddressInformation => nativeResult.AdditionalAddressInformation;
        public string AdditionalNameInformation => nativeResult.AdditionalNameInformation;
        public string AdditionalOptionalAddressInformation => nativeResult.AdditionalOptionalAddressInformation;
        public string Address => nativeResult.Address;
        public int Age => (int)nativeResult.Age;
        public Xamarin.Forms.ImageSource BackCameraFrame => nativeResult.BackCameraFrame != null ? Utils.ConvertAndroidBitmap(nativeResult.BackCameraFrame.ConvertToBitmap()) : null;
        public IImageAnalysisResult BackImageAnalysisResult => new ImageAnalysisResult(nativeResult.BackImageAnalysisResult);
        public ProcessingStatus BackProcessingStatus => (ProcessingStatus)nativeResult.BackProcessingStatus.Ordinal();
        public IVizResult BackVizResult => new VizResult(nativeResult.BackVizResult);
        public Xamarin.Forms.ImageSource BarcodeCameraFrame => nativeResult.BarcodeCameraFrame != null ? Utils.ConvertAndroidBitmap(nativeResult.BarcodeCameraFrame.ConvertToBitmap()) : null;
        public IBarcodeResult BarcodeResult => new BarcodeResult(nativeResult.BarcodeResult);
        public IClassInfo ClassInfo => nativeResult.ClassInfo != null ? new ClassInfo(nativeResult.ClassInfo) : null;
        public IDataMatchDetailedInfo DataMatchDetailedInfo => new DataMatchDetailedInfo(nativeResult.DataMatchDetailedInfo);
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry.Date != null ? new Date(nativeResult.DateOfExpiry.Date) : null;
        public bool DateOfExpiryPermanent => nativeResult.IsDateOfExpiryPermanent;
        public IDate DateOfIssue => nativeResult.DateOfIssue.Date != null ? new Date(nativeResult.DateOfIssue.Date) : null;
        public string DocumentAdditionalNumber => nativeResult.DocumentAdditionalNumber;
        public DataMatchResult DocumentDataMatch => (DataMatchResult)nativeResult.DocumentDataMatch.Ordinal();
        public string DocumentNumber => nativeResult.DocumentNumber;
        public string DocumentOptionalAdditionalNumber => nativeResult.DocumentOptionalAdditionalNumber;
        public IDriverLicenseDetailedInfo DriverLicenseDetailedInfo => new DriverLicenseDetailedInfo(nativeResult.DriverLicenseDetailedInfo);
        public string Employer => nativeResult.Employer;
        public bool Expired => nativeResult.IsExpired;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public string FathersName => nativeResult.FathersName;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FrontCameraFrame => nativeResult.FrontCameraFrame != null ? Utils.ConvertAndroidBitmap(nativeResult.FrontCameraFrame.ConvertToBitmap()) : null;
        public IImageAnalysisResult FrontImageAnalysisResult => new ImageAnalysisResult(nativeResult.FrontImageAnalysisResult);
        public ProcessingStatus FrontProcessingStatus => (ProcessingStatus)nativeResult.FrontProcessingStatus.Ordinal();
        public IVizResult FrontVizResult => new VizResult(nativeResult.FrontVizResult);
        public Xamarin.Forms.ImageSource FullDocumentBackImage => nativeResult.FullDocumentBackImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentBackImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => nativeResult.FullDocumentFrontImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentFrontImage.ConvertToBitmap()) : null;
        public string FullName => nativeResult.FullName;
        public string IssuingAuthority => nativeResult.IssuingAuthority;
        public string LastName => nativeResult.LastName;
        public string LocalizedName => nativeResult.LocalizedName;
        public string MaritalStatus => nativeResult.MaritalStatus;
        public string MothersName => nativeResult.MothersName;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string Nationality => nativeResult.Nationality;
        public string PersonalIdNumber => nativeResult.PersonalIdNumber;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public ProcessingStatus ProcessingStatus => (ProcessingStatus)nativeResult.ProcessingStatus.Ordinal();
        public string Profession => nativeResult.Profession;
        public string Race => nativeResult.Race;
        public RecognitionMode RecognitionMode => (RecognitionMode)nativeResult.RecognitionMode.Ordinal();
        public string Religion => nativeResult.Religion;
        public string ResidentialStatus => nativeResult.ResidentialStatus;
        public bool ScanningFirstSideDone => nativeResult.IsScanningFirstSideDone;
        public string Sex => nativeResult.Sex;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap()) : null;
    }
}