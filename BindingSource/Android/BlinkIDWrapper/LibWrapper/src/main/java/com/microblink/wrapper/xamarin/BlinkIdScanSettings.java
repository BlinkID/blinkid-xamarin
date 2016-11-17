package com.microblink.wrapper.xamarin;

import android.content.Context;
import android.support.annotation.Nullable;

import com.microblink.detectors.document.DocumentDetectorSettings;
import com.microblink.detectors.document.DocumentSpecification;
import com.microblink.detectors.document.DocumentSpecificationPreset;
import com.microblink.hardware.camera.CameraType;
import com.microblink.recognizers.blinkbarcode.bardecoder.BarDecoderRecognizerSettings;
import com.microblink.recognizers.blinkbarcode.pdf417.Pdf417RecognizerSettings;
import com.microblink.recognizers.blinkbarcode.usdl.USDLRecognizerSettings;
import com.microblink.recognizers.blinkbarcode.zxing.ZXingRecognizerSettings;
import com.microblink.recognizers.blinkid.austria.back.AustrianIDBackSideRecognizerSettings;
import com.microblink.recognizers.blinkid.austria.front.AustrianIDFrontSideRecognizerSettings;
import com.microblink.recognizers.blinkid.croatia.back.CroatianIDBackSideRecognizerSettings;
import com.microblink.recognizers.blinkid.croatia.front.CroatianIDFrontSideRecognizerSettings;
import com.microblink.recognizers.blinkid.czechia.back.CzechIDBackSideRecognizerSettings;
import com.microblink.recognizers.blinkid.czechia.front.CzechIDFrontSideRecognizerSettings;
import com.microblink.recognizers.blinkid.eudl.EUDLCountry;
import com.microblink.recognizers.blinkid.eudl.EUDLRecognizerSettings;
import com.microblink.recognizers.blinkid.germany.front.GermanIDFrontSideRecognizerSettings;
import com.microblink.recognizers.blinkid.germany.mrz.GermanIDMRZSideRecognizerSettings;
import com.microblink.recognizers.blinkid.malaysia.IKadRecognizerSettings;
import com.microblink.recognizers.blinkid.malaysia.MyKadRecognizerSettings;
import com.microblink.recognizers.blinkid.mrtd.MRTDRecognizerSettings;
import com.microblink.recognizers.blinkid.serbia.back.SerbianIDBackSideRecognizerSettings;
import com.microblink.recognizers.blinkid.serbia.front.SerbianIDFrontSideRecognizerSettings;
import com.microblink.recognizers.blinkid.singapore.SingaporeIDRecognizerSettings;
import com.microblink.recognizers.blinkid.slovakia.back.SlovakIDBackSideRecognizerSettings;
import com.microblink.recognizers.blinkid.slovakia.front.SlovakIDFrontSideRecognizerSettings;
import com.microblink.recognizers.blinkid.slovenia.back.SlovenianIDBackSideRecognizerSettings;
import com.microblink.recognizers.blinkid.slovenia.front.SlovenianIDFrontSideRecognizerSettings;
import com.microblink.recognizers.blinkocr.BlinkOCRRecognizerSettings;
import com.microblink.recognizers.blinkocr.parser.OcrParserSettings;
import com.microblink.recognizers.blinkocr.parser.generic.AmountParserSettings;
import com.microblink.recognizers.blinkocr.parser.generic.DateParserSettings;
import com.microblink.recognizers.blinkocr.parser.generic.EMailParserSettings;
import com.microblink.recognizers.blinkocr.parser.generic.IbanParserSettings;
import com.microblink.recognizers.blinkocr.parser.generic.RawParserSettings;
import com.microblink.recognizers.blinkocr.parser.licenseplates.LicensePlatesParserSettings;
import com.microblink.recognizers.blinkocr.parser.mobilecoupons.MobileCouponsParserSettings;
import com.microblink.recognizers.blinkocr.parser.regex.RegexParserSettings;
import com.microblink.recognizers.blinkocr.parser.vin.VinParserSettings;
import com.microblink.recognizers.detector.DetectorRecognizerSettings;
import com.microblink.recognizers.settings.RecognizerSettings;
import com.microblink.util.RecognizerCompatibility;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.Map;
import java.util.Set;

