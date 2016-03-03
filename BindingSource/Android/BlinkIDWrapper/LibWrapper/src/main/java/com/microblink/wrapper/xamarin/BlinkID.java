package com.microblink.wrapper.xamarin;

import android.content.Context;
import android.content.Intent;
import android.os.Parcelable;

import com.microblink.activity.ScanActivity;
import com.microblink.activity.ScanCard;
import com.microblink.activity.ShowOcrResultMode;
import com.microblink.recognizers.BaseRecognitionResult;
import com.microblink.recognizers.IResultHolder;
import com.microblink.recognizers.RecognitionResults;
import com.microblink.recognizers.blinkbarcode.BarcodeType;
import com.microblink.recognizers.blinkbarcode.bardecoder.BarDecoderScanResult;
import com.microblink.recognizers.blinkbarcode.pdf417.Pdf417ScanResult;
import com.microblink.recognizers.blinkbarcode.usdl.USDLRecognizerSettings;
import com.microblink.recognizers.blinkbarcode.usdl.USDLScanResult;
import com.microblink.recognizers.blinkbarcode.zxing.ZXingScanResult;
import com.microblink.recognizers.blinkid.eudl.EUDLCountry;
import com.microblink.recognizers.blinkid.eudl.EUDLRecognitionResult;
import com.microblink.recognizers.blinkid.eudl.EUDLRecognizerSettings;
import com.microblink.recognizers.blinkid.malaysia.MyKadRecognitionResult;
import com.microblink.recognizers.blinkid.mrtd.MRTDRecognitionResult;
import com.microblink.recognizers.blinkid.mrtd.MRTDRecognizerSettings;
import com.microblink.recognizers.settings.RecognitionSettings;
import com.microblink.recognizers.settings.RecognizerSettings;
import com.microblink.results.barcode.BarcodeDetailedData;
import com.microblink.util.Log;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Created by ivan on 2/29/16.
 */
public class BlinkID {

    public static final String PAYMENT_DATA_KEY = "PaymentDataType";

    public static final String RESULT_TYPE_KEY = "ResultType";
    public static final String BARCODE_TYPE_KEY = "Type";
    public static final String BARCODE_DATA_KEY = "Data";
    public static final String BARCODE_RAW_DATA_KEY = "Raw";

    // result types
    public static final String PDF417_RESULT_TYPE = "PDF417";
    public static final String USDL_RESULT_TYPE = "USDL";
    public static final String BARDECODER_RESULT_TYPE = "Barcode";
    public static final String ZXING_RESULT_TYPE = BARDECODER_RESULT_TYPE;
    public static final String MRTD_RESULT_TYPE = "MRTD";
    public static final String EUDL_RESULT_TYPE = "EUDL";
    public static final String MYKAD_RESULT_TYPE = "MyKad";

    private static final String LOG_TAG = "BlinkId";

    private RecognitionSettings mRecognitionSettings;
    private Context mContext;
    private String mLicenseKey;
    private BlinkIdResultListener mResultListener;

    private static BlinkID ourInstance = new BlinkID();

    public static BlinkID getInstance() {
        return ourInstance;
    }

    private BlinkID() {
        mRecognitionSettings = buildRecognitionSettings();
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
     * have to be defined with setter methods.
     *
     * @throws IllegalStateException If license key, context or result listener is not defined.
     */
    public void scan() {
        if (mLicenseKey == null || mContext == null || mResultListener == null) {
            throw new IllegalStateException("Before scanning, license key, context and result listener" +
                    " have to be defined.");
        }
        Intent scanIntent = buildScanIntent(mRecognitionSettings);
        Log.w(this, "Starting scan intent");
        mContext.startActivity(scanIntent);
    }

    /**
     * This method builds scan intent for BlinkID.
     */
    private Intent buildScanIntent(RecognitionSettings settings) {

        // first create intent for provided ScanCard activity
        final Intent intent = new Intent(mContext, BlinkIDScanActivity.class);

        // optionally, if you want the beep sound to be played after a scan
        // add a sound resource id as EXTRAS_BEEP_RESOURCE extra
//        intent.putExtra(ScanActivity.EXTRAS_BEEP_RESOURCE, R.raw.beep);

        // if we have help intent, we can pass it to scan activity so it can invoke
        // it if user taps the help button. If we do not set the help intent,
        // scan activity will hide the help button.
//        intent.putExtra(ScanActivity.EXTRAS_HELP_INTENT, helpIntent);


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

        // If you want, you can disable drawing of OCR results on scan activity. Drawing OCR results can be visually
        // appealing and might entertain the user while waiting for scan to complete, but might introduce a small
        // performance penalty.
        // intent.putExtra(ScanActivity.EXTRAS_SHOW_OCR_RESULT, false);

        /// If you want you can have scan activity display the focus rectangle whenever camera
        // attempts to focus, similarly to various camera app's touch to focus effect.
        // By default this is off, and you can turn this on by setting EXTRAS_SHOW_FOCUS_RECTANGLE
        // extra to true.
//        intent.putExtra(ScanActivity.EXTRAS_SHOW_FOCUS_RECTANGLE, true);

        // If you want, you can enable the pinch to zoom feature of scan activity.
        // By enabling this you allow the user to use the pinch gesture to zoom the camera.
        // By default this is off and can be enabled by setting EXTRAS_ALLOW_PINCH_TO_ZOOM extra to true.
//        intent.putExtra(ScanActivity.EXTRAS_ALLOW_PINCH_TO_ZOOM, true);

        // Enable showing of OCR results as animated dots. This does not have effect if non-OCR recognizer like
        // barcode recognizer is active.
//        intent.putExtra(ScanCard.EXTRAS_SHOW_OCR_RESULT_MODE, (Parcelable) ShowOcrResultMode.ANIMATED_DOTS);

        intent.putExtra(BlinkIDScanActivity.EXTRAS_RECOGNITION_SETTINGS, mRecognitionSettings);

        return intent;
    }

    /**
     * This method creates the recognition settings for scan activity.
     *
     * @return Recognition settings for scan activity.
     */
    protected RecognitionSettings buildRecognitionSettings() {
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

        // To specify we want to perform MRTD (Machine Readable Travel Document) recognition,
        // prepare settings for MRTD recognizer
        MRTDRecognizerSettings mrtd = new MRTDRecognizerSettings();

        // To specify we want to perform USDL (US Driver's License) recognition,
        // prepare settings for USDL recognizer
        USDLRecognizerSettings usdl = new USDLRecognizerSettings();

        // To specify we want to perform EUDL (EU Driver's License) recognition,
        // prepare settings for EUDL recognizer. Pass country as parameter to EUDLRecognizerSettings
        // constructor. Here we choose UK.
        EUDLRecognizerSettings ukdl = new EUDLRecognizerSettings(EUDLCountry.EUDL_COUNTRY_UK);

        //MyKadRecognizerSettings myKad = new MyKadRecognizerSettings();

        // Add array with recognizer settings so that scan activity will know
        // what do you want to scan. Setting recognizer settings array is mandatory.
        recognitionSettings.setRecognizerSettingsArray(new RecognizerSettings[]{mrtd, usdl, ukdl});

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
                if (result instanceof MRTDRecognitionResult) {
                    resultList.add(buildMRTDResult((MRTDRecognitionResult) result));
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
        return buildKeyValueResult(res, EUDL_RESULT_TYPE);
    }

    /**
     * Builds result map for MRTD scan result.
     */
    private Map<String, String> buildMRTDResult(MRTDRecognitionResult res) {
        return buildKeyValueResult(res, MRTD_RESULT_TYPE);
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
