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

import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

public class MainActivity extends AppCompatActivity {

    private static final String LICENSE_KEY = "BRVITPHC-YSYABCZD-CHKHMEC6-E3NNMLH2-LYTNVVRM-7JPCNWWW-FT5F4JW2-32QER7JS";
    ;

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
        blinkId.setContext(this);
        blinkId.setLicenseKey(LICENSE_KEY);
        blinkId.setResultListener(mResultListener);
        Set<BlinkID.RecognizerType> recognizers = new HashSet<>();
        // recognize US Driver's Licenses
        recognizers.add(BlinkID.RecognizerType.USDL);
        // recognize UK Driver's Licenses
        recognizers.add(BlinkID.RecognizerType.UKDL);
//        recognizers.add(BlinkID.RecognizerType.PDF417);
//        recognizers.add(BlinkID.RecognizerType.CRO_ID_FRONT);
//        recognizers.add(BlinkID.RecognizerType.CRO_ID_BACK);


        boolean useFrontFaceCamera = false;
        recognizers = blinkId.filterOutUnsupportedRecognizers(recognizers, useFrontFaceCamera);
        blinkId.scan(recognizers, useFrontFaceCamera);
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
