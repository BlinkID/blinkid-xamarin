package com.microblink.blinkid.wrapper;

import android.app.Activity;
import android.content.Intent;

import com.microblink.entities.recognizers.RecognizerBundle;

public final class BlinkIDWrapper {

    public static void startMyScanActivityForResult(Activity parentActivity, int requestCode, RecognizerBundle recognizerBundle) {
        Intent intent = new Intent(parentActivity, MyScanActivity.class);
        recognizerBundle.saveToIntent(intent);
        parentActivity.startActivityForResult(intent, requestCode);
    }

}
