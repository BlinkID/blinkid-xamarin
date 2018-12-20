using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using ObjCRuntime;

namespace Microblink
{
	[Native]
	public enum MBCameraPreset : ulong
	{
		MBCameraPreset480p,
		MBCameraPreset720p,
		Optimal,
		Max,
		Photo
	}

	[Native]
	public enum MBCameraType : ulong
	{
		Back,
		Front
	}

	[Native]
	public enum MBCameraAutofocusRestriction : ulong
	{
		None,
		Near,
		Far
	}

	[Native]
	public enum MBProcessingOrientation : ulong
	{
		Up,
		Right,
		Down,
		Left
	}

	[Native]
	public enum MBRecognizerResultState : ulong
	{
		Empty,
		Uncertain,
		Valid
	}

	[Native]
	public enum MBBarcodeType : ulong
	{
		None = 0,
		TypeQR,
		TypeDataMatrix,
		TypeUPCE,
		TypeUPCA,
		TypeEAN8,
		TypeEAN13,
		TypeCode128,
		TypeCode39,
		TypeITF,
		TypeAztec,
		TypePdf417
	}

	[Native]
	public enum MBDetectionStatus : ulong
	{
		Success = 1 << 0,
		Fail = 1 << 1,
		CameraTooHigh = 1 << 2,
		CameraAtAngle = 1 << 3,
		CameraRotated = 1 << 4,
		QRSuccess = 1 << 6,
		Pdf417Success = 1 << 7,
		FallbackSuccess = 1 << 8,
		PartialForm = 1 << 9,
		CameraTooNear = 1 << 10
	}

	[Native]
	public enum MBDetectionCode : ulong
	{
		Fail = 0,
		Fallback,
		Success
	}

	[Native]
	public enum MBMrtdSpecificationPreset : ulong
	{
		MBMrtdSpecificationTd1,
		MBMrtdSpecificationTd2,
		MBMrtdSpecificationTd3
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct MBRange
	{
		public nfloat start;

		public nfloat stop;
	}

	// static class CFunctions
	// {
	// 	// MBRange MBMakeRange (CGFloat start, CGFloat stop) __attribute__((always_inline));
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern MBRange MBMakeRange (nfloat start, nfloat stop);

	// 	// MBScale MBMakeScale (CGFloat scale, CGFloat tolerance) __attribute__((always_inline));
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern MBScale MBMakeScale (nfloat scale, nfloat tolerance);

	// 	// MBImageExtensionFactors MBMakeImageExtensionFactors (CGFloat top, CGFloat right, CGFloat bottom, CGFloat left) __attribute__((always_inline));
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern MBImageExtensionFactors MBMakeImageExtensionFactors (nfloat top, nfloat right, nfloat bottom, nfloat left);

	// 	// extern CGDelta CGDeltaMake (CGFloat deltaX, CGFloat deltaY);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGDelta CGDeltaMake (nfloat deltaX, nfloat deltaY);

	// 	// extern CGPoint CGPointWithDelta (CGPoint point, CGDelta delta);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGPoint CGPointWithDelta (CGPoint point, CGDelta delta);

	// 	// extern CGFloat CGPointDistance (CGPoint p1, CGPoint p2);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern nfloat CGPointDistance (CGPoint p1, CGPoint p2);

	// 	// extern CGPoint CGPointAlongLine (CGLine line, CGFloat distance);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGPoint CGPointAlongLine (CGLine line, nfloat distance);

	// 	// extern CGPoint CGPointRotatedAroundPoint (CGPoint point, CGPoint pivot, CGFloat degrees);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGPoint CGPointRotatedAroundPoint (CGPoint point, CGPoint pivot, nfloat degrees);

	// 	// extern CGLine CGLineMake (CGPoint point1, CGPoint point2);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGLine CGLineMake (CGPoint point1, CGPoint point2);

	// 	// extern _Bool CGLineEqualToLine (CGLine line1, CGLine line2);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern bool CGLineEqualToLine (CGLine line1, CGLine line2);

	// 	// extern CGPoint CGLineMidPoint (CGLine line);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGPoint CGLineMidPoint (CGLine line);

	// 	// extern CGFloat CGLineDirection (CGLine line);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern nfloat CGLineDirection (CGLine line);

	// 	// extern CGFloat CGLinesAngle (CGLine line1, CGLine line2);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern nfloat CGLinesAngle (CGLine line1, CGLine line2);

	// 	// extern CGPoint CGLinesIntersectAtPoint (CGLine line1, CGLine line2);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGPoint CGLinesIntersectAtPoint (CGLine line1, CGLine line2);

	// 	// extern CGFloat CGLineLength (CGLine line);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern nfloat CGLineLength (CGLine line);

	// 	// extern CGLine CGLineScale (CGLine line, CGFloat scale);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGLine CGLineScale (CGLine line, nfloat scale);

	// 	// extern CGLine CGLineTranslate (CGLine line, CGDelta delta);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGLine CGLineTranslate (CGLine line, CGDelta delta);

