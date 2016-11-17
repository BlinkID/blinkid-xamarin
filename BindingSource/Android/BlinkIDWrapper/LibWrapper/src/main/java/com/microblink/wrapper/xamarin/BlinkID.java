package com.microblink.wrapper.xamarin;

import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Parcelable;

import com.microblink.hardware.camera.CameraType;
import com.microblink.recognizers.BaseRecognitionResult;
import com.microblink.recognizers.IResultHolder;
import com.microblink.recognizers.RecognitionResults;
import com.microblink.recognizers.blinkbarcode.BarcodeType;
import com.microblink.recognizers.blinkbarcode.bardecoder.BarDecoderScanResult;
import com.microblink.recognizers.blinkbarcode.pdf417.Pdf417ScanResult;
import com.microblink.recognizers.blinkbarcode.usdl.USDLScanResult;
import com.microblink.recognizers.blinkbarcode.zxing.ZXingScanResult;
import com.microblink.recognizers.blinkid.austria.back.AustrianIDBackSideRecognitionResult;
import com.microblink.recognizers.blinkid.austria.front.AustrianIDFrontSideRecognitionResult;
import com.microblink.recognizers.blinkid.croatia.back.CroatianIDBackSideRecognitionResult;
import com.microblink.recognizers.blinkid.croatia.front.CroatianIDFrontSideRecognitionResult;
import com.microblink.recognizers.blinkid.czechia.back.CzechIDBackSideRecognitionResult;
import com.microblink.recognizers.blinkid.czechia.front.CzechIDFrontSideRecognitionResult;
import com.microblink.recognizers.blinkid.eudl.EUDLRecognitionResult;
import com.microblink.recognizers.blinkid.germany.front.GermanIDFrontSideRecognitionResult;
import com.microblink.recognizers.blinkid.germany.mrz.GermanIDMRZSideRecognitionResult;
import com.microblink.recognizers.blinkid.malaysia.IKadRecognitionResult;
import com.microblink.recognizers.blinkid.malaysia.MyKadRecognitionResult;
import com.microblink.recognizers.blinkid.mrtd.MRTDRecognitionResult;
import com.microblink.recognizers.blinkid.serbia.back.SerbianIDBackSideRecognitionResult;
import com.microblink.recognizers.blinkid.serbia.front.SerbianIDFrontSideRecognitionResult;
import com.microblink.recognizers.blinkid.singapore.SingaporeIDRecognitionResult;
import com.microblink.recognizers.blinkid.slovakia.back.SlovakIDBackSideRecognitionResult;
import com.microblink.recognizers.blinkid.slovakia.front.SlovakIDFrontSideRecognitionResult;
import com.microblink.recognizers.blinkid.slovenia.back.SlovenianIDBackSideRecognitionResult;
import com.microblink.recognizers.blinkid.slovenia.front.SlovenianIDFrontSideRecognitionResult;
import com.microblink.recognizers.blinkocr.BlinkOCRRecognitionResult;
import com.microblink.recognizers.detector.DetectorRecognitionResult;
import com.microblink.recognizers.settings.RecognitionSettings;
import com.microblink.recognizers.settings.RecognizerSettings;
import com.microblink.recognizers.settings.RecognizerSettingsUtils;
import com.microblink.results.barcode.BarcodeDetailedData;
import com.microblink.util.Log;
import com.microblink.util.RecognizerCompatibility;
import com.microblink.util.RecognizerCompatibilityStatus;
import com.microblink.wrapper.xamarin.scan.BlinkIDScanActivity;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Created by ivan on 2/29/16.
 */
public class BlinkID {

    private static final String PAYMENT_DATA_KEY = "PaymentDataType";

    // result types
    public static final String PDF417_RESULT_TYPE = "PDF417";
    public static final String USDL_RESULT_TYPE = "USDL";
    public static final String BARDECODER_RESULT_TYPE = "Barcode";
    public static final String ZXING_RESULT_TYPE = BARDECODER_RESULT_TYPE;
    public static final String MRTD_RESULT_TYPE = "MRTD";
    public static final String EUDL_RESULT_TYPE = "EUDL";
    public static final String MYKAD_RESULT_TYPE = "MyKad";
    public static final String IKAD_RESULT_TYPE = "iKad";
    public static final String AUT_ID_FRONT_RESULT_TYPE = "AustrianIdFront";
    public static final String AUT_ID_BACK_RESULT_TYPE = "AustrianIdBack";
    public static final String CRO_ID_FRONT_RESULT_TYPE = "CroatianIdFront";
    public static final String CRO_ID_BACK_RESULT_TYPE = "CroatianIdBack";
    public static final String CZ_ID_FRONT_RESULT_TYPE = "CzechIdFront";
    public static final String CZ_ID_BACK_RESULT_TYPE = "CzechIdBack";
    public static final String DE_ID_FRONT_RESULT_TYPE = "GermanIdFront";
    public static final String DE_ID_MRZ_SIDE_RESULT_TYPE = "GermanIdMrzSide";
    public static final String SRB_ID_FRONT_RESULT_TYPE = "SerbianIdFront";
    public static final String SRB_ID_BACK_RESULT_TYPE = "SerbianIdBack";
    public static final String SVK_ID_FRONT_RESULT_TYPE = "SlovakIdFront";
    public static final String SVK_ID_BACK_RESULT_TYPE = "SlovakIdBack";
    public static final String SVN_ID_FRONT_RESULT_TYPE = "SlovenianIdFront";
    public static final String SVN_ID_BACK_RESULT_TYPE = "SlovenianIdBack";
    public static final String SINGAPORE_ID_FRONT_RESULT_TYPE = "SingaporeIdFront";
    public static final String SINGAPORE_ID_BACK_RESULT_TYPE = "SingaporeIdBack";
    public static final String OCR_RESULT_TYPE = "OcrResult";
    public static final String ID_CARD_DETECTOR_RESULT_TYPE = "IdCardDetector";
    public static final String UNKNOWN_RESULT_TYPE = "Unknown";

