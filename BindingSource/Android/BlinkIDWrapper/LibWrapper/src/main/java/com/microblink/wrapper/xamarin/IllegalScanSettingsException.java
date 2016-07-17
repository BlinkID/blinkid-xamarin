package com.microblink.wrapper.xamarin;

/**
 * Exception that is thrown when scan settings are not valid (e.g. no recognizers are active).
 */
public class IllegalScanSettingsException extends Exception {

    public IllegalScanSettingsException(String message) {
        super(message);
    }

    public IllegalScanSettingsException() {
        super();
    }
}
