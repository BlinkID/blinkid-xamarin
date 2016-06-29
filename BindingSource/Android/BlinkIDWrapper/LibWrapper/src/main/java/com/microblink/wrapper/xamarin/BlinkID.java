package com.microblink.wrapper.xamarin;

import android.content.Context;
import android.content.Intent;

import com.microblink.hardware.camera.CameraType;
import com.microblink.recognizers.BaseRecognitionResult;
import com.microblink.recognizers.IResultHolder;
import com.microblink.recognizers.RecognitionResults;
import com.microblink.recognizers.blinkbarcode.BarcodeType;
import com.microblink.recognizers.blinkbarcode.bardecoder.BarDecoderRecognizerSettings;
import com.microblink.recognizers.blinkbarcode.bardecoder.BarDecoderScanResult;
import com.microblink.recognizers.blinkbarcode.pdf417.Pdf417RecognizerSettings;
import com.microblink.recognizers.blinkbarcode.pdf417.Pdf417ScanResult;
import com.microblink.recognizers.blinkbarcode.usdl.USDLRecognizerSettings;
import com.microblink.recognizers.blinkbarcode.usdl.USDLScanResult;
import com.microblink.recognizers.blinkbarcode.zxing.ZXingRecognizerSettings;
import com.microblink.recognizers.blinkbarcode.zxing.ZXingScanResult;
import com.microblink.recognizers.blinkid.croatia.back.CroatianIDBackSideRecognitionResult;
import com.microblink.recognizers.blinkid.croatia.back.CroatianIDBackSideRecognizerSettings;
import com.microblink.recognizers.blinkid.croatia.front.CroatianIDFrontSideRecognitionResult;
import com.microblink.recognizers.blinkid.croatia.front.CroatianIDFrontSideRecognizerSettings;
import com.microblink.recognizers.blinkid.eudl.EUDLCountry;
import com.microblink.recognizers.blinkid.eudl.EUDLRecognitionResult;
import com.microblink.recognizers.blinkid.eudl.EUDLRecognizerSettings;
import com.microblink.recognizers.blinkid.malaysia.MyKadRecognitionResult;
import com.microblink.recognizers.blinkid.malaysia.MyKadRecognizerSettings;
import com.microblink.recognizers.blinkid.mrtd.MRTDRecognitionResult;
import com.microblink.recognizers.blinkid.mrtd.MRTDRecognizerSettings;
import com.microblink.recognizers.blinkid.singapore.SingaporeIDRecognitionResult;
import com.microblink.recognizers.blinkid.singapore.SingaporeIDRecognizerSettings;
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
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

/**
 * Created by ivan on 2/29/16.
 */
public class BlinkID {

    // result data keys
    public static final String PAYMENT_DATA_KEY = "PaymentDataType";

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
    public static final String DATE_OF_BIRTH_KEY= "DateOfBirth";
    public static final String DATE_OF_EXPIRY_KEY = "DateOfExpiry";
    public static final String DATE_OF_ISSUE_KEY = "DateOfIssue";
    public static final String DOCUMENT_NUMBER_KEY = "DocumentNumber";
    public static final String ADDRESS_KEY = "Address";
    public static final String ISSUING_AUTHORITY_KEY = "IssuingAuthority";
    public static final String BLOOD_GROUP_KEY = "BloodGroup";
    public static final String RACE_KEY = "Race";

    public static final String PRIMARY_ID_KEY = "PrimaryID";
    public static final String SECONDARY_ID_KEY = "SecondaryID";
    public static final String NATIONALITY_KEY = "Nationality";
    public static final String DOCUMENT_CODE_KEY = "DocumentCode";
    public static final String ISSUER_KEY = "Issuer";
    public static final String OPT1_KEY = "Opt1";
    public static final String OPT2_KEY = "Opt2";
    public static final String MRZ_RAW_KEY = "MrzText";

    // result types
    public static final String PDF417_RESULT_TYPE = "PDF417";
    public static final String USDL_RESULT_TYPE = "USDL";
    public static final String BARDECODER_RESULT_TYPE = "Barcode";
    public static final String ZXING_RESULT_TYPE = BARDECODER_RESULT_TYPE;
    public static final String MRTD_RESULT_TYPE = "MRTD";
    public static final String EUDL_RESULT_TYPE = "EUDL";
    public static final String MYKAD_RESULT_TYPE = "MyKad";
    public static final String CRO_ID_FRONT_RESULT_TYPE = "CroIdFront";
    public static final String CRO_ID_BACK_RESULT_TYPE = "CroIdBack";
    public static final String SINGAPORE_ID_FRONT_RESULT_TYPE = "SingaporeIdFront";
    public static final String SINGAPORE_ID_BACK_RESULT_TYPE = "SingaporeIdBack";

