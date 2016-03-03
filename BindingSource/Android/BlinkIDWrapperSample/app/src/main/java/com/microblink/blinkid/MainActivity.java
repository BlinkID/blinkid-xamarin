package com.microblink.blinkid;

import android.app.AlertDialog;
import android.content.pm.ActivityInfo;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import com.microblink.wrapper.xamarin.BlinkID;
import com.microblink.wrapper.xamarin.BlinkIdResultListener;

import java.util.List;
import java.util.Map;

public class MainActivity extends AppCompatActivity {

    private static final String LICENSE_KEY = "NFRZVYWD-MCK7SSO7-TJ7ZWOC4-AT2AYDM7-JDHZQMHY-V3PZU4SX-54PGUFQM-AUX5RGYJ";
    ;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);

        // check if BlinkID is supported on the device
        Button btnScan = (Button) findViewById(R.id.btnScan);

//        RecognizerCompatibilityStatus supportStatus = RecognizerCompatibility.getRecognizerCompatibilityStatus(this);
//        if (supportStatus == RecognizerCompatibilityStatus.RECOGNIZER_SUPPORTED) {
//            btnScan.setEnabled(true);
//        } else {
//            btnScan.setEnabled(false);
//            Toast.makeText(this, "BlinkID is not supported! Reason: " + supportStatus.name(), Toast.LENGTH_LONG).show();
//        }
    }

    public void scanClickHandler(View view) {
        BlinkID blinkId = BlinkID.getInstance();
        blinkId.setContext(this);
        blinkId.setLicenseKey(LICENSE_KEY);
        blinkId.setResultListener(mResultListener);
        blinkId.scan();
    }

    BlinkIdResultListener mResultListener = new BlinkIdResultListener() {
        @Override
        public void onResultsAvailable(List<Map<String, String>> results) {
            if (results == null) {
                Toast.makeText(MainActivity.this, "Nothing scanned.", Toast.LENGTH_LONG).show();
                return;
            }
            StringBuilder sb = new StringBuilder();
            for (Map<String, String> resMap : results) {
                sb.append(resMap.get(BlinkID.RESULT_TYPE_KEY)).append(" result:\n\n");
                for (String key : resMap.keySet()) {
                    sb.append(key).append(": ").append(resMap.get(key)).append("\n");
                }
                sb.append("\n\n");
            }
            final AlertDialog dialog = new AlertDialog.Builder(MainActivity.this)
                    .setTitle("Scan result")
                    .setMessage(sb.toString())
                    .setPositiveButton("OK", null)
                    .setCancelable(false)
                    .create();
            runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    dialog.show();
                }
            });
        }
    };
}
