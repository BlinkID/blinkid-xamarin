package com.microblink.wrapper.xamarin;

import com.microblink.activity.ScanCard;
import com.microblink.recognizers.RecognitionResults;

/**
 * Created by ivan on 2/29/16.
 */
public class ScanCardWrapper extends ScanCard {

    @Override
    public void onScanningDone(RecognitionResults recognitionResults) {
        super.onScanningDone(recognitionResults);
        BlinkID.getInstance().onScanningDone(recognitionResults);
    }
}
