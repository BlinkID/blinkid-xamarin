﻿using BlinkID.Forms.Core.Recognizers;
using BlinkID.Forms.iOS.Recognizers;
using Xamarin.Forms;

[assembly: Dependency(typeof(UsdlCombinedRecognizer))]
namespace BlinkID.Forms.iOS.Recognizers
{
    public sealed class UsdlCombinedRecognizer : Recognizer, IUsdlCombinedRecognizer
    {
        MBUsdlCombinedRecognizer nativeRecognizer;
        UsdlCombinedRecognizerResult result;

        public UsdlCombinedRecognizer()
            : base(new MBUsdlCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBUsdlCombinedRecognizer;
            result = new UsdlCombinedRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IUsdlCombinedRecognizerResult Result => result;

        public int FaceImageDpi { get => (int)nativeRecognizer.FaceImageDpi; set => nativeRecognizer.FaceImageDpi = value; }
        public bool ReturnFaceImage { get => nativeRecognizer.ReturnFaceImage; set => nativeRecognizer.ReturnFaceImage = value; }
        public int FullDocumentImageDpi { get => (int)nativeRecognizer.FullDocumentImageDpi; set => nativeRecognizer.FullDocumentImageDpi = value; }
        public bool ReturnFullDocumentImage { get => nativeRecognizer.ReturnFullDocumentImage; set => nativeRecognizer.ReturnFullDocumentImage = value; }
        public bool SignResult { get => nativeRecognizer.SignResult; set => nativeRecognizer.SignResult = value; }
        public int NumStableDetectionsThreshold { get => (int)nativeRecognizer.NumStableDetectionsThreshold; set => nativeRecognizer.NumStableDetectionsThreshold = value; }
        public IImageExtensionFactors FullDocumentImageExtensionFactors
        {
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors);
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeFactors;
        }
    }

    public sealed class UsdlCombinedRecognizerResult : RecognizerResult, IUsdlCombinedRecognizerResult
    {
        MBUsdlCombinedRecognizerResult nativeResult;

        internal UsdlCombinedRecognizerResult(MBUsdlCombinedRecognizerResult nativeResult)
            : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }

        public string FirstName => nativeResult.FirstName;

        public string MiddleName => nativeResult.MiddleName;

        public string LastName => nativeResult.LastName;

        public string FullName => nativeResult.FullName;

        public string NameSuffix => nativeResult.NameSuffix;

        public string Address => nativeResult.Address;

        public string DocumentNumber => nativeResult.DocumentNumber;

        public string Sex => nativeResult.Sex;

        public string Restrictions => nativeResult.Restrictions;

        public string Endorsements => nativeResult.Endorsements;

        public string VehicleClass => nativeResult.VehicleClass;

        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;

        public IDate DateOfIssue => nativeResult.DateOfIssue.Date != null ? new Date(nativeResult.DateOfIssue.Date) : null;

        public IDate DateOfExpiry => nativeResult.DateOfExpiry.Date != null ? new Date(nativeResult.DateOfExpiry.Date) : null;

        public bool Uncertain => nativeResult.IsUncertain;

        public string RawStringData => nativeResult.Data.ToString(Foundation.NSStringEncoding.UTF8);

        public byte[] RawData => nativeResult.Data.ToArray();

        public string[] OptionalElements => nativeResult.OptionalElements;

        public byte[] DigitalSignature => nativeResult.DigitalSignature.ToArray();

        public int DigitalSignatureVersion => (int)nativeResult.DigitalSignatureVersion;

        public DataMatchResult DocumentDataMatch => (DataMatchResult)nativeResult.DocumentDataMatch;

        public ImageSource FaceImage => Utils.ConvertUIImage(nativeResult.FaceImage.Image);

        public ImageSource FullDocumentImage => Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image);

        public bool ScanningFirstSideDone => nativeResult.ScanningFirstSideDone;

        public string GetField(UsdlKeys key)
        {
            return nativeResult.GetField((MBUsdlKeys)key);
        }

        public int Age => nativeResult.Age;
    }
}