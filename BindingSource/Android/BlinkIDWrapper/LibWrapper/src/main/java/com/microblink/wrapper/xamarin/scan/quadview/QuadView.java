/**
 * Copyright (c)2011 MicroBlink Ltd. All rights reserved.
 *
 * ANY UNAUTHORIZED USE OR SALE, DUPLICATION, OR DISTRIBUTION
 * OF THIS PROGRAM OR ANY OF ITS PARTS, IN SOURCE OR BINARY FORMS,
 * WITH OR WITHOUT MODIFICATION, WITH THE PURPOSE OF ACQUIRING
 * UNLAWFUL MATERIAL OR ANY OTHER BENEFIT IS PROHIBITED!
 * THIS PROGRAM IS PROTECTED BY COPYRIGHT LAWS AND YOU MAY NOT
 * REVERSE ENGINEER, DECOMPILE, OR DISASSEMBLE IT.
 */

package com.microblink.wrapper.xamarin.scan.quadview;

import android.animation.Animator;
import android.animation.ValueAnimator;
import android.content.Context;
import android.content.pm.ActivityInfo;
import android.content.res.Resources;
import android.graphics.Canvas;
import android.os.Handler;
import android.util.AttributeSet;
import android.view.View;
import android.view.animation.AccelerateDecelerateInterpolator;

import com.microblink.geometry.Point;
import com.microblink.geometry.Quadrilateral;
import com.microblink.geometry.quadDrawers.QuadrilateralDrawer;
import com.microblink.util.Log;
import com.microblink.view.OnSizeChangedListener;
import com.microblink.wrapper.xamarin.R;

public class QuadView extends View implements ValueAnimator.AnimatorUpdateListener {

    private double mHMargin = 0.11;
    private double mVMargin = 0.11;

    private int mWidth = -1;
    private int mHeight = -1;
    private int mTop = -1, mLeft = -1, mRight = -1, mBottom = -1;

    private long mAnimationDuration = 500;

    private QuadrilateralWrapper mCurrent = new QuadrilateralWrapper();
    private QuadrilateralWrapper mTarget = new QuadrilateralWrapper();
    private QuadrilateralDrawer mQuadDrawer;
    private Resources mResources = null;
    private ValueAnimator mAnimation = null;

    private int mHostActivityOrientation = ActivityInfo.SCREEN_ORIENTATION_PORTRAIT;

    private boolean mMirrored = false;

    private final Handler mHandler = new Handler();

    private boolean mMovableViewfinder = true;

    private OnSizeChangedListener mOnSizeChangedListener;

    private QuadViewAnimationListener mAnimationListener;

    public void setMovable(boolean isMovable) {
        mMovableViewfinder = isMovable;
    }

    public QuadView(Context context, AttributeSet attrs, double horizontalMargin, double verticalMargin, int hostActivityOrientation) {
        super(context, attrs);

        mQuadDrawer = new QuadrilateralDrawer(getContext());
        mQuadDrawer.setLineLengthPerc(0.05f);
        mQuadDrawer.setDesiredLength(54);

        mVMargin = verticalMargin;
        mHMargin = horizontalMargin;

        // Initialize these once for performance rather than calling them every
        // time in onDraw().
        mResources = getResources();
        mHostActivityOrientation = hostActivityOrientation;

        if (!isInEditMode() && android.os.Build.VERSION.SDK_INT >= 11) {
            setLayerType(View.LAYER_TYPE_HARDWARE, mQuadDrawer.getPaint());
        }
    }

    public void setHostActivityOrientation(int hostActivityOrientation) {
        mHostActivityOrientation = hostActivityOrientation;
    }

    public void setMirrored(boolean mirrored) {
        mMirrored = mirrored;
    }

    public boolean isAnimationInProgress() {
        if (mAnimation != null) {
            return mAnimation.isRunning();
        } else {
            return false;
        }
    }

    public void setDefaultTarget() {
        mTarget.setMargins(mTop, mBottom, mLeft, mRight, mHostActivityOrientation);
        mTarget.setIsDefaultQuad(true);
        if(mMirrored) {
            mTarget.mirror(mWidth, mHeight, mHostActivityOrientation);
        }
        if (mTop != mBottom) {
            startAnimation();
        }
    }

