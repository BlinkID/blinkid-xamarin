package com.microblink.wrapper.xamarin.scan.quadview;

/**
 * Class that manages animated quadrilateral view.
 */
public class QuadViewManager {
    private QuadView mQuadView;

    public QuadViewManager(QuadView quadView) {
        mQuadView = quadView;
    }

    /**
     * Call this method to begin quadrilateral animation to its default position.
     * It is safe to call this method from non-UI thread.
     */
    public void animateQuadToDefaultPosition() {
        mQuadView.setDefaultTarget();
        mQuadView.publishDetectionStatus(false);
    }

    /**
     * Call this method to begin quadrilateral animation to detected quadrilateral.
     * @param detection Detected quadrilateral to which we animate the view.
     * @param detectionSuccessful Status of the detection (determines Quadrilateral color).
     */
    public void animateQuadToDetectionPosition(QuadrilateralWrapper detection, boolean detectionSuccessful) {
        if (!detection.isEmpty()) {
            mQuadView.setNewTarget(detection);
        }
        mQuadView.publishDetectionStatus(detectionSuccessful);
    }


    /**
     * Returns true if quad view animation is currently in progress.
     * @return true if quad view animation is currently in progress.
     */
    public boolean isAnimationInProgress() {
        return mQuadView.isAnimationInProgress();
    }
}
