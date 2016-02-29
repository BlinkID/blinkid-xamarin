package com.microblink.wrapper.xamarin;

import java.util.List;
import java.util.Map;

/**
 * Created by ivan on 2/29/16.
 */
public interface BlinkIdResultListener {
    /**
     * This method is called when recognition results are available.
     * @param results List of recognition results. Each list element is a map that contains
     *                result from one successful recognizer whose type is stored under
     *                {@link BlinkID#RESULT_TYPE_KEY} key.
     */
    void onResultsAvailable(List<Map<String, String>> results);
}