    private static final String LOG_TAG = "BlinkId";

    DateFormat mDateFormat = new SimpleDateFormat("dd/MM/yyyy");


    private RecognitionSettings mRecognitionSettings;
    private Context mContext;
    private String mLicenseKey;
    private BlinkIdResultListener mResultListener;

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


    public Set<RecognizerType> filterOutUnsupportedRecognizers(Set<RecognizerType> recognizers) {
        return filterOutUnsupportedRecognizers(recognizers, false);
    }

    /**
     * Filters out unsupported recognizers (on current device and chosen camera) from given
     * {@code recognizers} set.
     * @param recognizers Set of recognizers that should be used in recognition. Set remains
     *                    unchanged.
     * @param useCameraFrontFace If set to {@code true} filters out recognizers that are unsupported
     *                           on current phone's front-facing camera, otherwise do the same for
     *                           default phone camera.
     * @return Set of recognizers that are supported on current device and chosen camera.
     */
    public Set<RecognizerType> filterOutUnsupportedRecognizers(
            Set<RecognizerType> recognizers, boolean useCameraFrontFace) {
        RecognizerSettings[] settArray = buildRecognitionSettings(recognizers, useCameraFrontFace)
                .getRecognizerSettingsArray();

        CameraType cameraType = CameraType.CAMERA_DEFAULT;
        if (useCameraFrontFace) {
            cameraType = CameraType.CAMERA_FRONTFACE;
        }
        if(!RecognizerCompatibility.cameraHasAutofocus(cameraType, mContext)) {
            settArray = RecognizerSettingsUtils.filterOutRecognizersThatRequireAutofocus(settArray);
        }

        Set<RecognizerType> filtered = new HashSet<>();
        for (RecognizerSettings recognizerSettings : settArray) {
            if (recognizerSettings instanceof Pdf417RecognizerSettings) {
                filtered.add(RecognizerType.PDF417);
            } else if (recognizerSettings instanceof  USDLRecognizerSettings) {
                filtered.add(RecognizerType.USDL);
            } else if (recognizerSettings instanceof  BarDecoderRecognizerSettings) {
                filtered.add(RecognizerType.BARDECODER);
            } else if (recognizerSettings instanceof  ZXingRecognizerSettings) {
                filtered.add(RecognizerType.ZXING);
            } else if (recognizerSettings instanceof  MRTDRecognizerSettings) {
                filtered.add(RecognizerType.MRTD);
            } else if (recognizerSettings instanceof  EUDLRecognizerSettings) {
                switch (((EUDLRecognizerSettings) recognizerSettings).getCountry()) {
                    case EUDL_COUNTRY_GERMANY:
                        addEUDLRecognizerToFiltered(RecognizerType.DEDL, filtered);
                        break;
                    case EUDL_COUNTRY_UK:
                        addEUDLRecognizerToFiltered(RecognizerType.UKDL, filtered);
                        break;
                    case EUDL_COUNTRY_AUTO:
                        addEUDLRecognizerToFiltered(RecognizerType.EUDL, filtered);
                        break;
                }
            } else if (recognizerSettings instanceof  MyKadRecognizerSettings) {
                filtered.add(RecognizerType.MYKAD);
            } else if (recognizerSettings instanceof CroatianIDFrontSideRecognizerSettings) {
                filtered.add(RecognizerType.CRO_ID_FRONT);
            } else if (recognizerSettings instanceof CroatianIDBackSideRecognizerSettings) {
                filtered.add(RecognizerType.CRO_ID_BACK);
            } else if (recognizerSettings instanceof SingaporeIDRecognizerSettings) {
                filtered.add(RecognizerType.SINGAPORE_ID);
            }
        }
        return filtered;
    }