/**
 * BlinkID scan settings that define which camera type and which recognizers, parsers and detectors
 * will be used. Also settings can be used to define whether to allow multiple scan results or not.
 */
public class BlinkIdScanSettings {

    private static final String EUDL_FULL_DOCUMENT_IMAGE_NAME = "EUDL";
    private static final String MRTD_FULL_DOCUMENT_IMAGE_NAME = "MRTD";
    private static final String ID_CARD_DETECTOR_IMAGE_NAME = "DocumentDetector/IDCard";

    private ArrayList<RecognizerSettings> mRecognizers;
    private Map<String, OcrParserSettings> mParsers;
    private DeviceCameraType mCameraType;
    private boolean mCameraHasAutofocus;
    private Set<String> mAcceptedImageNames;

    private boolean mAllowMultipleScanResultsOnSingleImage;

    /**
     * Settings constructor that accepts camera type that will be used as argument.
     * @param context Application context.
     * @param cameraType Device camera type that will be used.
     */
    public BlinkIdScanSettings(Context context, DeviceCameraType cameraType) {
        mRecognizers = new ArrayList<>();
        mParsers = new HashMap<>();
        mCameraType = cameraType;
        mAcceptedImageNames = new HashSet<>();

        // check whether chosen camera has autofocus
        CameraType camera = CameraType.CAMERA_DEFAULT;
        if (cameraType != DeviceCameraType.CAMERA_DEFAULT) {
            if (cameraType == DeviceCameraType.CAMERA_FRONTFACE) {
                camera = CameraType.CAMERA_FRONTFACE;
            } else if (cameraType == DeviceCameraType.CAMERA_BACKFACE) {
                camera = CameraType.CAMERA_BACKFACE;
            }
        }
        mCameraHasAutofocus = RecognizerCompatibility.cameraHasAutofocus(camera, context);
    }

    /**
     * Settings constructor for settings with default device camera type.
     * @param context Application context.
     */
    public BlinkIdScanSettings(Context context) {
        this(context, DeviceCameraType.CAMERA_DEFAULT);
    }

    /**
     * Sets whether or not outputting of multiple scan results from same image
     * is allowed. If that is true, it is possible to return multiple
     * recognition results from same image. If this option is false, the array
     * of BaseRecognitionResults will contain at most 1 element. The upside of setting that option
     * to false is the speed - if you enable lots of recognizers, as soon as the first recognizer
     * succeeds in scanning, recognition chain will be terminated and other
     * recognizers will not get a chance to analyze the image. The downside is
     * that you are then unable to obtain multiple results from single image.
     */
    public void setAllowMultipleScanResultsOnSingleImage(boolean allowMultipleScanResultsOnSingleImage) {
        mAllowMultipleScanResultsOnSingleImage = allowMultipleScanResultsOnSingleImage;
    }

    /**
     * Returns true if multiple scan results can be obtained from single image. See
     * {@link #setAllowMultipleScanResultsOnSingleImage} for details.
     *
     * @return true if multiple scan results can be obtained from single image.
     */
    public boolean shouldAllowMultipleScanResultsOnSingleImage() {
        return mAllowMultipleScanResultsOnSingleImage;
    }