    // result data keys
    public static final String RESULT_TYPE_KEY = "ResultType";
    public static final String BARCODE_TYPE_KEY = "Type";
    public static final String BARCODE_DATA_KEY = "Data";
    public static final String BARCODE_RAW_DATA_KEY = "Raw";
    public static final String EUDL_COUNTRY_KEY = "Country";

    public static final String LAST_NAME_KEY = "LastName";
    public static final String FIRST_NAME_KEY = "FirstName";
    public static final String FULL_NAME_KEY = "FullName";
    public static final String SEX_KEY = "Sex";
    public static final String CITIZENSHIP_KEY = "Citizenship";
    public static final String COUNTRY_OF_BIRTH_KEY = "CountryOfBirth";
    public static final String PLACE_OF_BIRTH_KEY = "PlaceOfBirth";
    public static final String DATE_OF_BIRTH_KEY= "DateOfBirth";
    public static final String DATE_OF_EXPIRY_KEY = "DateOfExpiry";
    public static final String DATE_OF_BIRTH_RAW_KEY= "RawDateOfBirth";
    public static final String DATE_OF_EXPIRY_RAW_KEY = "RawDateOfExpiry";
    public static final String DATE_OF_ISSUE_KEY = "DateOfIssue";
    public static final String PERSONAL_NUMBER_KEY = "PersonalNumber";
    public static final String DOCUMENT_NUMBER_KEY = "DocumentNumber";
    public static final String ADDRESS_KEY = "Address";
    public static final String ISSUING_AUTHORITY_KEY = "IssuingAuthority";
    public static final String AUTHORITY_KEY = "Authority";
    public static final String BLOOD_GROUP_KEY = "BloodGroup";
    public static final String RACE_KEY = "Race";
    public static final String EYE_COLOR_KEY = "EyeColor";
    public static final String HEIGHT_KEY = "Height";
    public static final String PRINCIPAL_RESIDENCE_AT_ISSUANCE_KEY = "PrincipalResidenceAtIssuance";
    public static final String SURNAME_AT_BIRTH_KEY = "SurnameAtBirth";
    public static final String SPECIAL_REMARKS_KEY = "SpecialRemarks";
    public static final String EMPLOYER_KEY = "Employer";
    public static final String PASSPORT_NUMBER_KEY = "PassportNumber";
    public static final String SECTOR_KEY = "Sector";

    public static final String PRIMARY_ID_KEY = "PrimaryID";
    public static final String SECONDARY_ID_KEY = "SecondaryID";
    public static final String NATIONALITY_KEY = "Nationality";
    public static final String DOCUMENT_CODE_KEY = "DocumentCode";
    public static final String ISSUER_KEY = "Issuer";
    public static final String OPT1_KEY = "Opt1";
    public static final String OPT2_KEY = "Opt2";
    public static final String MRZ_RAW_KEY = "MrzText";

    private static final String LOG_TAG = "BlinkId";

    /** Date format for date results */
    DateFormat mDateFormat = new SimpleDateFormat("dd/MM/yyyy");

    private Context mContext;
    private String mLicenseKey;
    private BlinkIdResultListener mResultListener;
    private String[] mParserIdentifiers;

    private static BlinkID ourInstance = new BlinkID();

    public static BlinkID getInstance() {
        return ourInstance;
    }

    /**
     * Checks whether the BlinkID is supported on the device.
     * @param context The application context.
     * @return Returns {@code true} if BlinkID is supported on the device, {@code false} otherwise.
     */
    public boolean isBlinkIDSupportedOnDevice(Context context) {
        RecognizerCompatibilityStatus status = RecognizerCompatibility.getRecognizerCompatibilityStatus(context);
        return status == RecognizerCompatibilityStatus.RECOGNIZER_SUPPORTED;
    }

    /**
     * Defines the license key for native library that is bound to application package name.
     *
     * @param licenseKey License key for the application package name.
     */
    public void setLicenseKey(String licenseKey) {
        mLicenseKey = licenseKey;
    }

    /**
     * Defines the application context that is used by scan activity.
     *
     * @param context The application context.
     */
    public void setContext(Context context) {
        mContext = context;
    }

    /**
     * Defines the scan results listener that will obtain results when recognition is done.
     *
     * @param resultListener Scan results listener.
     */
    public void setResultListener(BlinkIdResultListener resultListener) {
        mResultListener = resultListener;
    }

