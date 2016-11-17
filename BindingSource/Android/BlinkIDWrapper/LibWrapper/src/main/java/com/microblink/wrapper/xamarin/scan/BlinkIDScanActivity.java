package com.microblink.wrapper.xamarin.scan;

import android.annotation.TargetApi;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Rect;
import android.media.MediaPlayer;
import android.os.Bundle;
import android.os.Handler;
import android.support.annotation.StringRes;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.FrameLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.microblink.detectors.DetectorResult;
import com.microblink.detectors.multi.MultiDetectorResult;
import com.microblink.detectors.points.PointsDetectorResult;
import com.microblink.detectors.quad.QuadDetectorResult;
import com.microblink.geometry.Point;
import com.microblink.geometry.Quadrilateral;
import com.microblink.hardware.SuccessCallback;
import com.microblink.hardware.camera.CameraType;
import com.microblink.hardware.orientation.Orientation;
import com.microblink.image.Image;
import com.microblink.image.ImageType;
import com.microblink.metadata.DetectionMetadata;
import com.microblink.metadata.ImageMetadata;
import com.microblink.metadata.Metadata;
import com.microblink.metadata.MetadataListener;
import com.microblink.metadata.MetadataSettings;
import com.microblink.recognition.InvalidLicenceKeyException;
import com.microblink.recognizers.RecognitionResults;
import com.microblink.recognizers.settings.RecognitionSettings;
import com.microblink.recognizers.settings.RecognizerSettings;
import com.microblink.util.Log;
import com.microblink.view.CameraAspectMode;
import com.microblink.view.CameraEventsListener;
import com.microblink.view.OnSizeChangedListener;
import com.microblink.view.OrientationAllowedListener;
import com.microblink.view.recognition.DetectionStatus;
import com.microblink.view.recognition.RecognizerView;
import com.microblink.view.recognition.ScanResultListener;
import com.microblink.wrapper.xamarin.BlinkID;
import com.microblink.wrapper.xamarin.R;
import com.microblink.wrapper.xamarin.scan.dots.PointSetView;
import com.microblink.wrapper.xamarin.scan.dots.PointSetWrapper;
import com.microblink.wrapper.xamarin.scan.quadview.QuadView;
import com.microblink.wrapper.xamarin.scan.quadview.QuadViewManager;
import com.microblink.wrapper.xamarin.scan.quadview.QuadrilateralWrapper;
import com.microblink.wrapper.xamarin.scan.quadview.XPoint;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;
import java.util.Timer;
import java.util.TimerTask;

public class BlinkIDScanActivity extends Activity implements ScanResultListener, CameraEventsListener, OnSizeChangedListener, MetadataListener {

    public static final String TAG = "BlinkIDScanActivity";

    public static final String EXTRAS_LICENSE_KEY = "EXTRAS_LICENSE_KEY";
    public static final String EXTRAS_RECOGNITION_SETTINGS = "EXTRAS_RECOGNITION_SETTINGS";
    public static final String EXTRAS_ACCEPTED_IMAGE_NAMES_ARRAY = "EXTRAS_ACCEPTED_IMAGE_NAMES_ARRAY";
    public static final String EXTRAS_CAMERA_TYPE = "EXTRAS_CAMERA_TYPE";


    /** Names of the dewarped images that will be accepted */
    private Set<String> mAcceptedImageNames = new HashSet<>();

    private Handler mHandler = new Handler();

    /**
     * This is a RecognizerView - it contains camera view and can contain camera overlays
     */
    private RecognizerView mRecognizerView;

    /**
     * This is a back button
     */
    private Button mBackButton = null;
    /**
     * This is a torch control button
     */
    private Button mTorchButton = null;
    /**
     * Is torch enabled?
     */
    private boolean mTorchEnabled = false;
    /**
     * This is a text field that contains status messages
     */
    private TextView mStatusTextView = null;
    /**
     * MediaPlayer will be used for beep sound
     */
    private MediaPlayer mMediaPlayer = null;