    /**
     * Adds recognizer for back side of the Austrian ID card if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerAustrianIdBack() {
        AustrianIDBackSideRecognizerSettings ausIdBack = new AustrianIDBackSideRecognizerSettings();
        ausIdBack.setDisplayFullDocumentImage(true);
        return addRecognizer(ausIdBack, AustrianIDBackSideRecognizerSettings.FULL_DOCUMENT_IMAGE);
    }

    /**
     * Adds recognizer for front side of the Austrian ID card if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerAustrianIdFront() {
        AustrianIDFrontSideRecognizerSettings ausIdFront = new AustrianIDFrontSideRecognizerSettings();
        ausIdFront.setDisplayFullDocumentImage(true);
        return addRecognizer(ausIdFront, AustrianIDFrontSideRecognizerSettings.FULL_DOCUMENT_IMAGE);
    }

    /**
     * Adds recognizer for back side of the Croatian ID card if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerCroatianIdBack() {
        CroatianIDBackSideRecognizerSettings croIdBack = new CroatianIDBackSideRecognizerSettings();
        croIdBack.setDisplayFullDocumentImage(true);
        return addRecognizer(croIdBack, CroatianIDBackSideRecognizerSettings.FULL_DOCUMENT_IMAGE);
    }

    /**
     * Adds recognizer for front side of the Croatian ID card if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerCroatianIdFront() {
        CroatianIDFrontSideRecognizerSettings croIdFront = new CroatianIDFrontSideRecognizerSettings();
        croIdFront.setDisplayFullDocumentImage(true);
        return addRecognizer(croIdFront, CroatianIDFrontSideRecognizerSettings.FULL_DOCUMENT_IMAGE);
    }

    /**
     * Adds recognizer for back side of the Czech ID card if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerCzechIdBack() {
        CzechIDBackSideRecognizerSettings czIdBack = new CzechIDBackSideRecognizerSettings();
        czIdBack.setDisplayFullDocumentImage(true);
        return addRecognizer(czIdBack, CzechIDBackSideRecognizerSettings.FULL_DOCUMENT_IMAGE);
    }

    /**
     * Adds recognizer for front side of the Czech ID card if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerCzechIdFront() {
        CzechIDFrontSideRecognizerSettings czIdFront = new CzechIDFrontSideRecognizerSettings();
        czIdFront.setDisplayFullDocumentImage(true);
        return addRecognizer(czIdFront, CzechIDFrontSideRecognizerSettings.FULL_DOCUMENT_IMAGE);
    }

    /**
     * Adds recognizer for front side of the German ID card (new ID cards) if it is supported on
     * current device and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerGermanIdFront() {
        GermanIDFrontSideRecognizerSettings deIdFront = new GermanIDFrontSideRecognizerSettings();
        deIdFront.setDisplayFullDocumentImage(true);
        return addRecognizer(deIdFront, GermanIDFrontSideRecognizerSettings.FULL_DOCUMENT_IMAGE);
    }

    /**
     * Adds recognizer for MRZ side of the German ID card if it is supported on current device
     * and chosen camera type (on old ID cards MRZ side is the front side, on new ID cards MRZ side
     * is the back side).
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerGermanIdMrzSide() {
        GermanIDMRZSideRecognizerSettings deIdMrz = new GermanIDMRZSideRecognizerSettings();
        deIdMrz.setDisplayFullDocumentImage(true);
        return addRecognizer(deIdMrz, GermanIDMRZSideRecognizerSettings.FULL_DOCUMENT_IMAGE);
    }

    /**
     * Adds recognizer for back side of the Serbian ID card if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerSerbianIdBack() {
        SerbianIDBackSideRecognizerSettings srbIdBack = new SerbianIDBackSideRecognizerSettings();
        srbIdBack.setDisplayFullDocumentImage(true);
        return addRecognizer(srbIdBack, SerbianIDBackSideRecognizerSettings.FULL_DOCUMENT_IMAGE);
    }

    /**
     * Adds recognizer for front side of the Serbian ID card if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerSerbianIdFront() {
        SerbianIDFrontSideRecognizerSettings srbIdFront = new SerbianIDFrontSideRecognizerSettings();
        srbIdFront.setReturnFullDocumentPhoto(true);
        return addRecognizer(srbIdFront, SerbianIDFrontSideRecognizerSettings.FULL_DOCUMENT_IMAGE);
    }

    /**
     * Adds recognizer for back side of the Slovak ID card if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerSlovakIdBack() {
        SlovakIDBackSideRecognizerSettings svkIdBack = new SlovakIDBackSideRecognizerSettings();
        svkIdBack.setDisplayFullDocumentImage(true);
        return addRecognizer(svkIdBack, SlovakIDBackSideRecognizerSettings.FULL_DOCUMENT_IMAGE);
    }

    /**
     * Adds recognizer for front side of the Slovak ID card if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerSlovakIdFront() {
        SlovakIDFrontSideRecognizerSettings svkIdFront = new SlovakIDFrontSideRecognizerSettings();
        svkIdFront.setDisplayFullDocumentImage(true);
        return addRecognizer(svkIdFront, SlovakIDFrontSideRecognizerSettings.FULL_DOCUMENT_IMAGE);
    }

    /**
     * Adds recognizer for back side of the Slovenian ID card if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerSlovenianIdBack() {
        SlovenianIDBackSideRecognizerSettings svnIdBack = new SlovenianIDBackSideRecognizerSettings();
        svnIdBack.setDisplayFullDocumentImage(true);
        return addRecognizer(svnIdBack, SlovenianIDBackSideRecognizerSettings.FULL_DOCUMENT_IMAGE);
    }

    /**
     * Adds recognizer for front side of the Slovenian ID card if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerSlovenianIdFront() {
        SlovenianIDFrontSideRecognizerSettings svnIdFront = new SlovenianIDFrontSideRecognizerSettings();
        svnIdFront.setDisplayFullDocumentImage(true);
        return addRecognizer(svnIdFront, SlovenianIDFrontSideRecognizerSettings.FULL_DOCUMENT_IMAGE);
    }

    /**
     * Adds Singapore ID card recognizer if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerSingaporeId() {
        SingaporeIDRecognizerSettings singaporeId = new SingaporeIDRecognizerSettings();
        singaporeId.setDisplayFullDocumentImage(true);
        return addRecognizer(singaporeId, SingaporeIDRecognizerSettings.FULL_DOCUMENT_IMAGE_NAME);
    }

    /**
     * Adds Malaysian MyKad ID document recognizer if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerMyKad() {
        MyKadRecognizerSettings myKad = new MyKadRecognizerSettings();
        myKad.setShowFullDocument(true);
        return addRecognizer(myKad, MyKadRecognizerSettings.FULL_DOCUMENT_IMAGE);
    }

    /**
     * Adds Malaysian iKad document recognizer if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerIKad() {
        IKadRecognizerSettings iKad = new IKadRecognizerSettings();
        iKad.setShowFullDocumentImage(true);
        return addRecognizer(iKad, IKadRecognizerSettings.FULL_DOCUMENT_IMAGE);
    }

    /**
     * Adds MRTD(Machine Readable Travel Document) recognizer if it is supported on current device
     * and chosen camera type. MRTD recognizer reads MRZ zone.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerMRTD() {
        MRTDRecognizerSettings mrtd = new MRTDRecognizerSettings();
        mrtd.setShowFullDocument(true);
        return addRecognizer(mrtd, MRTD_FULL_DOCUMENT_IMAGE_NAME);
    }

    /**
     * Adds USDL (US Driver's license) recognizer if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerUSDL() {
        return addRecognizer(new USDLRecognizerSettings());
    }

    /**
     * Adds Austrian DL (Austrian Driver's license) recognizer if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerAustrianDL() {
        // To specify we want to perform EUDL (EU Driver's License) recognition,
        // prepare settings for EUDL recognizer. Pass country as parameter to EUDLRecognizerSettings
        // constructor. Here we choose Austria.
        EUDLRecognizerSettings ausDL = new EUDLRecognizerSettings(EUDLCountry.EUDL_COUNTRY_AUSTRIA);
        ausDL.setShowFullDocument(true);
        return addRecognizer(ausDL, EUDL_FULL_DOCUMENT_IMAGE_NAME);
    }

    /**
     * Adds UKDL (UK Driver's license) recognizer if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerUKDL() {
        // To specify we want to perform EUDL (EU Driver's License) recognition,
        // prepare settings for EUDL recognizer. Pass country as parameter to EUDLRecognizerSettings
        // constructor. Here we choose UK.
        EUDLRecognizerSettings ukDL =  new EUDLRecognizerSettings(EUDLCountry.EUDL_COUNTRY_UK);
        ukDL.setShowFullDocument(true);
        return addRecognizer(ukDL, EUDL_FULL_DOCUMENT_IMAGE_NAME);
    }

    /**
     * Adds DEDL (German Driver's license) recognizer if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerDEDL() {
        // To specify we want to perform EUDL (EU Driver's License) recognition,
        // prepare settings for EUDL recognizer. Pass country as parameter to EUDLRecognizerSettings
        // constructor. Here we choose Germany.
        EUDLRecognizerSettings deDL =  new EUDLRecognizerSettings(EUDLCountry.EUDL_COUNTRY_GERMANY);
        deDL.setShowFullDocument(true);
        return addRecognizer(deDL, EUDL_FULL_DOCUMENT_IMAGE_NAME);
    }

    /**
     * Adds EUDL(European Driver's Licenses) recognizer if it is supported on current device
     * and chosen camera type. This recognizer is used for scanning all supported EU driver's
     * licenses, type (country) will be automatically detected.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerEUDL() {
        EUDLRecognizerSettings eudl = buildEUDLRecognizerSettings();
        eudl.setShowFullDocument(true);
        return addRecognizer(eudl, EUDL_FULL_DOCUMENT_IMAGE_NAME);
    }

    /**
     * Adds Pdf417 barcode recognizer if it is supported on current device
     * and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerPdf417() {
        return addRecognizer(buildPdf417RecognizerSettings());
    }

    /**
     * Adds bardecoder recognizer if it is supported on current device and chosen camera type.
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise. BarDecoder recognizer defines settings for scanning 1D barcodes
     * with algorithms implemented by Microblink team. Enabled barcodes are: code 128 and code 39.
     */
    public boolean addRecognizerBarDecoder() {
        return addRecognizer(buildBardecoderRecognizerSettings());
    }