    private void startAnimation() {
        mHandler.post(new Runnable() {

            @Override
            public void run() {
                Log.d(QuadView.this, "Starting quad animation");
                if (mAnimation != null) {
                    mAnimation.cancel();
                }
                mAnimation = ValueAnimator.ofObject(new QuadrangleEvaluator(), mCurrent, mTarget);
                mAnimation.setDuration(mAnimationDuration);
                mAnimation.setInterpolator(new AccelerateDecelerateInterpolator());
                mAnimation.addUpdateListener(QuadView.this);
                mAnimation.addListener(mAnimatorListener);
                mAnimation.start();
            }
        });
    }

    public void setAnimationDuration(long animationDuration) {
        mAnimationDuration = animationDuration;
    }

    public void setNewTarget(QuadrilateralWrapper quad) {
        if (mMovableViewfinder) {
            mTarget = transformToViewCoordinates(quad.getSortedQuad());
        } else {
            mTarget = mCurrent.clone();
        }
    }

    @SuppressWarnings("deprecation")
    public void publishDetectionStatus(boolean detectionSuccessful) {
        if (detectionSuccessful) {
            mTarget.setColor(mResources.getColor(R.color.recognized_frame));
        } else {
            mTarget.setColor(mResources.getColor(R.color.default_frame));
        }
        if (mTop != mBottom) {
            startAnimation();
        }
    }

    @Override
    protected void onLayout(boolean changed, int left, int top, int right, int bottom) {
        mWidth = this.getWidth();
        mHeight = this.getHeight();
        Log.d(this, "QuadView layouting to size: {}x{}", mWidth, mHeight);
        if(mOnSizeChangedListener != null) {
            mOnSizeChangedListener.onSizeChanged(mWidth, mHeight);
        }
    }

    public void animateToNewDefault(double hMargin, double vMargin) {
        mHMargin = hMargin;
        mVMargin = vMargin;

        if (mTop != mBottom) {
            // calculate new bounds only if they already exists because
            // mTop != mBottom is check to see whether we can safely
            // initialize animation without NPE (quads are created only
            // after layout, whilst set(Default)Target/publishDetectionStatus
            // or any other animation trigger may happen before
            int effectiveWidth = (int) (mWidth * (1. - mHMargin));
            int effectiveHeight = (int) (mHeight * (1. - mVMargin));

            mTop = (mHeight - effectiveHeight) / 2;
            mLeft = (mWidth - effectiveWidth) / 2;
            mRight = mWidth - mLeft;
            mBottom = mHeight - mTop;

            if(mHostActivityOrientation == ActivityInfo.SCREEN_ORIENTATION_REVERSE_LANDSCAPE || mHostActivityOrientation == ActivityInfo.SCREEN_ORIENTATION_REVERSE_PORTRAIT) {
                int tmp = mTop;
                mTop = mBottom;
                mBottom = tmp;

                tmp = mLeft;
                mLeft = mRight;
                mRight = tmp;
            }

            mTarget.setMargins(mTop, mBottom, mLeft, mRight, mHostActivityOrientation);
            mTarget.setIsDefaultQuad(true);
            if(mMirrored) {
                mTarget.mirror(mWidth, mHeight, mHostActivityOrientation);
            }

            mCurrent.setIsDefaultQuad(false);

            startAnimation();
        }
    }