    /** CameraPermissionManager is provided helper class that can be used to obtain the permission to use camera.
     * It is used on Android 6.0 (API level 23) or newer.
     */
    private CameraPermissionManager mCameraPermissionManager;
    /**
     * Actual viewfinder that draws animations.
     */
    protected QuadViewManager mQuadViewManager = null;
    /**
     * Draws points detection.
     */
    protected PointSetView mPointSetView = null;

    boolean activityRunning = false;
    private boolean mFinishing = false;

    private Image mLastDewarpedImage;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_blinkid_scan);

        activityRunning = true;

        // obtain reference to RecognizerView
        mRecognizerView = (RecognizerView) findViewById(R.id.recognizerView);

        mAcceptedImageNames.clear();

        Intent intent = getIntent();
        Bundle extras = intent.getExtras();
        if (extras != null) {
            String licenseKey = extras.getString(EXTRAS_LICENSE_KEY);
            try {
                mRecognizerView.setLicenseKey(licenseKey);
            } catch (InvalidLicenceKeyException e) {
                Log.e(this, e, "INVALID LICENCE KEY");
                Toast.makeText(this, "Invalid licence key!", Toast.LENGTH_SHORT).show();
                finish();
            }

            CameraType cameraType = (CameraType) extras.getParcelable(EXTRAS_CAMERA_TYPE);
            mRecognizerView.setCameraType(cameraType);

            String[] acceptedImageNamesArr = extras.getStringArray(EXTRAS_ACCEPTED_IMAGE_NAMES_ARRAY);
            for (String imageName: acceptedImageNamesArr) {
                mAcceptedImageNames.add(imageName);
            }

            RecognitionSettings recognitionSettings = extras.getParcelable(EXTRAS_RECOGNITION_SETTINGS);
            if (recognitionSettings == null) {
                recognitionSettings = new RecognitionSettings();
            }

            mRecognizerView.setRecognitionSettings(recognitionSettings);

            RecognizerSettings[] settArr = recognitionSettings.getRecognizerSettingsArray();

            // check that settings array is non-empty
            if (settArr == null || settArr.length == 0) {
                throw new NullPointerException("Recognizer settings array cannot be null nor empty!");
            }
            int nullSettings = 0;
            for (RecognizerSettings sett : settArr) {
                if (sett == null) {
                    ++nullSettings;
                }
            }
            if (nullSettings == settArr.length) {
                throw new NullPointerException("At least one element in recognizer settings array must be non-null!");
            }
        }

        // scan result listener will be notified when scan result gets available
        mRecognizerView.setScanResultListener(this);
        // camera events listener receives events such as when camera preview has started
        // or there was an error while starting the camera
        mRecognizerView.setCameraEventsListener(this);
        // orientation allowed listener is asked if orientation is allowed when device orientation
        // changes - if orientation is allowed, rotatable views will be rotated to that orientation
        mRecognizerView.setOrientationAllowedListener(new OrientationAllowedListener() {
            @Override
            public boolean isOrientationAllowed(Orientation orientation) {
                // allow all orientations
                return true;
            }
        });

        // on size changed listener is notified whenever the size of the view is changed (for example
        // when transforming the view from portrait to landscape or vice versa)
        mRecognizerView.setOnSizeChangedListener(this);

        // define which metadata will be available in MetadataListener (onMetadataAvailable method)
        MetadataSettings metadataSettings = new MetadataSettings();
        // detection metadata should be available in MetadataListener
        // detection metadata are all metadata objects from com.microblink.metadata.detection package
        metadataSettings.setDetectionMetadataAllowed(true);

        if (!mAcceptedImageNames.isEmpty()) {
            // set metadata listener and defined metadata settings
            // metadata listener will obtain selected metadata
            // define which images should be available in MetadataListener
            MetadataSettings.ImageMetadataSettings ims = new MetadataSettings.ImageMetadataSettings();
            // enable dewarped images
            ims.setDewarpedImageEnabled(true);
            metadataSettings.setImageMetadataSettings(ims);
        }

        mRecognizerView.setMetadataListener(this, metadataSettings);

        // set initial orientation
        mRecognizerView.setInitialOrientation(Orientation.ORIENTATION_PORTRAIT);

        // animate rotatable views on top of scanner view
        mRecognizerView.setAnimateRotation(true);

        // set camera aspect mode to FILL - this will use the entire surface
        // for camera preview, instead of letterboxing it
        mRecognizerView.setAspectMode(CameraAspectMode.ASPECT_FILL);

        // instantiate the camera permission manager
        mCameraPermissionManager = new com.microblink.wrapper.xamarin.scan.CameraPermissionManager(this);
        // get the built in layout that should be displayed when camera permission is not given
        View v = mCameraPermissionManager.getAskPermissionOverlay();
        if (v != null) {
            // add it to the current layout that contains the recognizer view
            ViewGroup vg = (ViewGroup) findViewById(R.id.scan_root);
            vg.addView(v);
        }

        // create scanner (make sure scan settings and listeners were set prior calling create)
        mRecognizerView.create();

        // after scanner is created, you can add your views to it

        // create quad view manager and add its quad view as a child of recognizer view
        mQuadViewManager = createQuadViewManager(mRecognizerView);

        mPointSetView = new PointSetView(this, null);
        mRecognizerView.addChildView(mPointSetView, false);

        // initialize buttons and status view
        View view = getLayoutInflater().inflate(R.layout.overlay_blinkid_scan, null);

        /** setup back button */
        mBackButton = (Button) view.findViewById(R.id.defaultBackButton);
        mBackButton.setText(getString(R.string.mbHome));

        mBackButton.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                setResult(Activity.RESULT_CANCELED);
                finish();
            }
        });

        mTorchButton = (Button) view.findViewById(R.id.defaultTorchButton);
        mTorchButton.setVisibility(View.GONE);

        mStatusTextView = (TextView) view.findViewById(R.id.defaultStatusTextView);
        // hide status text
        mStatusTextView.setVisibility(View.INVISIBLE);

        // add buttons and status view as rotatable view to BlinkIdView (it will be rotated even if activity remains in portrait/landscape)
        // allowed orientations are controlled via OrientationAllowedListener
        mRecognizerView.addChildView(view, true);
    }

    @Override
    protected void onResume() {
        super.onResume();
        activityRunning = true;
        // all activity lifecycle events must be passed on to RecognizerView
        if (mRecognizerView != null) {
            mRecognizerView.resume();
        }
        mMediaPlayer = MediaPlayer.create(this, R.raw.beep);
    }

    @Override
    protected void onStart() {
        super.onStart();
        activityRunning = true;
        // all activity lifecycle events must be passed on to RecognizerView
        if (mRecognizerView != null) {
            mRecognizerView.start();
        }
    }

    @Override
    protected void onPause() {
        super.onPause();
        activityRunning = false;
        // all activity lifecycle events must be passed on to RecognizerView
        if (mRecognizerView != null) {
            mRecognizerView.pause();
        }
        if (mMediaPlayer != null) {
            mMediaPlayer = null;
        }
    }

    @Override
    protected void onStop() {
        super.onStop();
        activityRunning = false;
        // all activity lifecycle events must be passed on to RecognizerView
        if (mRecognizerView != null) {
            mRecognizerView.stop();
        }
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        activityRunning = false;
        // all activity lifecycle events must be passed on to RecognizerView
        if (mRecognizerView != null) {
            mRecognizerView.destroy();
        }
    }

    /**
     * Plays beep sound.
     */
    private void soundNotification() {
        if (mMediaPlayer != null) {
            Log.d(TAG, "Playing beep sound");
            mMediaPlayer.start();
            mMediaPlayer.setOnCompletionListener(new MediaPlayer.OnCompletionListener() {

                @Override
                public void onCompletion(MediaPlayer mp) {
                    if (mMediaPlayer == null) {
                        mp.release();
                    }
                }
            });
        }
    }

    @Override
    public void onScanningDone(RecognitionResults results) {
        mRecognizerView.pauseScanning();
        waitForAnimationAndFinish(results);
    }

    private void waitForAnimationAndFinish(final RecognitionResults results) {
        if (mQuadViewManager == null && mPointSetView == null) {
            setResults(results);
            super.finish();
        } else {
            mFinishing = true;
            final Timer timer = new Timer();
            timer.scheduleAtFixedRate(new TimerTask() {
                @Override
                public void run() {
                    if ((mQuadViewManager != null && mQuadViewManager.isAnimationInProgress()) || (mPointSetView != null && mPointSetView.isAnimationInProgress())) {
                        Log.v(BlinkIDScanActivity.this, "Waiting for animations to end...");
                    } else {
                        timer.cancel();
                        setResults(results);
                        BlinkIDScanActivity.this.finish();
                    }

                }
            }, 0, 100);
        }
    }

    private void setResults(RecognitionResults results) {
        BlinkID.getInstance().onScanningDone(results,
                mLastDewarpedImage == null ? null : mLastDewarpedImage.convertToBitmap());
        soundNotification();
    }


    @Override
    public void onCameraPreviewStarted() {
        // this method is called just after camera preview has started
        enableTorchButtonIfPossible();
    }

    @Override
    public void onCameraPreviewStopped() {
        // this method is called just after camera preview has stopped
    }

    private void enableTorchButtonIfPossible() {
        if (mRecognizerView.isCameraTorchSupported() && mTorchButton != null) {
            mTorchButton.setVisibility(View.VISIBLE);
            mTorchButton.setOnClickListener(new View.OnClickListener() {

                @Override
                public void onClick(View v) {
                    mRecognizerView.setTorchState(!mTorchEnabled, new SuccessCallback() {
                        @Override
                        public void onOperationDone(final boolean success) {
                            runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    if (success) {
                                        mTorchEnabled = !mTorchEnabled;
                                        if (mTorchEnabled) {
                                            mTorchButton.setText(R.string.mbLightOn);
                                            mTorchButton.setCompoundDrawablesWithIntrinsicBounds(R.drawable.lighton, 0, 0, 0);
                                        } else {
                                            mTorchButton.setText(R.string.mbLightOff);
                                            mTorchButton.setCompoundDrawablesWithIntrinsicBounds(R.drawable.lightoff, 0, 0, 0);
                                        }
                                    }
                                }
                            });
                        }
                    });
                }
            });
        }
    }


    @Override
    public void onError(Throwable ex) {
        // This method will be called when opening of camera resulted in exception or
        // recognition process encountered an error.
        // The error details will be given in ex parameter.
        Log.e(this, ex, "Error");
        handleError();
    }

    @SuppressWarnings("deprecation")
    private void handleError() {
        if (activityRunning && !mFinishing) {
            AlertDialog alertDialog = new AlertDialog.Builder(this).create();
            alertDialog.setTitle(R.string.error);
            alertDialog.setMessage(getString(R.string.errorDesc));

            alertDialog.setButton(getString(R.string.btnOK), new DialogInterface.OnClickListener() {

                @Override
                public void onClick(DialogInterface dialog, int which) {
                    if (dialog != null) {
                        dialog.dismiss();
                    }
                    setResult(Activity.RESULT_CANCELED, null);
                    finish();
                }
            });
            alertDialog.setCancelable(false);
            alertDialog.show();
        }
    }

    private void displayText(final int textId) {
        mHandler.post(new Runnable() {
            @Override
            public void run() {
                mStatusTextView.setText(textId);
            }
        });
    }

    @Override
    public void onAutofocusFailed() {
        // this method is called if camera cannot perform autofocus
        // this method is called from background (focusing) thread
        // so make sure you post UI actions on UI thread
        displayText(R.string.AutofocusFail);
    }

    @Override
    public void onAutofocusStarted(Rect[] rects) {
        if (rects == null) {
            Log.i(TAG, "Autofocus started with focusing areas being null");
        } else {
            Log.i(TAG, "Autofocus started");
            for (int i = 0; i < rects.length; ++i) {
                Log.d(TAG, "Focus area: " + rects[i].toString());
            }
        }
    }

    @Override
    public void onAutofocusStopped(Rect[] rects) {
        if (rects == null) {
            Log.i(TAG, "Autofocus stopped with focusing areas being null");
        } else {
            Log.i(TAG, "Autofocus stopped");
            for (int i = 0; i < rects.length; ++i) {
                Log.d(TAG, "Focus area: " + rects[i].toString());
            }
        }
    }

    @Override
    public void onSizeChanged(int width, int height) {
        // this is called whenever size of the BlinkIDView changes
        // we will use this callback in this example to adjust the margins of buttons
        int horizontalMargin = (int) (width * 0.07);
        int verticalMargin = (int) (height * 0.07);
        // set margins for back button
        FrameLayout.LayoutParams backButtonParams = (FrameLayout.LayoutParams) mBackButton.getLayoutParams();
        if (backButtonParams.leftMargin != horizontalMargin && backButtonParams.topMargin != verticalMargin) {
            backButtonParams.setMargins(horizontalMargin, verticalMargin, horizontalMargin, verticalMargin);
            mBackButton.setLayoutParams(backButtonParams);
        }
        // set margins for torch button
        FrameLayout.LayoutParams torchButtonParams = (FrameLayout.LayoutParams) mTorchButton.getLayoutParams();
        if (torchButtonParams.leftMargin != horizontalMargin && torchButtonParams.topMargin != verticalMargin) {
            torchButtonParams.setMargins(horizontalMargin, verticalMargin, horizontalMargin, verticalMargin);
            mTorchButton.setLayoutParams(torchButtonParams);
        }
        // set margins for text view
        FrameLayout.LayoutParams statusViewParams = (FrameLayout.LayoutParams) mStatusTextView.getLayoutParams();
        if (statusViewParams.bottomMargin != verticalMargin) {
            if (android.os.Build.VERSION.SDK_INT <= 7) {
                statusViewParams.setMargins(0, verticalMargin, 0, verticalMargin);
            } else {
                statusViewParams.setMargins(horizontalMargin, verticalMargin, horizontalMargin, verticalMargin);
            }
            mStatusTextView.setLayoutParams(statusViewParams);
        }
    }

    /**
     * Displays message about detection status to the user.
     *
     * @param detectionStatus The detection status.
     */
    private void displayDetectionStatus(DetectionStatus detectionStatus) {
        if (detectionStatus == DetectionStatus.SUCCESS) {
            displayText(R.string.Processing);
        } else if (detectionStatus == DetectionStatus.FAIL) {
            displayText(R.string.Align);
        } else if (detectionStatus == DetectionStatus.CAMERA_TOO_HIGH) {
            displayText(R.string.CameraTooHigh);
        } else if (detectionStatus == DetectionStatus.PARTIAL_OBJECT) {
            displayText(R.string.PartialDetected);
        }
    }

    @Override
    public void onMetadataAvailable(Metadata metadata) {
        if (metadata instanceof DetectionMetadata) {
            DetectorResult detectionResult = ((DetectionMetadata) metadata).getDetectionResult();
            if (detectionResult instanceof MultiDetectorResult) {
                DetectorResult[] results = ((MultiDetectorResult) detectionResult).getDetectionResults();
                if (results != null) {
                    for (DetectorResult dr : results) {
                        if (dr != null) {
                            onDetectorResultAvailable(dr);
                        }
                    }
                }
            } else {
                onDetectorResultAvailable(detectionResult);
            }
        } else if (metadata instanceof ImageMetadata) {
            // here we will get dewarped image
            Image img = ((ImageMetadata) metadata).getImage();
            if (img.getImageType() == ImageType.DEWARPED && mAcceptedImageNames.contains(img.getImageName())) {
                mLastDewarpedImage = ((ImageMetadata) metadata).getImage().clone();
            }
        }
    }

    private void onDetectorResultAvailable(DetectorResult detectorResult) {
        // DetectionMetadata contains DetectorResult which is null if object detection
        // has failed and non-null otherwise
        if (detectorResult == null) {
            if (mQuadViewManager != null) {
                mQuadViewManager.animateQuadToDefaultPosition();
            }
            if (mPointSetView != null) {
                mPointSetView.setTransformedPointSet(null);
            }
            displayDetectionStatus(DetectionStatus.FAIL);
        } else if (mPointSetView != null && detectorResult instanceof PointsDetectorResult) {
            List<Point> pointList = ((PointsDetectorResult) detectorResult).getTransformedPointSet().getPoints();
            List<XPoint> xPointList = new ArrayList<>();
            for (Point p : pointList) {
                xPointList.add(new XPoint(p.getX(), p.getY()));
            }
            mPointSetView.setTransformedPointSet(new PointSetWrapper(xPointList));
            displayDetectionStatus(detectorResult.getDetectionStatus());
        } else if (detectorResult instanceof QuadDetectorResult) {
            QuadDetectorResult quadResult = (QuadDetectorResult) detectorResult;
            boolean detectionSuccessful = quadResult.getDetectionStatus() == DetectionStatus.SUCCESS;
            Quadrilateral quad = quadResult.getTransformedDisplayLocation();
            if (mQuadViewManager != null) {
                if (quad == null) {
                    mQuadViewManager.animateQuadToDefaultPosition();
                } else {
                    mQuadViewManager.animateQuadToDetectionPosition(
                            quadToQuadWrapper(quad), detectionSuccessful);
                }
            }
            if (mPointSetView != null) {
                mPointSetView.setTransformedPointSet(null);
            }
            displayDetectionStatus(quadResult.getDetectionStatus());
        }
    }

    @Override
    @TargetApi(23)
    public void onRequestPermissionsResult(int requestCode, String[] permissions, int[] grantResults) {
        // on API level 23, request permission result should be passed to camera permission manager
        mCameraPermissionManager.onRequestPermissionsResult(requestCode, permissions, grantResults);
    }

    @Override
    @TargetApi(23)
    public void onCameraPermissionDenied() {
        // this method is called on Android 6.0 and newer if camera permission was not given
        // by user

        // ask user to give a camera permission. Provided manager asks for
        // permission only if it has not been already granted.
        // on API level < 23, this method does nothing
        mCameraPermissionManager.askForCameraPermission();
    }

    /**
     * Creates the quad view manager and adds its quad view as a child of given {@link RecognizerView}.
     * @param recognizerView Parent of the quad view.
     * @return Created quad view manager.
     */
    private QuadViewManager createQuadViewManager(RecognizerView recognizerView) {
        QuadView qv = new QuadView(recognizerView.getContext(), null, 0.11, 0.11,
                recognizerView.getHostScreenOrientation());
        recognizerView.addChildView(qv, false, 0);
        return new QuadViewManager(qv);
    }


    private QuadrilateralWrapper quadToQuadWrapper(Quadrilateral q) {
        Point ul = q.getUpperLeft();
        Point ur = q.getUpperRight();
        Point ll = q.getLowerLeft();
        Point lr = q.getLowerRight();
        QuadrilateralWrapper qw = new QuadrilateralWrapper(new XPoint(ul.getX(), ul.getY()),
                new XPoint(ur.getX(), ur.getY()), new XPoint(ll.getX(), ll.getY()),
                new XPoint(lr.getX(), lr.getY()));
        qw.setColor(q.getColor());
        qw.setIsDefaultQuad(q.isDefaultQuad());
        return qw;
    }
}