    /**
     * Adds ZXing recognizer if it is supported on current device and chosen camera type.
     * ZXing recognizer can recognize various barcode types. Enabled barcodes are:
     * QR code, Aztec code, code 128, code 39, Data matrix, ean 13, ean 8, UPC A, UPC E
     * @return returns {@code true} if recognizer is supported on current device and chosen
     * camera type, {@code false} otherwise.
     */
    public boolean addRecognizerZxing() {
        return addRecognizer(buildZxingRecognizerSettings());
    }

    /**
     * Adds Raw text parser if it is supported on current device and chosen camera type.
     * @return returns {@code true} if parser is supported on current device and chosen
     * camera type, {@code false} otherwise.
     * @param uniqueIdentifier parser identifier that should be used to obtain parser result
     * @param required if parser is required and there are multiple active parsers, result from
     *                 ocr parsers will be returned only if result from this parser is available.
     */
    public boolean addParserRaw(String uniqueIdentifier, boolean required) {
        return addParser(uniqueIdentifier, new RawParserSettings(), required);
    }

    /**
     * Adds Amount parser if it is supported on current device and chosen camera type.
     * @return returns {@code true} if parser is supported on current device and chosen
     * camera type, {@code false} otherwise.
     * @param uniqueIdentifier parser identifier that should be used to obtain parser result
     * @param required if parser is required and there are multiple active parsers, result from
     *                 ocr parsers will be returned only if result from this parser is available.
     */
    public boolean addParserAmount(String uniqueIdentifier, boolean required) {
        return addParser(uniqueIdentifier, new AmountParserSettings(), required);
    }

