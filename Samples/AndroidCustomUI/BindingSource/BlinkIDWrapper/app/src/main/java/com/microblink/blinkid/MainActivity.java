package com.microblink.blinkid;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import com.microblink.MicroblinkSDK;
import com.microblink.blinkid.wrapper.BlinkIDWrapper;
import com.microblink.entities.recognizers.RecognizerBundle;
import com.microblink.entities.recognizers.blinkid.generic.BlinkIdRecognizer;
import com.microblink.intent.IntentDataTransferMode;
import com.microblink.util.Log;
import com.microblink.util.RecognizerCompatibility;
import com.microblink.util.RecognizerCompatibilityStatus;

import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {

    private static final int MY_REQUEST_CODE = 123;

    RecognizerBundle recognizerBundle;
    BlinkIdRecognizer recognizer;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Button btnScan = findViewById(R.id.btnScan);

        boolean isRecognitionSupported = true;
        RecognizerCompatibilityStatus supportStatus = RecognizerCompatibility.getRecognizerCompatibilityStatus(this);
        if (supportStatus == RecognizerCompatibilityStatus.RECOGNIZER_SUPPORTED) {
            Log.i(this, "Recognition is supported!");
        } else if (supportStatus == RecognizerCompatibilityStatus.NO_CAMERA) {
            Toast.makeText(this, "BlinkID is supported only in DirectAPI mode!", Toast.LENGTH_SHORT).show();
            Log.w(this, "Recognition is supported only in DirectAPI mode!");
        } else {
            isRecognitionSupported = false;
            Toast.makeText(this, "BlinkID is not supported! Reason: " + supportStatus.name(), Toast.LENGTH_LONG).show();
            Log.e(this, "Recognition is not supported! Reason: {}", supportStatus.name());
        }

        if (isRecognitionSupported) {
            MicroblinkSDK.setLicenseFile("com.microblink.blinkid.mblic", this);
            MicroblinkSDK.setIntentDataTransferMode(IntentDataTransferMode.PERSISTED_OPTIMISED);
            recognizer = new BlinkIdRecognizer();
            recognizer.setReturnFullDocumentImage(true);
            recognizer.setReturnFaceImage(true);
            recognizerBundle = new RecognizerBundle(recognizer);
        } else {
            btnScan.setEnabled(false);
        }
    }

    public void scanClickHandler(View view) {
        BlinkIDWrapper.startMyScanActivityForResult(this, MY_REQUEST_CODE, recognizerBundle);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        // onActivityResult is called whenever we returned from activity started with startActivityForResult
        // We need to check request code to determine that we have really returned from appropriate activity
        if (requestCode != MY_REQUEST_CODE) {
            return;
        }

        if (resultCode == Activity.RESULT_OK) {
            // OK result code means scan was successful
            onScanSuccess(data);
        } else {
            // user probably pressed Back button and cancelled scanning
            onScanCanceled();
        }
    }

    private void onScanSuccess(Intent data) {
        // update recognizer results with scanned data
        recognizerBundle.loadFromIntent(data);

        // you can now extract any scanned data from result, we'll just get primary id
        BlinkIdRecognizer.Result result = recognizer.getResult();
        String name = result.getFullName();
        if (name.isEmpty()) {
            name = result.getFirstName();
        }
        Toast.makeText(this, "Name: " + name, Toast.LENGTH_LONG).show();
    }

    private void onScanCanceled() {
        Toast.makeText(this, "Scan cancelled!", Toast.LENGTH_SHORT).show();
    }
}