    /**
     * Starts the scan activity. Before scanning, license key, context and result listener
     * have to be defined with setter methods: {@link #setLicenseKey(String)},
     * {@link #setContext(Context)}, {@link #setResultListener(BlinkIdResultListener)}.
     *
     * @param scanSettings Scan settings which define recognizers that will be used to scan
     *                     corresponding document types and camera type that will be used.
     *
     * @throws IllegalStateException If license key, context or result listener is not defined.
     * @throws IllegalScanSettingsException If scanSettings are not valid, scan settings are valid
     *                                      if at least one recognizer or parser or detector is active.
     */
    public void scan(BlinkIdScanSettings scanSettings) throws IllegalScanSettingsException {
        if (mLicenseKey == null || mContext == null || mResultListener == null) {
            throw new IllegalStateException("Before scanning, license key, context and result listener" +
                    " have to be defined.");
        }
        BlinkIdScanSettings.DeviceCameraType cam = scanSettings.getCameraType();
        CameraType cameraType = CameraType.CAMERA_DEFAULT;
        if (cam == BlinkIdScanSettings.DeviceCameraType.CAMERA_FRONTFACE) {
            cameraType = CameraType.CAMERA_FRONTFACE;
        } else if (cam == BlinkIdScanSettings.DeviceCameraType.CAMERA_BACKFACE) {
            cameraType = CameraType.CAMERA_BACKFACE;
        }
        RecognitionSettings recognitionSettings = buildRecognitionSettings(scanSettings, cameraType);
        if (recognitionSettings.getRecognizerSettingsArray().length == 0) {
            throw new IllegalScanSettingsException("At least one recognizer/parser/detector must be active.");
        }
        mParserIdentifiers = scanSettings.getParserIdentifiers();

        Intent scanIntent = buildScanIntent(recognitionSettings, scanSettings.getAcceptedImageNames(), cameraType);
        Log.i(this, "Starting scan intent");
        mContext.startActivity(scanIntent);
    }

    /**
     * This method builds scan intent for BlinkID.
     */
    private Intent buildScanIntent(RecognitionSettings settings, String[] acceptedImageNames, CameraType cameraType) {

        // first create intent for provided ScanCard activity
        final Intent intent = new Intent(mContext, BlinkIDScanActivity.class);
        intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

        // In order for scanning to work, you must enter a valid licence key. Without licence key,
        // scanning will not work. Licence key is bound the the package name of your app, so when
        // obtaining your licence key from Microblink make sure you give us the correct package name
        // of your app. You can obtain your licence key at http://microblink.com/login or contact us
        // at http://help.microblink.com.
        // Licence key also defines which recognizers are enabled and which are not. Since the licence
        // key validation is performed on image processing thread in native code, all enabled recognizers
        // that are disallowed by licence key will be turned off without any error and information
        // about turning them off will be logged to ADB logcat.
        intent.putExtra(BlinkIDScanActivity.EXTRAS_LICENSE_KEY, mLicenseKey);

        intent.putExtra(BlinkIDScanActivity.EXTRAS_CAMERA_TYPE, (Parcelable) cameraType);
        intent.putExtra(BlinkIDScanActivity.EXTRAS_ACCEPTED_IMAGE_NAMES_ARRAY, acceptedImageNames);
        intent.putExtra(BlinkIDScanActivity.EXTRAS_RECOGNITION_SETTINGS, settings);

        return intent;
    }

    /**
     * This method creates the recognition settings for scan activity.
     *
     * @param scanSettings Scan settings which define recognizers that will be used to scan
     *                     corresponding document types.
     *
     * @param cameraType Camera type that will be used.
     * @return Recognition settings for scan activity.
     */
    protected RecognitionSettings buildRecognitionSettings(BlinkIdScanSettings scanSettings, CameraType cameraType) {
        // initialize scanning settings object
        RecognitionSettings recognitionSettings = new RecognitionSettings();

        // with setNumMsBeforeTimeout you can define number of miliseconds that must pass
        // after first partial scan result has arrived before scan activity triggers a timeout.
        // Timeout is good for preventing infinitely long scanning experience when user attempts
        // to scan damaged or unsupported slip. After timeout, scan activity will return only
        // data that was read successfully. This might be incomplete data.
        recognitionSettings.setNumMsBeforeTimeout(2000);

        // If you add more recognizers to recognizer settings array, you can choose whether you
        // want to have the ability to obtain multiple scan results from same video frame. For example,
        // if both payment slip and payment barcode are visible on a single frame, by setting
        // setAllowMultipleScanResultsOnSingleImage to true you can obtain both scan results
        // from barcode and slip. If this is false (default), you will get the first valid result
        // (i.e. first result that contains all required data). Having this option turned off
        // creates better and faster user experience.
        recognitionSettings.setAllowMultipleScanResultsOnSingleImage(
                scanSettings.shouldAllowMultipleScanResultsOnSingleImage());

        RecognizerSettings[] settingsArray = scanSettings.createRecognizerSettingsArray();
        if (!RecognizerCompatibility.cameraHasAutofocus(cameraType, mContext)) {
            settingsArray = RecognizerSettingsUtils.filterOutRecognizersThatRequireAutofocus(settingsArray);
        }

        // Add array with recognizer settings so that scan activity will know
        // what do you want to scan. Setting recognizer settings array is mandatory.
        recognitionSettings.setRecognizerSettingsArray(settingsArray);
        return recognitionSettings;
    }