    /**
     * Adds Date parser if it is supported on current device and chosen camera type.
     * @return returns {@code true} if parser is supported on current device and chosen
     * camera type, {@code false} otherwise.
     * @param uniqueIdentifier parser identifier that should be used to obtain parser result
     * @param required if parser is required and there are multiple active parsers, result from
     *                 ocr parsers will be returned only if result from this parser is available.
     */
    public boolean addParserDate(String uniqueIdentifier, boolean required) {
        return addParser(uniqueIdentifier, new DateParserSettings(), required);
    }

    /**
     * Adds EMail parser if it is supported on current device and chosen camera type.
     * @return returns {@code true} if parser is supported on current device and chosen
     * camera type, {@code false} otherwise.
     * @param uniqueIdentifier parser identifier that should be used to obtain parser result
     * @param required if parser is required and there are multiple active parsers, result from
     *                 ocr parsers will be returned only if result from this parser is available.
     */
    public boolean addParserEmail(String uniqueIdentifier, boolean required) {
        return addParser(uniqueIdentifier, new EMailParserSettings(), required);
    }

    /**
     * Adds IBAN parser if it is supported on current device and chosen camera type.
     * @return returns {@code true} if parser is supported on current device and chosen
     * camera type, {@code false} otherwise.
     * @param uniqueIdentifier parser identifier that should be used to obtain parser result
     * @param required if parser is required and there are multiple active parsers, result from
     *                 ocr parsers will be returned only if result from this parser is available.
     */
    public boolean addParserIBAN(String uniqueIdentifier, boolean required) {
        return addParser(uniqueIdentifier, new IbanParserSettings(), required);
    }

