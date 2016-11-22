package com.microblink.blinkid;

import android.app.AlertDialog;
import android.content.pm.ActivityInfo;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Toast;

import com.microblink.util.Log;
import com.microblink.wrapper.xamarin.BlinkID;
import com.microblink.wrapper.xamarin.BlinkIdResultListener;
import com.microblink.wrapper.xamarin.BlinkIdScanSettings;
import com.microblink.wrapper.xamarin.IllegalScanSettingsException;

import java.util.List;
import java.util.Map;

public class MainActivity extends AppCompatActivity {

    private static final String LICENSE_KEY = "BRVITPHC-YSYABCZD-CHKHMEC6-E3NNMLH2-LYTNVVRM-7JPCNWWW-FT5F4JW2-32QER7JS";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);

        // check if BlinkID is supported on the device
        Button btnScan = (Button) findViewById(R.id.btnScan);

        if (BlinkID.getInstance().isBlinkIDSupportedOnDevice(this)) {
            btnScan.setEnabled(true);
        } else {
            btnScan.setEnabled(false);
            Toast.makeText(this, "BlinkID is not supported!", Toast.LENGTH_LONG).show();
        }
    }

    public void scanClickHandler(View view) {
        BlinkID blinkId = BlinkID.getInstance();
        // set context, license key and result listener
        blinkId.setContext(this);
        blinkId.setLicenseKey(LICENSE_KEY);
        blinkId.setResultListener(mResultListener);

        // build scan settings for back facing camera
        BlinkIdScanSettings scanSettings = new BlinkIdScanSettings(this, BlinkIdScanSettings.DeviceCameraType.CAMERA_BACKFACE);
        // allow multiple scan results
        scanSettings.setAllowMultipleScanResultsOnSingleImage(true);

        if (!scanSettings.addRecognizerMRTD()) {
            Log.w(this, "MRTD recognizer is not supported on current device and chosen camera type");
        }
        if (!scanSettings.addRecognizerPdf417()) {
            Log.w(this, "PDF417 recognizer is not supported on current device and chosen camera type");
        }
        
        // scan can throw IllegalScanSettingsException if scan settings are not valid, at least
        // one recognizer or parser or detector must be active in scan settings
        try {
            blinkId.scan(scanSettings);
        } catch (IllegalScanSettingsException e) {
            Log.w(this, "ERROR: {}", e.getMessage());
            e.printStackTrace();
        }
    }

    BlinkIdResultListener mResultListener = new BlinkIdResultListener() {
        @Override
        public void onResultsAvailable(List<Map<String, String>> results) {
            if (results == null) {
                Toast.makeText(MainActivity.this, "Nothing scanned.", Toast.LENGTH_LONG).show();
                return;
            }
            final StringBuilder sb = new StringBuilder();
            for (Map<String, String> resMap : results) {
                sb.append(resMap.get(BlinkID.RESULT_TYPE_KEY)).append(" result:\n\n");
                for (String key : resMap.keySet()) {
                    sb.append(key).append(": ").append(resMap.get(key)).append("\n");
                }
                sb.append("\n\n");
            }
            runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    AlertDialog dialog = new AlertDialog.Builder(MainActivity.this)
                            .setTitle("Scan result")
                            .setMessage(sb.toString())
                            .setPositiveButton("OK", null)
                            .setCancelable(false)
                            .create();
                    dialog.show();
                }
            });
        }

        @Override
        public void onDocumentImageAvailable(@NonNull final Bitmap bitmap) {
            runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    ImageView iv = new ImageView(MainActivity.this);
                    iv.setImageBitmap(bitmap);
                    AlertDialog dialog = new AlertDialog.Builder(MainActivity.this)
                            .setTitle("Scan image")
                            .setView(iv)
                            .setPositiveButton("OK", null)
                            .setCancelable(false)
                            .create();
                    dialog.show();
                    Toast.makeText(MainActivity.this, "Bitmap available", Toast.LENGTH_LONG).show();
                }
            });
        }
    };
}
