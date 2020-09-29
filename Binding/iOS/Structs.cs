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
	public enum MBDocumentFaceDetectorType : ulong
	{
		Td1 = 0,
		Td2,
		PassportsAndVisas
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct MBImageExtensionFactors
	{
		public nfloat top;

		public nfloat right;

		public nfloat bottom;

		public nfloat left;
	}

	// static class CFunctions
	// {
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

	[Native]
	public enum MBLicenseError : ulong
	{
		NetworkRequired,
		UnableToDoRemoteLicenceCheck,
		LicenseIsLocked,
		LicenseCheckFailed
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

	[Native]
	public enum MBDataMatchResult : ulong
	{
		NotPerformed = 0,
		Failed,
		Success
	}

	[Native]
	public enum MBMrtdSpecificationPreset : ulong
	{
		MBMrtdSpecificationTd1,
		MBMrtdSpecificationTd2,
		MBMrtdSpecificationTd3
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
	public enum MBIdBarcodeDocumentType : ulong
	{
		None = 0,
		AAMVACompliant,
		ArgentinaID,
		ArgentinaDL,
		ColombiaID,
		ColombiaDL,
		NigeriaVoterID,
		NigeriaDL,
		PanamaID,
		SouthAfricaID
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

	[Native]
	public enum MBCountry : ulong
	{
		None = 0,
		Albania,
		Algeria,
		Argentina,
		Australia,
		Austria,
		Azerbaijan,
		Bahrain,
		Bangladesh,
		Belgium,
		BosniaAndHerzegovina,
		Brunei,
		Bulgaria,
		Cambodia,
		Canada,
		Chile,
		Colombia,
		CostaRica,
		Croatia,
		Cyprus,
		Czechia,
		Denmark,
		DominicanRepublic,
		Egypt,
		Estonia,
		Finland,
		France,
		Georgia,
		Germany,
		Ghana,
		Greece,
		Guatemala,
		HongKong,
		Hungary,
		India,
		Indonesia,
		Ireland,
		Israel,
		Italy,
		Jordan,
		Kazakhstan,
		Kenya,
		Kosovo,
		Kuwait,
		Latvia,
		Lithuania,
		Malaysia,
		Maldives,
		Malta,
		Mauritius,
		Mexico,
		Morocco,
		Netherlands,
		NewZealand,
		Nigeria,
		Pakistan,
		Panama,
		Paraguay,
		Philippines,
		Poland,
		Portugal,
		PuertoRico,
		Qatar,
		Romania,
		Russia,
		SaudiArabia,
		Serbia,
		Singapore,
		Slovakia,
		Slovenia,
		SouthAfrica,
		Spain,
		Sweden,
		Switzerland,
		Taiwan,
		Thailand,
		Tunisia,
		Turkey,
		Uae,
		Uganda,
		Uk,
		Ukraine,
		Usa,
		Vietnam,
		Brazil,
		Norway,
		Oman,
		Ecuador,
		ElSalvador,
		SriLanka,
		Peru,
		Uruguay
	}

	[Native]
	public enum MBRegion : ulong
	{
		None = 0,
		Alabama,
		Alaska,
		Alberta,
		Arizona,
		Arkansas,
		AustralianCapitalTerritory,
		BritishColumbia,
		California,
		Colorado,
		Connecticut,
		Delaware,
		DistrictOfColumbia,
		Florida,
		Georgia,
		Hawaii,
		Idaho,
		Illinois,
		Indiana,
		Iowa,
		Kansas,
		Kentucky,
		Louisiana,
		Maine,
		Manitoba,
		Maryland,
		Massachusetts,
		Michigan,
		Minnesota,
		Mississippi,
		Missouri,
		Montana,
		Nebraska,
		Nevada,
		NewBrunswick,
		NewHampshire,
		NewJersey,
		NewMexico,
		NewSouthWales,
		NewYork,
		NorthernTerritory,
		NorthCarolina,
		NorthDakota,
		NovaScotia,
		Ohio,
		Oklahoma,
		Ontario,
		Oregon,
		Pennsylvania,
		Quebec,
		Queensland,
		RhodeIsland,
		Saskatchewan,
		SouthAustralia,
		SouthCarolina,
		SouthDakota,
		Tasmania,
		Tennessee,
		Texas,
		Utah,
		Vermont,
		Victoria,
		Virginia,
		Washington,
		WesternAustralia,
		WestVirginia,
		Wisconsin,
		Wyoming,
		Yukon,
		CiudadDeMexico,
		Jalisco,
		NewfoundlandAndLabrador,
		NuevoLeon
	}

	[Native]
	public enum MBType : ulong
	{
		None = 0,
		ConsularId,
		Dl,
		DlPublicServicesCard,
		EmploymentPass,
		FinCard,
		Id,
		MultipurposeId,
		MyKad,
		MyKid,
		MyPR,
		MyTentera,
		PanCard,
		ProfessionalId,
		PublicServicesCard,
		ResidencePermit,
		ResidentId,
		TemporaryResidencePermit,
		VoterId,
		WorkPermit,
		iKad,
		MilitaryId,
		MyKas,
		SocialSecurityCard,
		HealthInsuranceCard,
		Passport,
		SPass
	}

	[Native]
	public enum MBDocumentImageColorStatus : ulong
	{
		NotAvailable = 0,
		BlackAndWhite,
		Color
	}

	[Native]
	public enum MBImageAnalysisDetectionStatus : ulong
	{
		NotAvailable = 0,
		NotDetected,
		Detected
	}

	[Native]
	public enum MBAgeLimitStatus : ulong
	{
		NotAvailable,
		BelowAgeLimit,
		OverAgeLimit
	}

	[Native]
	public enum MBAnonymizationMode : ulong
	{
		None = 0,
		ImageOnly,
		ResultFieldsOnly,
		FullResult
	}

	[Native]
	public enum MBProcessorResultState : ulong
	{
		Empty,
		Uncertain,
		Valid
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

	[StructLayout (LayoutKind.Sequential)]
	public struct CGLine
	{
		public CGPoint point1;

		public CGPoint point2;
	}

	[Native]
	public enum MBRecognitionDebugMode : ulong
	{
		Default,
		Test,
		DetectionTest
	}

	[Native]
	public enum MBRecognitionMode : ulong
	{
		None,
		MrzId,
		MrzVisa,
		MrzPassport,
		PhotoId,
		FullRecognition
	}

	[Native]
	public enum MBProcessingStatus : ulong
	{
		Success,
		DetectionFailed,
		ImagePreprocessingFailed,
		StabilityTestFailed,
		ScanningWrongSide,
		FieldIdentificationFailed,
		MandatoryFieldMissing,
		InvalidCharactersFound,
		ImageReturnFailed,
		BarcodeRecognitionFailed,
		MrzParsingFailed,
		ClassFiltered,
		UnsupportedClass,
		UnsupportedByLicense
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
}