    /**
     * Adds VIN (Vehicle Identifier Number) parser if it is supported on current device and chosen camera type.
     * @return returns {@code true} if parser is supported on current device and chosen
     * camera type, {@code false} otherwise.
     * @param uniqueIdentifier parser identifier that should be used to obtain parser result
     * @param required if parser is required and there are multiple active parsers, result from
     *                 ocr parsers will be returned only if result from this parser is available.
     */
    public boolean addParserVIN(String uniqueIdentifier, boolean required) {
        return addParser(uniqueIdentifier, new VinParserSettings(), required);
    }

    /**
     * Adds License Plates parser if it is supported on current device and chosen camera type.
     * @return returns {@code true} if parser is supported on current device and chosen
     * camera type, {@code false} otherwise.
     * @param uniqueIdentifier parser identifier that should be used to obtain parser result
     * @param required if parser is required and there are multiple active parsers, result from
     *                 ocr parsers will be returned only if result from this parser is available.
     */
    public boolean addParserLicensePlates(String uniqueIdentifier, boolean required) {
        return addParser(uniqueIdentifier, new LicensePlatesParserSettings(), required);
    }

    /**
     * Adds Regex parser if it is supported on current device and chosen camera type.
     * @return returns {@code true} if parser is supported on current device and chosen
     * camera type, {@code false} otherwise.
     * @param uniqueIdentifier parser identifier that should be used to obtain parser result
     * @param regex Regex pattern.
     * @param required if parser is required and there are multiple active parsers, result from
     *                 ocr parsers will be returned only if result from this parser is available.
     */
    public boolean addParserRegex(String uniqueIdentifier, String regex, boolean required) {
        return addParser(uniqueIdentifier, new RegexParserSettings(regex), required);
    }

    /**
     * Adds Mobile Coupons parser, used for parsing mobile phone coupons prepaid codes
     * with given prefix code and ussd code length in format: *prefixString*USSDCodeLength_digits#
     * if it is supported on current device and chosen camera type.
     * @return returns {@code true} if parser is supported on current device and chosen
     * camera type, {@code false} otherwise.
     * @param uniqueIdentifier parser identifier that should be used to obtain parser result
     * @param prefixString prefix string enclosed with asterisks
     * @param USSDCodeLength number of digits between prefix and hash character
     * @param required if parser is required and there are multiple active parsers, result from
     *                 ocr parsers will be returned only if result from this parser is available.
     */
    public boolean addParserMobileCoupons(String uniqueIdentifier, String prefixString, int USSDCodeLength, boolean required) {
        return addParser(uniqueIdentifier, new MobileCouponsParserSettings(prefixString, USSDCodeLength), required);
    }

