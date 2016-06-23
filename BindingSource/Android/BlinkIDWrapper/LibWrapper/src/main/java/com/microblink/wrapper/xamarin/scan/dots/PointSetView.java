package com.microblink.wrapper.xamarin.scan.dots;

import android.animation.ArgbEvaluator;
import android.animation.TypeEvaluator;
import android.animation.ValueAnimator;
import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Paint;
import android.graphics.PorterDuff;
import android.graphics.PorterDuffXfermode;
import android.os.Handler;
import android.util.AttributeSet;
import android.util.DisplayMetrics;
import android.view.View;
import android.view.animation.AccelerateDecelerateInterpolator;

import com.microblink.util.Log;
import com.microblink.wrapper.xamarin.R;
import com.microblink.wrapper.xamarin.scan.quadview.XPoint;

import java.util.List;

/**
 * Created by dodo on 29/09/14.
 */
public class PointSetView extends View implements ValueAnimator.AnimatorUpdateListener {

    private static final long kAnimationDuration = 250;

    private Paint mPaint;

    private int mWidth = -1;
    private int mHeight = -1;

    private static int pointRadius = 15; // 15 pixels

    private PointSetWrapper mAppearingPointSet = null; // used for drawing points on QR code detection
    private PointSetWrapper mDisappearingPointSet = null;
    private ValueAnimator mAnimation = null;

    private final Handler mHandler = new Handler();

    private int mTargetColor = -1;
    private int mTargetColorWithAlpha0 = -1;

    private TwoColors mCurrentColors;

    @SuppressWarnings("deprecation")
    public PointSetView(Context context, AttributeSet attrs) {
        super(context, attrs);

        mPaint = new Paint(Paint.ANTI_ALIAS_FLAG);

        DisplayMetrics dm = context.getResources().getDisplayMetrics();
        int frameBorderWidth = (dm.densityDpi + 49) / 50;
        pointRadius = frameBorderWidth * 2;
        mPaint.setStrokeWidth(frameBorderWidth);
        mPaint.setStrokeCap(Paint.Cap.ROUND);
        mPaint.setXfermode(new PorterDuffXfermode(PorterDuff.Mode.SRC));

        mTargetColor = context.getResources().getColor(R.color.recognized_frame);
        mTargetColorWithAlpha0 = (mTargetColor & 0x00FFFFFF);
        mCurrentColors = new TwoColors(0, mTargetColor);

        if (android.os.Build.VERSION.SDK_INT >= 11) {
            setLayerType(View.LAYER_TYPE_SOFTWARE, null);
        }
    }

    @Override
    public void onAnimationUpdate(ValueAnimator animation) {
        mCurrentColors = (TwoColors) animation.getAnimatedValue();
        invalidate();
    }

    public boolean isAnimationInProgress() {
        if (mAnimation != null) {
            return mAnimation.isRunning();
        } else {
            return false;
        }
    }

    public void setTransformedPointSet(PointSetWrapper pointSet) {
        mDisappearingPointSet = mAppearingPointSet;
        if (pointSet != null) {
            mAppearingPointSet = convertToViewCoordinates(pointSet);
        } else {
            mAppearingPointSet = null;
        }
        startAnimation();
    }

    private void startAnimation() {
        mHandler.post(new Runnable() {

            @Override
            public void run() {
                if (mAnimation != null) {
                    mAnimation.cancel();
                }
                mAnimation = ValueAnimator.ofObject(new TwoColorsEvaluator(), new TwoColors(mTargetColorWithAlpha0, mTargetColor), new TwoColors(mTargetColor, mTargetColorWithAlpha0));
                mAnimation.setDuration(kAnimationDuration);
                mAnimation.setInterpolator(new AccelerateDecelerateInterpolator());
                mAnimation.addUpdateListener(PointSetView.this);
                mAnimation.start();
            }
        });
    }

    @Override
    protected void onLayout(boolean changed, int left, int top, int right, int bottom) {
        mWidth = this.getWidth();
        mHeight = this.getHeight();
        Log.v(this, "PointSetView layouting to size: {}x{}", mWidth, mHeight);
    }

    @Override
    protected void onDraw(Canvas canvas) {
        if (mWidth == -1) {
            mWidth = canvas.getWidth();
        }
        if (mHeight == -1) {
            mHeight = canvas.getHeight();
        }

        PointSetWrapper appearingPointSet, disappearingPointSet;

        appearingPointSet = mAppearingPointSet;
        disappearingPointSet = mDisappearingPointSet;

        if (appearingPointSet != null) {
            mPaint.setColor(mCurrentColors.mColor1);
            appearingPointSet.draw(canvas, mPaint, pointRadius);
        }
        if (disappearingPointSet != null) {
            mPaint.setColor(mCurrentColors.mColor2);
            disappearingPointSet.draw(canvas, mPaint, pointRadius);
        }
    }

    private class TwoColors {
        public int mColor1;
        public int mColor2;

        public TwoColors(int color1, int color2) {
            mColor1 = color1;
            mColor2 = color2;
        }
    }

    private class TwoColorsEvaluator implements TypeEvaluator<TwoColors> {

        private ArgbEvaluator mEval = new ArgbEvaluator();

        @Override
        public TwoColors evaluate(float fraction, TwoColors startValue, TwoColors endValue) {
            return new TwoColors(
                ((Integer)mEval.evaluate(fraction, Integer.valueOf(startValue.mColor1), Integer.valueOf(endValue.mColor1))).intValue(),
                ((Integer)mEval.evaluate(fraction, Integer.valueOf(startValue.mColor2), Integer.valueOf(endValue.mColor2))).intValue());
        }
    }

    private PointSetWrapper convertToViewCoordinates(PointSetWrapper unitPs) {
        List<XPoint> points = unitPs.getPoints();
        for (XPoint p : points) {
            float oldX = p.getX();
            float oldY = p.getY();
            p.setX((1.f - oldY) * mWidth);
            p.setY(oldX * mHeight);
        }
        return new PointSetWrapper(points);
    }

}
