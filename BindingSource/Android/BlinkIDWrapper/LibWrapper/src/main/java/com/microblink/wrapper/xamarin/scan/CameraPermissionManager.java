package com.microblink.wrapper.xamarin.scan;

import android.Manifest;
import android.annotation.TargetApi;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.net.Uri;
import android.os.Build;
import android.provider.Settings;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.annotation.UiThread;
import android.view.View;

import com.microblink.wrapper.xamarin.R;

/**
 * Helper class that shows the camera permission screen when user has denied camera permission
 * on Android 6.0+.
 */
public class CameraPermissionManager {
    private static final int PERMISSION_CAMERA_REQUEST_CODE = 69;
    private final static String PREFS_FILE = "CameraPermissionManager.prefs";
    private final static String PREFS_ALREADY_ASKED = "AskedForPermission";

    private Activity mCameraActivity;
    private View mAskPermissionOverlay = null;
    private boolean mRequestIssued = false;

    /**
     * Creates new camera permission manager and attaches it to activity.
     * @param cameraActivity The activity that contains camera view.
     */
    @UiThread
    public CameraPermissionManager(@NonNull Activity cameraActivity) {
        mCameraActivity = cameraActivity;
        if (Build.VERSION.SDK_INT >= 23) {
            mAskPermissionOverlay = mCameraActivity.getLayoutInflater().inflate(R.layout.camera_permission_overlay, null);
            mAskPermissionOverlay.setVisibility(View.GONE);
        }
    }

    private void saveAskedForPermission() {
        SharedPreferences sh = mCameraActivity.getSharedPreferences(PREFS_FILE, Context.MODE_PRIVATE);
        SharedPreferences.Editor editor = sh.edit();
        editor.putBoolean(PREFS_ALREADY_ASKED, true);
        editor.apply();
    }

    private boolean isAlreadyAskedForPermission() {
        SharedPreferences sh = mCameraActivity.getSharedPreferences(PREFS_FILE, Context.MODE_PRIVATE);
        return sh.getBoolean(PREFS_ALREADY_ASKED, false);
    }

    /**
     * Returns the layout that should be displayed when camera permission is not given. You
     * should put this view somewhere in your view hierarchy. The view is initially invisible
     * and will become visible only after calling askForCameraPermission and permission was not
     * given. You can override this layout by providing custom res/layout/camera_permission_overlay.xml.
     * @return View layout that is under control of CameraPermissionManager.
     */
    @Nullable
    @UiThread
    public View getAskPermissionOverlay() {
        return mAskPermissionOverlay;
    }

    /**
     * Returns true if camera permission is available. You should call resume() on RecognizerView only
     * if this method returns true.
     * @return whether or not camera permission is available
     */
    @UiThread
    public boolean hasCameraPermission() {
        if (Build.VERSION.SDK_INT >= 23) {
            return mCameraActivity.checkSelfPermission(Manifest.permission.CAMERA) == PackageManager.PERMISSION_GRANTED;
        } else {
            return true;
        }
    }

    /**
     * Asks the user to give camera permission and displays the layout returned by
     * getAskPermissionOverlay if user denies the permission.
     */
    @UiThread
    public void askForCameraPermission() {
        if (!hasCameraPermission()) {
            showAskPermissionOverlay();
        } else {
            if (mAskPermissionOverlay != null) {
                mAskPermissionOverlay.setVisibility(View.GONE);
            }
        }
    }

    @TargetApi(23)
    @UiThread
    private void requestCameraPermission() {
        if (!mRequestIssued) {
            mCameraActivity.requestPermissions(new String[]{Manifest.permission.CAMERA}, PERMISSION_CAMERA_REQUEST_CODE);
            mRequestIssued = true;
            saveAskedForPermission();
        }
    }

    @TargetApi(23)
    @UiThread
    private void showAskPermissionOverlay() {
        final View button = mAskPermissionOverlay.findViewById(R.id.camera_ask_permission_button);
        if (mCameraActivity.shouldShowRequestPermissionRationale(Manifest.permission.CAMERA)) {
            mAskPermissionOverlay.setVisibility(View.VISIBLE);
            button.setOnClickListener(mAskAgainClickListener);
        } else {
            if (isAlreadyAskedForPermission()) {
                mAskPermissionOverlay.setVisibility(View.VISIBLE);
                button.setOnClickListener(mGoToSettingsClickListener);
            } else {
                mAskPermissionOverlay.setVisibility(View.GONE);
                requestCameraPermission();
            }
        }
    }

    /**
     * This method handles request permission results as given to onRequestPermissionResult callback of Activity.
     * @param requestCode The request code as given to callback method.
     * @param permissions The permissions array.
     * @param grantResults The grant results as given to callback method.
     */
    @TargetApi(23)
    @UiThread
    public void onRequestPermissionsResult(int requestCode, String[] permissions,  int[] grantResults) {
        mRequestIssued = false;
        switch (requestCode) {
            case PERMISSION_CAMERA_REQUEST_CODE: {
                int cmPermIndex;
                boolean cmPermFound = false;
                for (cmPermIndex = 0; cmPermIndex < permissions.length; cmPermIndex++) {
                    if (permissions[cmPermIndex].equals(Manifest.permission.CAMERA)) {
                        cmPermFound = true;
                        break;
                    }
                }
                if (cmPermFound && grantResults[cmPermIndex] == PackageManager.PERMISSION_GRANTED) {
                    mAskPermissionOverlay.setVisibility(View.GONE);
                } else {
                    mAskPermissionOverlay.setVisibility(View.VISIBLE);
                    final View button = mAskPermissionOverlay.findViewById(R.id.camera_ask_permission_button);
                    if (mCameraActivity.shouldShowRequestPermissionRationale(Manifest.permission.CAMERA)) {
                        button.setOnClickListener(mAskAgainClickListener);
                    } else {
                        button.setOnClickListener(mGoToSettingsClickListener);
                    }
                }
            }
        }
    }

    private View.OnClickListener mAskAgainClickListener =  new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            requestCameraPermission();
        }
    };

    private View.OnClickListener mGoToSettingsClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            AlertDialog.Builder ab = new AlertDialog.Builder(mCameraActivity);
            ab.setCancelable(false)
                    .setTitle(R.string.mbWarningTitle)
                    .setMessage(R.string.mbEnablePermissionHelp)
                    .setNeutralButton(R.string.btnOK, new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            dialog.dismiss();
                            mAskPermissionOverlay.setVisibility(View.GONE);
                            mCameraActivity.startActivity(new Intent(Settings.ACTION_APPLICATION_DETAILS_SETTINGS, Uri.parse("package:" + mCameraActivity.getPackageName())));
                        }
                    })
                    .create()
                    .show();
        }
    };
}