    /**
     * Adds ID card detector if it is supported on current device and chosen camera type.
     * @return returns {@code true} if detector is supported on current device and chosen
     * camera type, {@code false} otherwise. Detector returns document image.
     */
    public boolean addDetectorIdCard() {
        return addRecognizer(buildIdCardDetectorRecognizerSettings(), ID_CARD_DETECTOR_IMAGE_NAME);
    }


    /**
     * Builds {@link DetectorRecognizerSettings} which define settings for detection of
     * various document types, enabled document type is ID card.
     */
    private DetectorRecognizerSettings buildIdCardDetectorRecognizerSettings() {
        DocumentSpecification idSpec = DocumentSpecification.createFromPreset(
                DocumentSpecificationPreset.DOCUMENT_SPECIFICATION_PRESET_ID1_CARD);
        DocumentDetectorSettings dds = new DocumentDetectorSettings( new DocumentSpecification[] {idSpec});
        dds.setNumStableDetectionsThreshold(2);
        return new DetectorRecognizerSettings(dds);
    }

    /**
     * Builds {@link ZXingRecognizerSettings} which define settings for scanning various barcode
     * types, enabled barcodes are: QR code, Aztec code, code 128, code 39, Data matrix, ean 13,
     * ean 8, UPC A, UPC E
     */
    private ZXingRecognizerSettings buildZxingRecognizerSettings() {
        // ZXingRecognizerSettings define settings for scanning various barcode types, by
        // default all barcode types are disabled
        ZXingRecognizerSettings zxingSettings = new ZXingRecognizerSettings();

        // by default all barcode types are disabled
        zxingSettings.setScanQRCode(true);
        zxingSettings.setScanAztecCode(true);
        zxingSettings.setScanCode128(true);
        zxingSettings.setScanCode39(true);
        zxingSettings.setScanDataMatrixCode(true);
        zxingSettings.setScanEAN13Code(true);
        zxingSettings.setScanEAN8Code(true);
        zxingSettings.setScanITFCode(false);
        zxingSettings.setScanUPCACode(true);
        zxingSettings.setScanUPCECode(true);
        // By setting this to true, you will enable scanning of barcodes with inverse
        // intensity values (i.e. white barcodes on dark background). This option can
        // significantly increase recognition time. Default is false
        zxingSettings.setInverseScanning(false);
        return zxingSettings;
    }

    /**
     * Builds {@link BarDecoderRecognizerSettings} which define settings for scanning 1D barcodes
     * with algorithms implemented by Microblink team. Enabled barcodes are: code 128 and code 39.
     */
    private BarDecoderRecognizerSettings buildBardecoderRecognizerSettings() {
        // BarDecoderRecognizerSettings define settings for scanning 1D barcodes with algorithms
        // implemented by Microblink team.
        BarDecoderRecognizerSettings oneDimensionalRecognizerSettings = new BarDecoderRecognizerSettings();

        oneDimensionalRecognizerSettings.setScanCode128(true);
        oneDimensionalRecognizerSettings.setScanCode39(true);
        // By setting this to true, you will enable scanning of barcodes with inverse
        // intensity values (i.e. white barcodes on dark background). This option can
        // significantly increase recognition time. Default is false
        oneDimensionalRecognizerSettings.setInverseScanning(false);
        return oneDimensionalRecognizerSettings;
    }


    /**
     * Builds {@link EUDLRecognizerSettings} which define settings for scanning
     * EUDL (EU Driver's License). Enabled driver licenses are all supported EU licenses.
     */
    private EUDLRecognizerSettings buildEUDLRecognizerSettings() {
        // To specify we want to perform EUDL (EU Driver's License) recognition,
        // prepare settings for EUDL recognizer. Pass country as parameter to EUDLRecognizerSettings
        // constructor. Here we choose auto detection (one of supported licenses).
        return new EUDLRecognizerSettings(EUDLCountry.EUDL_COUNTRY_AUTO);
    }