	// 	// extern CGLine CGLineScaleOnMidPoint (CGLine line, CGFloat scale);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGLine CGLineScaleOnMidPoint (CGLine line, nfloat scale);

	// 	// extern CGDelta CGLineDelta (CGLine line);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGDelta CGLineDelta (CGLine line);

	// 	// extern _Bool CGLinesAreParallel (CGLine line1, CGLine line2);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern bool CGLinesAreParallel (CGLine line1, CGLine line2);

	// 	// extern CGPoint CGRectTopLeftPoint (CGRect rect);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGPoint CGRectTopLeftPoint (CGRect rect);

	// 	// extern CGPoint CGRectTopRightPoint (CGRect rect);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGPoint CGRectTopRightPoint (CGRect rect);

	// 	// extern CGPoint CGRectBottomLeftPoint (CGRect rect);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGPoint CGRectBottomLeftPoint (CGRect rect);

	// 	// extern CGPoint CGRectBottomRightPoint (CGRect rect);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGPoint CGRectBottomRightPoint (CGRect rect);

	// 	// extern CGRect CGRectResize (CGRect rect, CGSize newSize);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGRect CGRectResize (CGRect rect, CGSize newSize);

	// 	// extern CGRect CGRectInsetEdge (CGRect rect, CGRectEdge edge, CGFloat amount);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGRect CGRectInsetEdge (CGRect rect, CGRectEdge edge, nfloat amount);

	// 	// extern CGRect CGRectStackedWithinRectFromEdge (CGRect rect, CGSize size, int count, CGRectEdge edge, _Bool reverse);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGRect CGRectStackedWithinRectFromEdge (CGRect rect, CGSize size, int count, CGRectEdge edge, bool reverse);

	// 	// extern CGPoint CGRectCenterPoint (CGRect rect);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGPoint CGRectCenterPoint (CGRect rect);

	// 	// extern void CGRectClosestTwoCornerPoints (CGRect rect, CGPoint point, CGPoint *point1, CGPoint *point2);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern unsafe void CGRectClosestTwoCornerPoints (CGRect rect, CGPoint point, CGPoint* point1, CGPoint* point2);

	// 	// extern CGPoint CGLineIntersectsRectAtPoint (CGRect rect, CGLine line);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGPoint CGLineIntersectsRectAtPoint (CGRect rect, CGLine line);

	// 	// extern void CGControlPointsForArcBetweenPointsWithRadius (CGPoint startPoint, CGPoint endPoint, CGFloat radius, _Bool rightHandRule, CGPoint *controlPoint1, CGPoint *controlPoint2);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern unsafe void CGControlPointsForArcBetweenPointsWithRadius (CGPoint startPoint, CGPoint endPoint, nfloat radius, bool rightHandRule, CGPoint* controlPoint1, CGPoint* controlPoint2);

	// 	// extern CGRect scanningRegionForFrameInBounds (CGRect frame, CGRect bounds) __attribute__((visibility("default")));
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern CGRect scanningRegionForFrameInBounds (CGRect frame, CGRect bounds);
	// }

	[StructLayout (LayoutKind.Sequential)]
	public struct MBScale
	{
		public nfloat scale;

		public nfloat tolerance;
	}

	[Native]
	public enum MBScanningMode : ulong
	{
		Auto,
		Landscape,
		Portrait
	}

	[Native]
	public enum MBDocumentSpecificationPreset : ulong
	{
		Id1Card,
		Id2Card,
		Cheque,
		A4Portrait,
		A4Landscape,
		Id1VerticalCard,
		Id2VerticalCard
	}

	[Native]
	public enum MBParserResultState : ulong
	{
		Empty,
		Uncertain,
		Valid
	}

	[Native]
	public enum MBTopUpPreset : ulong
	{
		MBTopUp123,
		MBTopUp103,
		MBTopUp131,
		Generic
	}

	[Native]
	public enum MBDateFormat : ulong
	{
		Ddmmyyyy = 0,
		Ddmmyy,
		Mmddyyyy,
		Mmddyy,
		Yyyymmdd,
		Yymmdd,
		Ddmonthyyyy,
		Ddmonthyy,
		Monthddyyyy,
		Monthddyy,
		Yyyymonthdd,
		Yymonthdd
	}

	[Native]
	public enum MBDeepOcrModel : ulong
	{
		MBDeepOcrModelBlinkInput
	}