    @Override
    @SuppressWarnings("deprecation")
    protected void onDraw(Canvas canvas) {
        boolean cornersUnknown = (mBottom <= 0);

        if (mWidth == -1) {
            mWidth = canvas.getWidth();
        }
        if (mHeight == -1) {
            mHeight = canvas.getHeight();
        }

        int effectiveWidth = (int) (mWidth * (1. - mHMargin));
        int effectiveHeight = (int) (mHeight * (1. - mVMargin));

        mTop = (mHeight - effectiveHeight) / 2;
        mLeft = (mWidth - effectiveWidth) / 2;
        mRight = mWidth - mLeft;
        mBottom = mHeight - mTop;

        if(mHostActivityOrientation == ActivityInfo.SCREEN_ORIENTATION_REVERSE_LANDSCAPE || mHostActivityOrientation == ActivityInfo.SCREEN_ORIENTATION_REVERSE_PORTRAIT) {
            int tmp = mTop;
            mTop = mBottom;
            mBottom = tmp;

            tmp = mLeft;
            mLeft = mRight;
            mRight = tmp;
        }

        if (cornersUnknown) {
            mCurrent.setMargins(mTop, mBottom, mLeft, mRight, mHostActivityOrientation);
            mCurrent.setColor(mResources.getColor(R.color.default_frame));
            mCurrent.setIsDefaultQuad(true);
            if(mMirrored) {
                mCurrent.mirror(mWidth, mHeight, mHostActivityOrientation);
            }

            mTarget.setMargins(mTop, mBottom, mLeft, mRight, mHostActivityOrientation);
            mTarget.setColor(mResources.getColor(R.color.default_frame));
            mTarget.setIsDefaultQuad(true);
            if(mMirrored) {
                mTarget.mirror(mWidth, mHeight, mHostActivityOrientation);
            }
        } else if(mCurrent.isDefaultQuad() && !mCurrent.matchesMargins(mTop, mBottom, mLeft, mRight, mHostActivityOrientation)) {
            mCurrent.setMargins(mTop, mBottom, mLeft, mRight, mHostActivityOrientation);
            mCurrent.setColor(mResources.getColor(R.color.default_frame));
            mCurrent.setIsDefaultQuad(true);
            if(mMirrored) {
                mCurrent.mirror(mWidth, mHeight, mHostActivityOrientation);
            }

            mTarget.setMargins(mTop, mBottom, mLeft, mRight, mHostActivityOrientation);
            mTarget.setColor(mResources.getColor(R.color.default_frame));
            mTarget.setIsDefaultQuad(true);
            if(mMirrored) {
                mTarget.mirror(mWidth, mHeight, mHostActivityOrientation);
            }
        }

        mQuadDrawer.drawQuad(quadWrapperToQuad(mCurrent), canvas);
    }

    @Override
    public void onAnimationUpdate(ValueAnimator animation) {
        mCurrent = (QuadrilateralWrapper) animation.getAnimatedValue();
        invalidate();
    }

    private Animator.AnimatorListener mAnimatorListener = new Animator.AnimatorListener() {
        @Override
        public void onAnimationStart(Animator animation) {
            if (mAnimationListener != null) {
                mAnimationListener.onAnimationStart();
            }
        }

        @Override
        public void onAnimationEnd(Animator animation) {
            if (mAnimationListener != null) {
                mAnimationListener.onAnimationEnd();
            }
        }

        @Override
        public void onAnimationCancel(Animator animation) {
            if (mAnimationListener != null) {
                mAnimationListener.onAnimationEnd();
            }
        }

        @Override
        public void onAnimationRepeat(Animator animation) {
            if (mAnimationListener != null) {
                mAnimationListener.onAnimationEnd();
                mAnimationListener.onAnimationStart();
            }
        }
    };

    private Quadrilateral quadWrapperToQuad(QuadrilateralWrapper qw) {
        XPoint ul = qw.getUpperLeft();
        XPoint ur = qw.getUpperRight();
        XPoint ll = qw.getLowerLeft();
        XPoint lr = qw.getLowerRight();
        Quadrilateral quadrilateral = new Quadrilateral(new Point(ul.getX(), ul.getY()),
                new Point(ur.getX(), ur.getY()), new Point(ll.getX(), ll.getY()),
                new Point(lr.getX(), lr.getY()));
        quadrilateral.setColor(qw.getColor());
        quadrilateral.setIsDefaultQuad(qw.isDefaultQuad());
        return quadrilateral;
    }

    private QuadrilateralWrapper transformToViewCoordinates(QuadrilateralWrapper unitQuad) {
        Log.i(com.microblink.view.viewfinder.quadview.QuadViewManager.class, "Building quad from unit quad {} and view size ({}x{}) in host activity orientation {}.", unitQuad, mWidth, mHeight, mHostActivityOrientation);
        // the points should already be corrected for mirror by transformation matrix
        XPoint uleft = unitQuad.getUpperLeft();
        XPoint uright = unitQuad.getUpperRight();
        XPoint lleft = unitQuad.getLowerLeft();
        XPoint lright = unitQuad.getLowerRight();

        return new QuadrilateralWrapper(
                new XPoint((1.f - uleft.getY()) * mWidth, uleft.getX() * mHeight),
                new XPoint((1.f - uright.getY()) * mWidth, uright.getX() * mHeight),
                new XPoint((1.f - lleft.getY()) * mWidth, lleft.getX() * mHeight),
                new XPoint((1.f - lright.getY()) * mWidth, lright.getX() * mHeight));
    }
}
