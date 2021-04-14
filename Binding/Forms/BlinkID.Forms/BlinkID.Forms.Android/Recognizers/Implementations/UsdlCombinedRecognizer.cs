﻿using BlinkID.Forms.Core.Recognizers;
using BlinkID.Forms.Droid.Recognizers;
using Xamarin.Forms;

[assembly: Dependency(typeof(UsdlCombinedRecognizer))]
namespace BlinkID.Forms.Droid.Recognizers
{
    public sealed class UsdlCombinedRecognizer : Recognizer, IUsdlCombinedRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Usdl.UsdlCombinedRecognizer nativeRecognizer;
        UsdlCombinedRecognizerResult result;

        public UsdlCombinedRecognizer()
            : base(new Com.Microblink.Entities.Recognizers.Blinkid.Usdl.UsdlCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Usdl.UsdlCombinedRecognizer;
            result = new UsdlCombinedRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Usdl.UsdlCombinedRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IUsdlCombinedRecognizerResult Result => result;

        public int FaceImageDpi { get => (int)nativeRecognizer.FaceImageDpi; set => nativeRecognizer.FaceImageDpi = (int)value; }
        public bool ReturnFaceImage { get => nativeRecognizer.ShouldReturnFaceImage(); set => nativeRecognizer.SetReturnFaceImage(value); }
        public int FullDocumentImageDpi { get => (int)nativeRecognizer.FullDocumentImageDpi; set => nativeRecognizer.FullDocumentImageDpi = (int)value; }
        public bool ReturnFullDocumentImage { get => nativeRecognizer.ShouldReturnFullDocumentImage(); set => nativeRecognizer.SetReturnFullDocumentImage(value); }
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeImageExtensionFactors;
        }
        public int NumStableDetectionsThreshold
        { 
            get => (int)nativeRecognizer.NumStableDetectionsThreshold;
            set => nativeRecognizer.NumStableDetectionsThreshold = (int)value;
        }
        public bool SignResult { get => nativeRecognizer.ShouldSignResult(); set => nativeRecognizer.SetSignResult(value); }
    }

    public sealed class UsdlCombinedRecognizerResult : RecognizerResult, IUsdlCombinedRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Usdl.UsdlCombinedRecognizer.Result nativeResult;

        internal UsdlCombinedRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Usdl.UsdlCombinedRecognizer.Result nativeResult)
            : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }

        public bool Uncertain => nativeResult.IsUncertain;

        public string RawStringData => nativeResult.RawStringData;

        public byte[] RawData => nativeResult.GetRawData();

        public string[] OptionalElements => nativeResult.GetOptionalElements();

        public byte[] DigitalSignature => nativeResult.GetDigitalSignature();

        public int DigitalSignatureVersion => (int)nativeResult.DigitalSignatureVersion;

        public DataMatchResult DocumentDataMatch => (DataMatchResult)nativeResult.DocumentDataMatch.Ordinal();

        public ImageSource FaceImage => Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap());

        public ImageSource FullDocumentImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap());

        public bool ScanningFirstSideDone => nativeResult.IsScanningFirstSideDone;

        public string GetField(UsdlKeys key)
        {
            return nativeResult.GetField(Com.Microblink.Entities.Recognizers.Blinkbarcode.Usdl.UsdlKeys.Values()[(int)key]);
        }

        public string FirstName => nativeResult.FirstName;

        public string LastName => nativeResult.LastName;

        public string FullName => nativeResult.FullName;

        public string MiddleName => nativeResult.MiddleName;

        public string NameSuffix => nativeResult.NameSuffix;

        public string Address => nativeResult.Address;

        public string DocumentNumber => nativeResult.DocumentNumber;

        public string Sex => nativeResult.Sex;

        public int Age => nativeResult.Age;

        public string Restrictions => nativeResult.Restrictions;

        public string Endorsements => nativeResult.Endorsements;

        public string VehicleClass => nativeResult.VehicleClass;

        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;

        public IDate DateOfIssue => nativeResult.DateOfIssue.Date != null ? new Date(nativeResult.DateOfIssue.Date) : null;

        public IDate DateOfExpiry => nativeResult.DateOfExpiry.Date != null ? new Date(nativeResult.DateOfExpiry.Date) : null;
    }
}