    /**
     * This method is called by scan activity when recognition is done.
     *
     * @param results Recognition results.
     */
    public void onScanningDone(RecognitionResults results, Bitmap documentImage) {
        BaseRecognitionResult[] resultsArr = results.getRecognitionResults();
        if (resultsArr != null && resultsArr.length > 0) {
            List<Map<String, String>> resultList = new ArrayList<>();
            boolean shouldReturnImage = false;
            for (BaseRecognitionResult result : resultsArr) {
                if (result instanceof AustrianIDFrontSideRecognitionResult) {
                    resultList.add(buildAustrianIdFrontResult((AustrianIDFrontSideRecognitionResult) result));
                    shouldReturnImage = true;
                } else if (result instanceof AustrianIDBackSideRecognitionResult) {
                    resultList.add(buildAustrianIdBackResult((AustrianIDBackSideRecognitionResult) result));
                    shouldReturnImage = true;
                } else if (result instanceof CzechIDFrontSideRecognitionResult) {
                    resultList.add(buildCzIdFrontResult((CzechIDFrontSideRecognitionResult) result));
                    shouldReturnImage = true;
                } else if (result instanceof CzechIDBackSideRecognitionResult) {
                    resultList.add(buildCzIdBackResult((CzechIDBackSideRecognitionResult) result));
                    shouldReturnImage = true;
                } else if (result instanceof CroatianIDFrontSideRecognitionResult) {
                    resultList.add(buildCroIdFrontResult((CroatianIDFrontSideRecognitionResult) result));
                    shouldReturnImage = true;
                } else if (result instanceof CroatianIDBackSideRecognitionResult) {
                    resultList.add(buildCroIdBackResult((CroatianIDBackSideRecognitionResult) result));
                    shouldReturnImage = true;
                } else if (result instanceof GermanIDMRZSideRecognitionResult) {
                    resultList.add(buildGermanIdMRZSideResult((GermanIDMRZSideRecognitionResult) result));
                    shouldReturnImage = true;
                } else if (result instanceof GermanIDFrontSideRecognitionResult) {
                    resultList.add(buildGermanIdFrontResult((GermanIDFrontSideRecognitionResult) result));
                    shouldReturnImage = true;
                } else if (result instanceof SerbianIDBackSideRecognitionResult) {
                    resultList.add(buildSerbianIdBackResult((SerbianIDBackSideRecognitionResult) result));
                    shouldReturnImage = true;
                } else if (result instanceof SerbianIDFrontSideRecognitionResult) {
                    resultList.add(buildSerbianIdFrontResult((SerbianIDFrontSideRecognitionResult) result));
                    shouldReturnImage = true;
                } else if (result instanceof SlovakIDBackSideRecognitionResult) {
                    resultList.add(buildSlovakIdBackResult((SlovakIDBackSideRecognitionResult) result));
                    shouldReturnImage = true;
                } else if (result instanceof SlovakIDFrontSideRecognitionResult) {
                    resultList.add(buildSlovakIdFrontResult((SlovakIDFrontSideRecognitionResult) result));
                    shouldReturnImage = true;
                } else if (result instanceof SlovenianIDBackSideRecognitionResult) {
                    resultList.add(buildSlovenianIdBackResult((SlovenianIDBackSideRecognitionResult) result));
                    shouldReturnImage = true;
                } else if (result instanceof SlovenianIDFrontSideRecognitionResult) {
                    resultList.add(buildSlovenianIdFrontResult((SlovenianIDFrontSideRecognitionResult) result));
                    shouldReturnImage = true;
                } else if (result instanceof SingaporeIDRecognitionResult) {
                    resultList.add(buildSingaporeIdResult((SingaporeIDRecognitionResult) result));
                    shouldReturnImage = true;
                } else if (result instanceof USDLScanResult) {
                    resultList.add(buildUSDLResult((USDLScanResult) result));
                } else if (result instanceof EUDLRecognitionResult) {
                    resultList.add(buildEUDLResult((EUDLRecognitionResult) result));
                    shouldReturnImage = true;
                } else if (result instanceof MyKadRecognitionResult) {
                    resultList.add(buildMyKadResult((MyKadRecognitionResult) result));
                    shouldReturnImage = true;
                } else if (result instanceof IKadRecognitionResult) {
                    resultList.add(buildIKadResult((IKadRecognitionResult) result));
                    shouldReturnImage = true;
                } else if (result instanceof Pdf417ScanResult) {
                    resultList.add(buildPdf417Result((Pdf417ScanResult) result));
                } else if (result instanceof BarDecoderScanResult) {
                    resultList.add(buildBarDecoderResult((BarDecoderScanResult) result));
                } else if (result instanceof ZXingScanResult) {
                    resultList.add(buildZxingResult((ZXingScanResult) result));
                } else if (result instanceof BlinkOCRRecognitionResult) {
                    resultList.add(buildOcrResult((BlinkOCRRecognitionResult) result));
                } else if (result instanceof MRTDRecognitionResult) {
                    resultList.add(buildMRTDResult((MRTDRecognitionResult) result));
                    shouldReturnImage = true;
                } else if (result instanceof DetectorRecognitionResult) {
                    resultList.add(buildIdCardDetectorResult((DetectorRecognitionResult) result));
                    shouldReturnImage = true;
                } else {
                    throw new RuntimeException("Unknown result type: "
                            + result.getClass().toString() + " in result array.");
                }
            }
            if (documentImage != null && shouldReturnImage) {
                mResultListener.onDocumentImageAvailable(documentImage);
            }
            mResultListener.onResultsAvailable(resultList);
        } else {
            mResultListener.onResultsAvailable(null);
        }

    }

