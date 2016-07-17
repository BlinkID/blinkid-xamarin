package com.microblink.wrapper.xamarin;

import android.graphics.Bitmap;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;

import java.util.List;
import java.util.Map;

/**
 * This is abstract class instead of interface due to problems with xamarin integration.
 *
 * This interface should be implemented by all listeners that are responsible for obtaining of
 * scan results.
 *
 */
public abstract class BlinkIdResultListener {
    /**
     * This method is called when recognition is done and results are available.
     * @param results List of recognition results, or {@code null} if nothing was scanned.
     *                Each list element is a map that contains result from one successful
     *                recognizer whose type is stored under {@link BlinkID#RESULT_TYPE_KEY} key.
     */
    public abstract void onResultsAvailable(@Nullable List<Map<String, String>> results);

    /**
     * This method is called when document image is available.
     * @param image Image of the scanned document.
     */
    public abstract void onDocumentImageAvailable(@NonNull Bitmap image);
}
