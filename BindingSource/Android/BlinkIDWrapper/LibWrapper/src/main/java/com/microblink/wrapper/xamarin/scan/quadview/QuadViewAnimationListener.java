package com.microblink.wrapper.xamarin.scan.quadview;

/**
 * Listener that will be notified of QuadView's animation events.
 */
public interface QuadViewAnimationListener {
    /**
     * Called when quad view starts animating quad.
     */
    void onAnimationStart();

    /**
     * Called when quad view finishes quad animation.
     */
    void onAnimationEnd();
}