    /**
     * Builds result map for Pdf417 scan result.
     */
    private Map<String, String> buildPdf417Result(Pdf417ScanResult res) {
        // getStringData getter will return the string version of barcode contents
        String barcodeData = res.getStringData();
        // getRawData getter will return the raw data information object of barcode contents
        BarcodeDetailedData rawData = res.getRawData();

        Map<String, String> resultMap = new HashMap<>();
        resultMap.put(RESULT_TYPE_KEY, PDF417_RESULT_TYPE);
        resultMap.put(BARCODE_TYPE_KEY, "PDF417");
        resultMap.put(BARCODE_DATA_KEY, barcodeData);

        // BarcodeDetailedData contains information about barcode's binary layout, if you
        // are only interested in raw bytes, you can obtain them with getAllData getter
        if (rawData != null) {
            byte[] rawDataBuffer = rawData.getAllData();
            resultMap.put(BARCODE_RAW_DATA_KEY, byteArrayToHex(rawDataBuffer));
        }

        return resultMap;
    }

    /**
     * Builds result map for BarDecoder scan result.
     */
    private Map<String, String> buildBarDecoderResult(BarDecoderScanResult res) {
        // with getBarcodeType you can obtain barcode type enum that tells you the type of decoded barcode
        BarcodeType type = res.getBarcodeType();
        // as with PDF417, getStringData will return the string contents of barcode
        String barcodeData = res.getStringData();

        Map<String, String> resultMap = new HashMap<>();
        resultMap.put(RESULT_TYPE_KEY, BARDECODER_RESULT_TYPE);
        String typeName = type != null ? type.name() : UNKNOWN_RESULT_TYPE;
        resultMap.put(BARCODE_TYPE_KEY, typeName);
        resultMap.put(BARCODE_DATA_KEY, barcodeData);
        return resultMap;
    }

    /**
     * Builds result map for Zxing scan result.
     */
    private Map<String, String> buildZxingResult(ZXingScanResult res) {
        // with getBarcodeType you can obtain barcode type enum that tells you the type of decoded barcode
        BarcodeType type = res.getBarcodeType();

        // as with PDF417, getStringData will return the string contents of barcode
        String barcodeData = res.getStringData();

        Map<String, String> resultMap = new HashMap<>();
        resultMap.put(RESULT_TYPE_KEY, ZXING_RESULT_TYPE);
        String typeName = type != null ? type.name() : UNKNOWN_RESULT_TYPE;
        resultMap.put(BARCODE_TYPE_KEY, typeName);
        resultMap.put(BARCODE_DATA_KEY, barcodeData);
        return resultMap;
    }

    /**
     * Builds result map for USDL scan result.
     */
    private Map<String, String> buildUSDLResult(USDLScanResult res) {
        return buildKeyValueResult(res, USDL_RESULT_TYPE);
    }

    /**
     * Builds result map for MyKad scan result.
     */
    private Map<String, String> buildMyKadResult(MyKadRecognitionResult res) {
        return buildKeyValueResult(res, MYKAD_RESULT_TYPE);
    }

    /**
     * Builds result map for Malaysian iKad scan result.
     */
    private Map<String, String> buildIKadResult(IKadRecognitionResult result) {
        Map<String, String> resultMap = new HashMap<>();
        resultMap.put(RESULT_TYPE_KEY, IKAD_RESULT_TYPE);

        resultMap.put(FULL_NAME_KEY, result.getFullName());
        resultMap.put(ADDRESS_KEY, result.getAddress());
        Date dateOfBirth = result.getDateOfBirth();
        if (dateOfBirth != null) {
            resultMap.put(DATE_OF_BIRTH_KEY, mDateFormat.format(dateOfBirth));
        }
        resultMap.put(EMPLOYER_KEY, result.getEmployer());
        Date dateOfExpiry = result.getExpiryDate();
        if (dateOfExpiry != null) {
            resultMap.put(DATE_OF_EXPIRY_KEY, mDateFormat.format(dateOfExpiry));
        }
        resultMap.put(NATIONALITY_KEY, result.getNationality());
        resultMap.put(PASSPORT_NUMBER_KEY, result.getPassportNumber());
        resultMap.put(SECTOR_KEY, result.getSector());
        resultMap.put(SEX_KEY, result.getSex());

        return resultMap;
    }

    /**
     * Builds result map for EUDL scan result.
     */
    private Map<String, String> buildEUDLResult(EUDLRecognitionResult res) {
        Map<String, String> resultMap = buildKeyValueResult(res, EUDL_RESULT_TYPE);
        resultMap.put(EUDL_COUNTRY_KEY, res.getCountry().name());
        return resultMap;
    }

    /**
     * Builds result map for MRTD scan result.
     */
    private Map<String, String> buildMRTDResult(MRTDRecognitionResult res) {
        Map<String, String> resultMap = new HashMap<>();
        resultMap.put(RESULT_TYPE_KEY, MRTD_RESULT_TYPE);
        resultMap.put(PRIMARY_ID_KEY, res.getPrimaryId());
        resultMap.put(SECONDARY_ID_KEY, res.getSecondaryId());
        resultMap.put(DATE_OF_BIRTH_KEY, mDateFormat.format(res.getDateOfBirth()));
        resultMap.put(DATE_OF_BIRTH_RAW_KEY, res.getRawDateOfBirth());
        resultMap.put(SEX_KEY, res.getSex());
        resultMap.put(NATIONALITY_KEY, res.getNationality());
        resultMap.put(DOCUMENT_CODE_KEY, res.getDocumentCode());
        resultMap.put(ISSUER_KEY, res.getIssuer());
        resultMap.put(DATE_OF_EXPIRY_KEY, mDateFormat.format(res.getDateOfExpiry()));
        resultMap.put(DATE_OF_EXPIRY_RAW_KEY, res.getRawDateOfExpiry());
        resultMap.put(OPT2_KEY, res.getOpt2());
        resultMap.put(OPT1_KEY, res.getOpt1());
        resultMap.put(DOCUMENT_NUMBER_KEY, res.getDocumentNumber());
        resultMap.put(MRZ_RAW_KEY, res.getMRZText());

        return resultMap;
    }

