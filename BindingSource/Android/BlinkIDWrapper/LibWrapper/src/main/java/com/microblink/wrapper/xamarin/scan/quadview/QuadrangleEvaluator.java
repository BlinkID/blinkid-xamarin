package com.microblink.wrapper.xamarin.scan.quadview;

import android.animation.ArgbEvaluator;
import android.animation.TypeEvaluator;

public class QuadrangleEvaluator implements TypeEvaluator<QuadrilateralWrapper> {

    private ArgbEvaluator mColorEval = new ArgbEvaluator();
    private QuadrilateralWrapper mCurrentQuad = new QuadrilateralWrapper();

    @Override
    public QuadrilateralWrapper evaluate(float fraction, QuadrilateralWrapper startValue,
                                         QuadrilateralWrapper endValue) {

        int color =
                (Integer) mColorEval.evaluate(fraction, startValue.getColor(), endValue.getColor());

        XPoint ulVec = endValue.getUpperLeft().clone();
        ulVec.operatorMinusEquals(startValue.getUpperLeft()).operatorMultiplyEquals(fraction);
        XPoint urVec = endValue.getUpperRight().clone();
        urVec.operatorMinusEquals(startValue.getUpperRight()).operatorMultiplyEquals(fraction);
        XPoint llVec = endValue.getLowerLeft().clone();
        llVec.operatorMinusEquals(startValue.getLowerLeft()).operatorMultiplyEquals(fraction);
        XPoint lrVec = endValue.getLowerRight().clone();
        lrVec.operatorMinusEquals(startValue.getLowerRight()).operatorMultiplyEquals(fraction);

        mCurrentQuad.setPoints(startValue.getUpperLeft().operatorPlus(ulVec),
                startValue.getUpperRight().operatorPlus(urVec),
                startValue.getLowerLeft().operatorPlus(llVec),
                startValue.getLowerRight().operatorPlus(lrVec));

        mCurrentQuad.setColor(color);
        if (endValue.isDefaultQuad() && (fraction > 0.95 || startValue.isDefaultQuad())) {
            mCurrentQuad.setIsDefaultQuad(true);
        }
        return mCurrentQuad;
    }

}