	[Native]
	public enum MBOcrFont : ulong
	{
		AkzidenzGrotesk,
		Arial,
		ArialBlack,
		Arnhem,
		AvantGarde,
		Bembo,
		Bodoni,
		Calibri,
		CalibriBold,
		Chainprinter,
		ComicSans,
		ConcertoRoundedSg,
		Courier,
		CourierBold,
		CourierMediumBold,
		CourierNewBold,
		CourierNewCe,
		CourierCondensed,
		DejavuSansMono,
		Din,
		EuropaGroteskNo2SbBold,
		Eurostile,
		F25BankPrinterBold,
		FranklinGothic,
		Frutiger,
		Futura,
		FuturaBold,
		Garamond,
		Georgia,
		GillSans,
		Handwritten,
		Helvetica,
		HelveticaBold,
		HelveticaCondensedLight,
		Hypermarket,
		Interstate,
		LatinModern,
		LatinModernItalic,
		LetterGothic,
		Lucida,
		LucidaSans,
		Matrix,
		Meta,
		Minion,
		Ocra,
		Ocrb,
		Officina,
		Optima,
		Printf,
		Rockwell,
		RotisSansSerif,
		RotisSerif,
		Sabon,
		Stone,
		SvBasicManual,
		Tahoma,
		TahomaBold,
		TexGyreTermes,
		TexGyreTermesItalic,
		TheSansMonoCondensedBlack,
		Thesis,
		TicketDeCaisse,
		TimesNewRoman,
		Trajan,
		Trinite,
		Univers,
		Verdana,
		Voltaire,
		Walbaum,
		EuropaGroSb,
		EuropaGroSbLight,
		AntonioRegular,
		CorporateLight,
		Micr,
		ArabicNile,
		Unknown,
		XitsMath,
		Any,
		UnknownMath,
		UkdlLight,
		Count,
		FeSchrift
	}

	[Native]
	public enum PPDocumentType : ulong
	{
		BlinkOCRDocumentType,
		MicrDocumentType,
		ArabicDocumentType,
		HandwrittenDocumentType
	}

	[Native]
	public enum MBProcessorResultState : ulong
	{
		Empty,
		Uncertain,
		Valid
	}

	[Native]
	public enum MBMrtdDocumentType : ulong
	{
		Unknown,
		IdentityCard,
		Passport,
		Visa,
		GreenCard
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct MBImageExtensionFactors
	{
		public nfloat top;

		public nfloat right;

		public nfloat bottom;

		public nfloat left;
	}

	[Native]
	public enum MBDocumentFaceDetectorType : ulong
	{
		Td1 = 0,
		Td2,
		PassportsAndVisas
	}

	[Native]
	public enum MBEudlCountry : ulong
	{
		UnitedKingdom,
		Germany,
		Austria,
		Any
	}

	[Native]
	public enum MBUsdlKeys : ulong
	{
		DocumentType,
		StandardVersionNumber,
		CustomerFamilyName,
		CustomerFirstName,
		CustomerFullName,
		DateOfBirth,
		Sex,
		EyeColor,
		AddressStreet,
		AddressCity,
		AddressJurisdictionCode,
		AddressPostalCode,
		FullAddress,
		Height,
		HeightIn,
		HeightCm,
		CustomerMiddleName,
		HairColor,
		NameSuffix,
		AKAFullName,
		AKAFamilyName,
		AKAGivenName,
		AKASuffixName,
		WeightRange,
		WeightPounds,
		WeightKilograms,
		CustomerIdNumber,
		FamilyNameTruncation,
		FirstNameTruncation,
		MiddleNameTruncation,
		PlaceOfBirth,
		AddressStreet2,
		RaceEthnicity,
		NamePrefix,
		CountryIdentification,
		ResidenceStreetAddress,
		ResidenceStreetAddress2,
		ResidenceCity,
		ResidenceJurisdictionCode,
		ResidencePostalCode,
		ResidenceFullAddress,
		Under18,
		Under19,
		Under21,
		SocialSecurityNumber,
		AKASocialSecurityNumber,
		AKAMiddleName,
		AKAPrefixName,
		OrganDonor,
		Veteran,
		AKADateOfBirth,
		IssuerIdentificationNumber,
		DocumentExpirationDate,
		JurisdictionVersionNumber,
		JurisdictionVehicleClass,
		JurisdictionRestrictionCodes,
		JurisdictionEndorsementCodes,
		DocumentIssueDate,
		FederalCommercialVehicleCodes,
		IssuingJurisdiction,
		StandardVehicleClassification,
		IssuingJurisdictionName,
		StandardEndorsementCode,
		StandardRestrictionCode,
		JurisdictionVehicleClassificationDescription,
		JurisdictionEndorsmentCodeDescription,
		JurisdictionRestrictionCodeDescription,
		InventoryControlNumber,
		CardRevisionDate,
		DocumentDiscriminator,
		LimitedDurationDocument,
		AuditInformation,
		ComplianceType,
		IssueTimestamp,
		PermitExpirationDate,
		PermitIdentifier,
		PermitIssueDate,
		NumberOfDuplicates,
		HAZMATExpirationDate,
		MedicalIndicator,
		NonResident,
		UniqueCustomerId,
		DataDiscriminator,
		DocumentExpirationMonth,
		DocumentNonexpiring,
		SecurityVersion
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CGLine
	{
		public CGPoint point1;

		public CGPoint point2;
	}

	[Native]
	public enum MBRecognitionMode : ulong
	{
		Default,
		Test,
		DetectionTest
	}

	[Native]
	public enum MBFrameQualityEstimationMode : ulong
	{
		Default,
		On,
		Off
	}

	[Native]
	public enum MBDocumentVerificationHighResImageState : ulong
	{
		FrontSide,
		BackSideSide
	}
}