    /**
     * Builds {@link Pdf417RecognizerSettings} which define settings for scanning plain PDF417
     * barcodes.
     */
    private Pdf417RecognizerSettings buildPdf417RecognizerSettings() {
        // Pdf417RecognizerSettings define the settings for scanning plain PDF417 barcodes.
        Pdf417RecognizerSettings pdf417RecognizerSettings = new Pdf417RecognizerSettings();
        // Set this to true to scan barcodes which don't have quiet zone (white area) around it
        // Use only if necessary because it drastically slows down the recognition process
        pdf417RecognizerSettings.setNullQuietZoneAllowed(true);
        // Set this to true to scan even barcode not compliant with standards
        // For example, malformed PDF417 barcodes which were incorrectly encoded
        // Use only if necessary because it slows down the recognition process
        pdf417RecognizerSettings.setUncertainScanning(false);
        return pdf417RecognizerSettings;
    }

    private boolean addRecognizer(RecognizerSettings recognizerSettings, @Nullable String fullDocumentImageName) {
        for (Iterator<RecognizerSettings> it = mRecognizers.iterator(); it.hasNext(); ) {
            RecognizerSettings curRec = it.next();
            if (recognizerSettings.getClass().equals(curRec.getClass())) {
                it.remove();
                // check for EUDL, same recognizer cannot be included multiple times. If adding
                // EUDL recognizers for more than one country, use one EUDL recognizer that will
                // detect country (EUDL_COUNTRY_AUTO)
                if (recognizerSettings instanceof EUDLRecognizerSettings &&
                        ((EUDLRecognizerSettings) curRec).getCountry() != ((EUDLRecognizerSettings) recognizerSettings).getCountry() ) {
                    recognizerSettings = buildEUDLRecognizerSettings();
                }
                break;
            }
        }
        if (mCameraHasAutofocus || !recognizerSettings.requiresAutofocus()) {
            mRecognizers.add(recognizerSettings);
            if (fullDocumentImageName != null) {
                mAcceptedImageNames.add(fullDocumentImageName);
            }
            return true;
        }
        return false;
    }

    private boolean addRecognizer(RecognizerSettings recognizerSettings) {
        return addRecognizer(recognizerSettings, null);
    }

    private boolean addParser(String identifier, OcrParserSettings parserSettings, boolean required) {
        parserSettings.setRequired(required);
        mParsers.put(identifier, parserSettings);
        return true;
    }

    RecognizerSettings[] createRecognizerSettingsArray() {
        ArrayList<RecognizerSettings> settingsList = new ArrayList<>(mRecognizers);
        if (!mParsers.isEmpty()) {
            BlinkOCRRecognizerSettings ocrRec = new BlinkOCRRecognizerSettings();
            for (String identifier : mParsers.keySet()) {
                ocrRec.addParser(identifier, mParsers.get(identifier));
            }
            settingsList.add(ocrRec);
        }
        RecognizerSettings[] settingsArray = new RecognizerSettings[settingsList.size()];
        settingsArray = settingsList.toArray(settingsArray);
        return settingsArray;
    }

    String[] getParserIdentifiers() {
        String[] identifiers = new String[mParsers.size()];
        int i = 0;
        for (String identifier : mParsers.keySet()) {
            identifiers[i++] = identifier;
        }
        return identifiers;
    }

    String[] getAcceptedImageNames() {
        String[] imageNamesArr = new String[mAcceptedImageNames.size()];
        imageNamesArr = mAcceptedImageNames.toArray(imageNamesArr);
        return imageNamesArr;
    }

    DeviceCameraType getCameraType() {
        return mCameraType;
    }

    public enum DeviceCameraType {
        CAMERA_DEFAULT,
        CAMERA_BACKFACE,
        CAMERA_FRONTFACE
    }

}