    private Map<String, String> buildCzIdBackResult(CzechIDBackSideRecognitionResult result) {
        Map<String, String> resultMap = buildMRTDResult(result);
        resultMap.put(RESULT_TYPE_KEY, CZ_ID_BACK_RESULT_TYPE);

        resultMap.put(ADDRESS_KEY, result.getAddress());
        resultMap.put(ISSUING_AUTHORITY_KEY, result.getAuthority());
        resultMap.put(PERSONAL_NUMBER_KEY, result.getPersonalNumber());

        return resultMap;
    }

    private Map<String, String> buildCzIdFrontResult(CzechIDFrontSideRecognitionResult result) {
        Map<String, String> resultMap = new HashMap<>();
        resultMap.put(RESULT_TYPE_KEY, CZ_ID_FRONT_RESULT_TYPE);

        resultMap.put(FIRST_NAME_KEY, result.getFirstName());
        resultMap.put(LAST_NAME_KEY, result.getLastName());
        resultMap.put(DOCUMENT_NUMBER_KEY, result.getIdentityCardNumber());
        resultMap.put(SEX_KEY, result.getSex());
        resultMap.put(PLACE_OF_BIRTH_KEY, result.getPlaceOfBirth());

        Date dateOfBirth = result.getDateOfBirth();
        if (dateOfBirth != null) {
            resultMap.put(DATE_OF_BIRTH_KEY, mDateFormat.format(dateOfBirth));
        }
        Date dateOfIssue = result.getDateOfIssue();
        if (dateOfIssue != null) {
            resultMap.put(DATE_OF_ISSUE_KEY, mDateFormat.format(dateOfIssue));

        }
        Date dateOfExpiry = result.getDateOfExpiry();
        if (dateOfExpiry != null) {
            resultMap.put(DATE_OF_EXPIRY_KEY, mDateFormat.format(dateOfExpiry));

        }

        return resultMap;
    }

    private Map<String, String> buildAustrianIdBackResult(AustrianIDBackSideRecognitionResult result) {
        Map<String, String> resultMap = buildMRTDResult(result);
        resultMap.put(RESULT_TYPE_KEY, AUT_ID_BACK_RESULT_TYPE);

        resultMap.put(PLACE_OF_BIRTH_KEY, result.getPlaceOfBirth());
        resultMap.put(EYE_COLOR_KEY, result.getEyeColour());
        resultMap.put(ISSUING_AUTHORITY_KEY, result.getIssuingAuthority());
        resultMap.put(PRINCIPAL_RESIDENCE_AT_ISSUANCE_KEY, result.getPrincipalResidenceAtIssuance());
        resultMap.put(HEIGHT_KEY, Integer.toString(result.getHeight()));

        Date dateOfIssue = result.getDateOfIssuance();
        if (dateOfIssue != null) {
            resultMap.put(DATE_OF_ISSUE_KEY, mDateFormat.format(dateOfIssue));

        }

        return resultMap;
    }

    private Map<String, String> buildAustrianIdFrontResult(AustrianIDFrontSideRecognitionResult result) {
        Map<String, String> resultMap = new HashMap<>();

        resultMap.put(RESULT_TYPE_KEY, AUT_ID_FRONT_RESULT_TYPE);

        resultMap.put(FIRST_NAME_KEY, result.getFirstName());
        resultMap.put(LAST_NAME_KEY, result.getLastName());
        resultMap.put(DOCUMENT_NUMBER_KEY, result.getIdentityCardNumber());
        resultMap.put(SEX_KEY, result.getSex());

        Date dateOfBirth = result.getDateOfBirth();
        if (dateOfBirth != null) {
            resultMap.put(DATE_OF_BIRTH_KEY, mDateFormat.format(dateOfBirth));
        }

        return resultMap;
    }

    private Map<String,String> buildCroIdFrontResult(CroatianIDFrontSideRecognitionResult result) {
        Map<String, String> resultMap = new HashMap<>();
        resultMap.put(RESULT_TYPE_KEY, CRO_ID_FRONT_RESULT_TYPE);

        resultMap.put(FIRST_NAME_KEY, result.getFirstName());
        resultMap.put(LAST_NAME_KEY, result.getLastName());
        resultMap.put(DOCUMENT_NUMBER_KEY, result.getIdentityCardNumber());
        resultMap.put(SEX_KEY, result.getSex());
        resultMap.put(CITIZENSHIP_KEY, result.getCitizenship());
        Date dateOfBirth = result.getDateOfBirth();
        if (dateOfBirth != null) {
            resultMap.put(DATE_OF_BIRTH_KEY, mDateFormat.format(dateOfBirth));
        }
        Date dateOfExpiry = result.getDocumentDateOfExpiry();
        if (dateOfExpiry != null) {
            resultMap.put(DATE_OF_EXPIRY_KEY, mDateFormat.format(dateOfExpiry));

        }

        return resultMap;
    }