    private void addEUDLRecognizerToFiltered(RecognizerType type, Set<RecognizerType> filtered) {
        boolean hasDifferentEudl = false;
        if (filtered.contains(RecognizerType.EUDL)) {
            return;
        }
        RecognizerType[] mutuallyExclusive = new RecognizerType[]{
                RecognizerType.DEDL,
                RecognizerType.UKDL
        };
        for (RecognizerType meType : mutuallyExclusive) {
            if (filtered.contains(meType)) {
                if (type != meType) {
                    filtered.remove(meType);
                    hasDifferentEudl = true;
                }
            }
        }
        if (hasDifferentEudl) {
            filtered.add(RecognizerType.EUDL);
        } else {
            filtered.add(type);
        }
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
     * have to be defined with setter methods.
     *
     * @param recognizers Recognizers that will be used to scan corresponding document types.
     * @param useFrontFaceCamera If set to {@code true} front-facing camera will be used,
     *                           otherwise default phone camera will be used.
     *
     * @throws IllegalStateException If license key, context or result listener is not defined.
     */
    public void scan(Set<RecognizerType> recognizers, boolean useFrontFaceCamera) {
        if (mLicenseKey == null || mContext == null || mResultListener == null) {
            throw new IllegalStateException("Before scanning, license key, context and result listener" +
                    " have to be defined.");
        }
        mRecognitionSettings = buildRecognitionSettings(recognizers, useFrontFaceCamera);
        Intent scanIntent = buildScanIntent(mRecognitionSettings, useFrontFaceCamera);
        Log.i(this, "Starting scan intent");
        mContext.startActivity(scanIntent);
    }

    /**
     * Starts the scan activity. Before scanning, license key, context and result listener
     * have to be defined with setter methods. Uses default camera.
     *
     * @param recognizers Recognizers that will be used to scan corresponding document types.
     *
     * @throws IllegalStateException If license key, context or result listener is not defined.
     */
    public void scan(Set<RecognizerType> recognizers) {
        scan(recognizers, false);
    }

    /**
     * This method builds scan intent for BlinkID.
     */
    private Intent buildScanIntent(RecognitionSettings settings, boolean useFrontFaceCamera) {

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

        intent.putExtra(BlinkIDScanActivity.EXTRAS_USE_FRONTFACE_CAMERA, useFrontFaceCamera);
        intent.putExtra(BlinkIDScanActivity.EXTRAS_RECOGNITION_SETTINGS, mRecognitionSettings);

        return intent;
    }

    /**
     * This method creates the recognition settings for scan activity.
     *
     * @param recognizers Recognizers that will be used to scan corresponding document types.
     *
     * @return Recognition settings for scan activity.
     */
    protected RecognitionSettings buildRecognitionSettings(Set<RecognizerType> recognizers, boolean useFrontFaceCamera) {
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
//        recognitionSettings.setAllowMultipleScanResultsOnSingleImage(true);

        List<RecognizerSettings> settingsList = new ArrayList<>();
        if (recognizers.contains(RecognizerType.MRTD)) {
            settingsList.add(buildMRTDRecognizerSettings());
        }

        if (recognizers.contains(RecognizerType.USDL)) {
            settingsList.add(buildUSDLRecognizerSettings());
        }

        if (recognizers.contains(RecognizerType.UKDL)) {
            settingsList.add(buildUKDLRecognizerSettings());
        }

        if (recognizers.contains(RecognizerType.DEDL)) {
            settingsList.add(buildDEDLRecognizerSettings());
        }

        if (recognizers.contains(RecognizerType.EUDL)) {
            settingsList.add(buildEUDLRecognizerSettings());
        }

        if (recognizers.contains(RecognizerType.MYKAD)) {
            settingsList.add(buildMyKadRecognizerSettings());
        }

        if (recognizers.contains(RecognizerType.PDF417)) {
            settingsList.add(buildPdf417RecognizerSettings());
        }

        if (recognizers.contains(RecognizerType.BARDECODER)) {
            settingsList.add(buildBardecoderRecognizerSettings());
        }

        if (recognizers.contains(RecognizerType.ZXING)) {
            settingsList.add(buildZxingRecognizerSettings());
        }

        if (recognizers.contains(RecognizerType.CRO_ID_BACK)) {
            settingsList.add(buildCroatianIDBackSideRecognizerSettings());
        }

        if (recognizers.contains(RecognizerType.CRO_ID_FRONT)) {
            settingsList.add(buildCroatianIDFrontSideRecognizerSettings());
        }

        if (recognizers.contains(RecognizerType.SINGAPORE_ID)) {
            settingsList.add(buildSingaporeIDRecognizerSettings());
        }

        RecognizerSettings[] settingsArray = new RecognizerSettings[settingsList.size()];
        settingsArray = settingsList.toArray(settingsArray);

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
    public void onScanningDone(RecognitionResults results) {
        BaseRecognitionResult[] resultsArr = results.getRecognitionResults();
        if (resultsArr != null && resultsArr.length > 0) {
            List<Map<String, String>> resultList = new ArrayList<>();
            for (BaseRecognitionResult result : resultsArr) {
                if (result instanceof CroatianIDFrontSideRecognitionResult) {
                    resultList.add(buildCroIdFrontResult((CroatianIDFrontSideRecognitionResult) result));
                } else if (result instanceof CroatianIDBackSideRecognitionResult) {
                    resultList.add(buildCroIdBackResult((CroatianIDBackSideRecognitionResult) result));
                } else if (result instanceof SingaporeIDRecognitionResult) {
                    resultList.add(buildSingaporeIdResult((SingaporeIDRecognitionResult) result));
                } else if (result instanceof USDLScanResult) {
                    resultList.add(buildUSDLResult((USDLScanResult) result));
                } else if (result instanceof EUDLRecognitionResult) {
                    resultList.add(buildEUDLResult((EUDLRecognitionResult) result));
                } else if (result instanceof MyKadRecognitionResult) {
                    resultList.add(buildMyKadResult((MyKadRecognitionResult) result));
                } else if (result instanceof Pdf417ScanResult) {
                    resultList.add(buildPdf417Result((Pdf417ScanResult) result));
                } else if (result instanceof BarDecoderScanResult) {
                    resultList.add(buildBarDecoderResult((BarDecoderScanResult) result));
                } else if (result instanceof ZXingScanResult) {
                    resultList.add(buildZxingResult((ZXingScanResult) result));
                } else if (result instanceof MRTDRecognitionResult) {
                    resultList.add(buildMRTDResult((MRTDRecognitionResult) result));
                } else {
                    throw new RuntimeException("Unknown result type: "
                            + result.getClass().toString() + " in result array.");
                }
            }
            mResultListener.onResultsAvailable(resultList);
        } else {
            mResultListener.onResultsAvailable(null);
        }

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
     * Builds {@link MRTDRecognizerSettings} which define settings for scanning
     * MRTD (Machine Readable Travel Documents).
     */
    private MRTDRecognizerSettings buildMRTDRecognizerSettings() {
        // To specify we want to perform MRTD (Machine Readable Travel Document) recognition,
        // prepare settings for MRTD recognizer
        return new MRTDRecognizerSettings();
    }

    /**
     * Builds {@link USDLRecognizerSettings} which define settings for scanning
     * USDL (US Driver's Licenses)
     */
    private USDLRecognizerSettings buildUSDLRecognizerSettings() {
        // To specify we want to perform USDL (US Driver's License) recognition,
        // prepare settings for USDL recognizer
        return new USDLRecognizerSettings();
    }

    /**
     * Builds {@link EUDLRecognizerSettings} which define settings for scanning
     * EUDL (EU Driver's License). Enabled driver licenses are <b>UK</b> driver's licenses.
     */
    private EUDLRecognizerSettings buildUKDLRecognizerSettings() {
        // To specify we want to perform EUDL (EU Driver's License) recognition,
        // prepare settings for EUDL recognizer. Pass country as parameter to EUDLRecognizerSettings
        // constructor. Here we choose UK.
        return new EUDLRecognizerSettings(EUDLCountry.EUDL_COUNTRY_UK);
    }

    /**
     * Builds {@link EUDLRecognizerSettings} which define settings for scanning
     * EUDL (EU Driver's License). Enabled driver licenses are <b>German</b> driver's licenses.
     */
    private EUDLRecognizerSettings buildDEDLRecognizerSettings() {
        // To specify we want to perform EUDL (EU Driver's License) recognition,
        // prepare settings for EUDL recognizer. Pass country as parameter to EUDLRecognizerSettings
        // constructor. Here we choose Germany.
        return new EUDLRecognizerSettings(EUDLCountry.EUDL_COUNTRY_GERMANY);
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
     * Builds {@link EUDLRecognizerSettings} which define settings for scanning
     * MyKad (Malaysian MyKad ID document).
     */
    private MyKadRecognizerSettings buildMyKadRecognizerSettings() {
        // To specify we want to perform MyKad (Malaysian MyKad ID document) recognition,
        // prepare settings for MyKad recognizer
        return new MyKadRecognizerSettings();
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

    /**
     * Builds {@link CroatianIDBackSideRecognizerSettings} which define settings for scanning
     * back side of Croatian ID card.
     */
    private CroatianIDBackSideRecognizerSettings buildCroatianIDBackSideRecognizerSettings() {
        CroatianIDBackSideRecognizerSettings croIDBackSettings = new CroatianIDBackSideRecognizerSettings();
        croIDBackSettings.setExtractIssuingAuthority(true);
        croIDBackSettings.setExtractDateOfIssue(true);
        return croIDBackSettings;
    }

    /**
     * Builds {@link CroatianIDFrontSideRecognizerSettings} which define settings for scanning
     * front side of Croatian ID card.
     */
    private CroatianIDFrontSideRecognizerSettings buildCroatianIDFrontSideRecognizerSettings() {
        CroatianIDFrontSideRecognizerSettings croIDFrontSettings = new CroatianIDFrontSideRecognizerSettings();
        croIDFrontSettings.setExtractSex(true);
        croIDFrontSettings.setExtractCitizenship(true);
        croIDFrontSettings.setExtractDateOfBirth(true);
        croIDFrontSettings.setExtractDateOfExpiry(true);
        return croIDFrontSettings;
    }

    /**
     * Builds {@link SingaporeIDRecognizerSettings} which define settings for scanning
     * front and back side of Singapore ID card.
     */
    private SingaporeIDRecognizerSettings buildSingaporeIDRecognizerSettings() {
        SingaporeIDRecognizerSettings singaporeIDSettings = new SingaporeIDRecognizerSettings();
        singaporeIDSettings.setExtractBloodGroup(true);
        singaporeIDSettings.setExtractCountryOfBirth(true);
        singaporeIDSettings.setExtractDateOfBirth(true);
        singaporeIDSettings.setExtractDateOfIssue(true);
        singaporeIDSettings.setExtractRace(true);
        singaporeIDSettings.setExtractSex(true);
        return singaporeIDSettings;
    }

    /**
     * Builds result map for Pdf417 scan result.
     */
    private Map<String, String> buildPdf417Result(Pdf417ScanResult res) {
        // getStringData getter will return the string version of barcode contents
        String barcodeData = res.getStringData();
        // getRawData getter will return the raw data information object of barcode contents
        BarcodeDetailedData rawData = res.getRawData();
        // BarcodeDetailedData contains information about barcode's binary layout, if you
        // are only interested in raw bytes, you can obtain them with getAllData getter
        byte[] rawDataBuffer = rawData.getAllData();

        Map<String, String> resultMap = new HashMap<>();
        resultMap.put(RESULT_TYPE_KEY, PDF417_RESULT_TYPE);
        resultMap.put(BARCODE_TYPE_KEY, "PDF417");
        resultMap.put(BARCODE_DATA_KEY, barcodeData);
        resultMap.put(BARCODE_RAW_DATA_KEY, byteArrayToHex(rawDataBuffer));
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
        resultMap.put(BARCODE_TYPE_KEY, type.name());
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
        resultMap.put(BARCODE_TYPE_KEY, type.name());
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
        resultMap.put(DATE_OF_BIRTH_KEY, res.getDateOfBirth());
        resultMap.put(SEX_KEY, res.getSex());
        resultMap.put(NATIONALITY_KEY, res.getNationality());
        resultMap.put(DOCUMENT_CODE_KEY, res.getDocumentCode());
        resultMap.put(ISSUER_KEY, res.getIssuer());
        resultMap.put(DATE_OF_EXPIRY_KEY, res.getDateOfExpiry());
        resultMap.put(OPT2_KEY, res.getOpt2());
        resultMap.put(OPT1_KEY, res.getOpt1());
        resultMap.put(DOCUMENT_NUMBER_KEY, res.getDocumentNumber());
        resultMap.put(MRZ_RAW_KEY, res.getMRZText());

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


    /**
     * Supported recognizers.
     */
    public enum RecognizerType {
        /** Pdf417 recognizer */
        PDF417,
        /** US Driver's License recognizer */
        USDL,
        /** Bardecoder recognizer */
        BARDECODER,
        /** Zxing recognizer */
        ZXING,
        /** Machine Readable Travel Document recognizer */
        MRTD,
        /** German Driver's License recognizer */
        DEDL,
        /** UK Driver's License recognizer */
        UKDL,
        /** EU Driver's License recognizer, scans all supported EU Driver's Licenses */
        EUDL,
        /** Malaysian MyKad ID document recognizer */
        MYKAD,
        /** Croatian ID card front side recognizer */
        CRO_ID_FRONT,
        /** Croatian ID card back side recognizer */
        CRO_ID_BACK,
        /** Singapore ID card recognizer */
        SINGAPORE_ID
    }

}