    private Map<String,String> buildCroIdBackResult(CroatianIDBackSideRecognitionResult result) {
        Map<String, String> resultMap = buildMRTDResult(result);
        resultMap.put(RESULT_TYPE_KEY, CRO_ID_BACK_RESULT_TYPE);
        resultMap.put(ADDRESS_KEY, result.getAddress());
        resultMap.put(ISSUING_AUTHORITY_KEY, result.getIssuingAuthority());
        Date dateOfIssue = result.getDocumentDateOfIssue();
        if (dateOfIssue != null) {
            resultMap.put(DATE_OF_ISSUE_KEY, mDateFormat.format(dateOfIssue));

        }

        return resultMap;
    }

    private Map<String, String> buildGermanIdFrontResult(GermanIDFrontSideRecognitionResult result) {
        Map<String, String> resultMap = new HashMap<>();
        resultMap.put(RESULT_TYPE_KEY, DE_ID_FRONT_RESULT_TYPE);

        resultMap.put(FIRST_NAME_KEY, result.getFirstName());
        resultMap.put(LAST_NAME_KEY, result.getLastName());
        resultMap.put(NATIONALITY_KEY, result.getNationality());
        resultMap.put(PLACE_OF_BIRTH_KEY, result.getPlaceOfBirth());
        Date dateOfBirth = result.getDateOfBirth();
        if (dateOfBirth != null) {
            resultMap.put(DATE_OF_BIRTH_KEY, mDateFormat.format(dateOfBirth));
        }
        resultMap.put(DOCUMENT_NUMBER_KEY, result.getIdentityCardNumber());
        Date dateOfExpiry = result.getDateOfExpiry();
        if (dateOfExpiry != null) {
            resultMap.put(DATE_OF_EXPIRY_KEY, mDateFormat.format(dateOfExpiry));

        }

        return resultMap;
    }

    private Map<String,String> buildGermanIdMRZSideResult(GermanIDMRZSideRecognitionResult result) {
        Map<String, String> resultMap = buildMRTDResult(result);
        resultMap.put(RESULT_TYPE_KEY, DE_ID_MRZ_SIDE_RESULT_TYPE);

        String address = result.getAddress();
        if (address != null && !address.isEmpty()) {
            resultMap.put(ADDRESS_KEY, address);
        }

        String authority = result.getAuthority();
        if (authority != null && !authority.isEmpty()) {
            resultMap.put(AUTHORITY_KEY, authority);
        }

        Date dateOfIssue = result.getDateOfIssue();
        if (dateOfIssue != null) {
            resultMap.put(DATE_OF_ISSUE_KEY, mDateFormat.format(dateOfIssue));
        }

        String eyeColor = result.getEyeColour();
        if (eyeColor != null && !eyeColor.isEmpty()) {
            resultMap.put(EYE_COLOR_KEY, eyeColor);
        }

        int height = result.getHeight();
        if (height != 0) {
            resultMap.put(HEIGHT_KEY, Integer.toString(height) + " cm");
        }

        return resultMap;
    }

    private Map<String, String> buildSerbianIdFrontResult(SerbianIDFrontSideRecognitionResult result) {
        Map<String, String> resultMap = new HashMap<>();
        resultMap.put(RESULT_TYPE_KEY, SRB_ID_FRONT_RESULT_TYPE);

        Date dateOfIssue = result.getIssuingDate();
        if (dateOfIssue != null) {
            resultMap.put(DATE_OF_ISSUE_KEY, mDateFormat.format(dateOfIssue));

        }
        Date dateOfExpiry = result.getValidUntil();
        if (dateOfExpiry != null) {
            resultMap.put(DATE_OF_EXPIRY_KEY, mDateFormat.format(dateOfExpiry));

        }
        resultMap.put(DOCUMENT_NUMBER_KEY, result.getDocumentNumber());

        return resultMap;
    }

    private Map<String,String> buildSerbianIdBackResult(SerbianIDBackSideRecognitionResult result) {
        Map<String, String> resultMap = buildMRTDResult(result);
        resultMap.put(RESULT_TYPE_KEY, SRB_ID_BACK_RESULT_TYPE);

        return resultMap;
    }

    private Map<String, String> buildSlovakIdFrontResult(SlovakIDFrontSideRecognitionResult result) {
        Map<String, String> resultMap = new HashMap<>();
        resultMap.put(RESULT_TYPE_KEY, SVK_ID_FRONT_RESULT_TYPE);

        resultMap.put(FIRST_NAME_KEY, result.getFirstName());
        resultMap.put(LAST_NAME_KEY, result.getLastName());
        resultMap.put(NATIONALITY_KEY, result.getNationality());
        resultMap.put(SEX_KEY, result.getSex());
        resultMap.put(DOCUMENT_NUMBER_KEY, result.getIdentityCardNumber());
        resultMap.put(ISSUING_AUTHORITY_KEY, result.getIssuingAuthority());
        Date dateOfBirth = result.getDateOfBirth();
        if (dateOfBirth != null) {
            resultMap.put(DATE_OF_BIRTH_KEY, mDateFormat.format(dateOfBirth));
        }
        resultMap.put(PERSONAL_NUMBER_KEY, result.getPersonalNumber());
        Date dateOfExpiry = result.getDateOfExpiry();
        if (dateOfExpiry != null) {
            resultMap.put(DATE_OF_EXPIRY_KEY, mDateFormat.format(dateOfExpiry));
        }
        Date dateOfIssue = result.getDateOfIssue();
        if (dateOfIssue != null) {
            resultMap.put(DATE_OF_ISSUE_KEY, mDateFormat.format(dateOfIssue));
        }

        return resultMap;
    }

    private Map<String,String> buildSlovakIdBackResult(SlovakIDBackSideRecognitionResult result) {
        Map<String, String> resultMap = buildMRTDResult(result);
        resultMap.put(RESULT_TYPE_KEY, SVK_ID_BACK_RESULT_TYPE);

        resultMap.put(ADDRESS_KEY, result.getAddress());
        resultMap.put(SURNAME_AT_BIRTH_KEY, result.getSurnameAtBirth());
        resultMap.put(PLACE_OF_BIRTH_KEY, result.getPlaceOfBirth());
        resultMap.put(SPECIAL_REMARKS_KEY, result.getSpecialRemarks());

        return resultMap;
    }

    private Map<String, String> buildSlovenianIdFrontResult(SlovenianIDFrontSideRecognitionResult result) {
        Map<String, String> resultMap = new HashMap<>();
        resultMap.put(RESULT_TYPE_KEY, SVN_ID_FRONT_RESULT_TYPE);

        resultMap.put(FIRST_NAME_KEY, result.getFirstName());
        resultMap.put(LAST_NAME_KEY, result.getLastName());
        resultMap.put(SEX_KEY, result.getSex());
        resultMap.put(NATIONALITY_KEY, result.getNationality());
        Date dateOfBirth = result.getDateOfBirth();
        if (dateOfBirth != null) {
            resultMap.put(DATE_OF_BIRTH_KEY, mDateFormat.format(dateOfBirth));

        }
        Date dateOfExpiry = result.getDateOfExpiry();
        if (dateOfExpiry != null) {
            resultMap.put(DATE_OF_EXPIRY_KEY, mDateFormat.format(dateOfExpiry));
        }

        return resultMap;
    }

    private Map<String,String> buildSlovenianIdBackResult(SlovenianIDBackSideRecognitionResult result) {
        Map<String, String> resultMap = buildMRTDResult(result);
        resultMap.put(RESULT_TYPE_KEY, SVN_ID_BACK_RESULT_TYPE);

        resultMap.put(ADDRESS_KEY, result.getAddress());
        resultMap.put(AUTHORITY_KEY, result.getAuthority());
        Date dateOfIssue = result.getDateOfIssue();
        if (dateOfIssue != null) {
            resultMap.put(DATE_OF_ISSUE_KEY, mDateFormat.format(dateOfIssue));
        }

        return resultMap;
    }

    private Map<String,String> buildSingaporeIdResult(SingaporeIDRecognitionResult result) {
        Map<String, String> resultMap = new HashMap<>();

        SingaporeIDRecognitionResult.SingaporeIDClassification classification =  result.getDocumentClassification();
        if (classification == SingaporeIDRecognitionResult.SingaporeIDClassification.BACK_SIDE) {
            resultMap.put(RESULT_TYPE_KEY, SINGAPORE_ID_BACK_RESULT_TYPE);

            resultMap.put(BLOOD_GROUP_KEY, result.getBloodGroup());
            Date dateOfIssue = result.getDocumentDateOfIssue();
            if (dateOfIssue != null) {
                resultMap.put(DATE_OF_ISSUE_KEY, mDateFormat.format(dateOfIssue));
            }
            resultMap.put(ADDRESS_KEY, result.getAddress());
        } else {
            resultMap.put(RESULT_TYPE_KEY, SINGAPORE_ID_FRONT_RESULT_TYPE);

            resultMap.put(DOCUMENT_NUMBER_KEY, result.getCardNumber());
            resultMap.put(FULL_NAME_KEY, result.getName());
            resultMap.put(RACE_KEY, result.getRace());
            Date dateOfBirth = result.getDateOfBirth();
            if (dateOfBirth != null) {
                resultMap.put(DATE_OF_BIRTH_KEY, mDateFormat.format(dateOfBirth));
            }
            resultMap.put(SEX_KEY, result.getSex());
            resultMap.put(COUNTRY_OF_BIRTH_KEY, result.getCountryOfBirth());
        }

        return resultMap;
    }

    private Map<String, String> buildOcrResult(BlinkOCRRecognitionResult result) {
        Map<String, String> resultMap = new HashMap<>();
        resultMap.put(RESULT_TYPE_KEY, OCR_RESULT_TYPE);

        for (String parserId: mParserIdentifiers) {
            String parserRes = result.getParsedResult(parserId);
            if (parserRes != null && !parserRes.isEmpty()) {
                resultMap.put(parserId, parserRes);
            }
        }

        return resultMap;
    }

    private Map<String,String> buildIdCardDetectorResult(DetectorRecognitionResult result) {
        Map<String, String> resultMap = new HashMap<>();
        resultMap.put(RESULT_TYPE_KEY, ID_CARD_DETECTOR_RESULT_TYPE);

        return resultMap;
    }


    private Map<String, String> buildKeyValueResult(BaseRecognitionResult res, String resultType) {
        Map<String, String> resultMap = new HashMap<>();
        IResultHolder resultHolder = res.getResultHolder();
        for (String key : resultHolder.keySet()) {
            if (key.equals(PAYMENT_DATA_KEY)) {
                continue;
            }
            Object value = resultHolder.getObject(key);
            if (value instanceof String) {
                resultMap.put(key, (String) value);
            } else {
                Log.d(LOG_TAG, "Ignoring non string key '" + key + "'");
            }
        }
        resultMap.put(RESULT_TYPE_KEY, resultType);
        return resultMap;
    }

    private String byteArrayToHex(byte[] data) {
        StringBuilder sb = new StringBuilder();
        for (byte b : data) {
            sb.append(String.format("%02x", b));
        }
        return sb.toString();
    }

}
