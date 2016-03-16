package com.microblink.wrapper.xamarin.scan.quadview;

import com.microblink.geometry.Point;
import com.microblink.geometry.Quadrilateral;

/**
 * Created by ivan on 3/16/16.
 */
public class QuadrilateralWrapper{

    private Quadrilateral mQuadrilateral;

    public QuadrilateralWrapper() {
        mQuadrilateral = new Quadrilateral();
    }

    public QuadrilateralWrapper(int top, int bottom, int left, int right, int hostActivityOrientation) {
        mQuadrilateral = new Quadrilateral(top, bottom, left, right, hostActivityOrientation);
    }

    public QuadrilateralWrapper(XPoint uleft, XPoint uright, XPoint lleft, XPoint lright) {
        mQuadrilateral = new Quadrilateral(xPointToPoint(uleft), xPointToPoint(uright),
                xPointToPoint(lleft), xPointToPoint(lright));
    }

    public QuadrilateralWrapper(float uleftx, float ulefty, float urightx, float urighty, float lleftx, float llefty, float lrightx, float lrighty, int uleftIndex) {
        mQuadrilateral = new Quadrilateral(uleftx, ulefty, urightx, urighty, lleftx, llefty, lrightx, lrighty, uleftIndex);
    }

    public QuadrilateralWrapper(XPoint uleft, XPoint uright, XPoint lleft, XPoint lright, int uleftIndex) {
        mQuadrilateral = new Quadrilateral(xPointToPoint(uleft), xPointToPoint(uright),
                xPointToPoint(lleft), xPointToPoint(lright), uleftIndex);
    }

    public void setMargins(int top, int bottom, int left, int right, int hostActivityOrientation) {
        mQuadrilateral.setMargins(top, bottom, left, right, hostActivityOrientation);
    }

    public boolean matchesMargins(int top, int bottom, int left, int right, int hostActivityOrientation) {
        return mQuadrilateral.matchesMargins(top, bottom, left, right, hostActivityOrientation);
    }

    public void setPoints(XPoint uleft, XPoint uright, XPoint lleft, XPoint lright) {
        mQuadrilateral.setPoints(xPointToPoint(uleft), xPointToPoint(uright),
                xPointToPoint(lleft), xPointToPoint(lright));
    }

    @Override
    public String toString() {
        return mQuadrilateral.toString();
    }

    public static QuadrilateralWrapper fromPointsAndCanvasSize(XPoint uleft, XPoint uright, XPoint lleft, XPoint lright, final int canvasWidth, final int canvasHeight, int hostActivityOrientation, boolean mirrorXY) {
        Quadrilateral quad = Quadrilateral.fromPointsAndCanvasSize(xPointToPoint(uleft), xPointToPoint(uright),
                xPointToPoint(lleft), xPointToPoint(lright), canvasWidth, canvasHeight, hostActivityOrientation, mirrorXY);
        QuadrilateralWrapper wrapper = new QuadrilateralWrapper();
        wrapper.mQuadrilateral = quad;
        return wrapper;
    }


    public void mirror(final int canvasWidth, final int canvasHeight, int hostActivityOrientation) {
        mQuadrilateral.mirror(canvasWidth, canvasHeight, hostActivityOrientation);
    }

    public QuadrilateralWrapper sortedQuad() {
        Quadrilateral quad = mQuadrilateral.sortedQuad();
        QuadrilateralWrapper sorted = new QuadrilateralWrapper();
        sorted.mQuadrilateral = quad;
        return sorted;
    }

    public XPoint getUpperLeft() {
        return pointToXpoint(mQuadrilateral.getUpperLeft());
    }

    public XPoint getRealUpperLeft() {
        return pointToXpoint(mQuadrilateral.getRealUpperLeft());
    }

    public XPoint getUpperRight() {
        return pointToXpoint(mQuadrilateral.getUpperRight());
    }

    public XPoint getRealUpperRight() {
        return pointToXpoint(mQuadrilateral.getRealUpperRight());
    }

    public XPoint getLowerLeft() {
        return pointToXpoint(mQuadrilateral.getLowerLeft());
    }

    public XPoint getRealLowerLeft() {
        return pointToXpoint(mQuadrilateral.getRealLowerLeft());
    }

    public XPoint getLowerRight() {
        return pointToXpoint(mQuadrilateral.getLowerRight());
    }

    public XPoint getRealLowerRight() {
        return pointToXpoint(mQuadrilateral.getRealLowerRight());
    }

    public int getColor() {
        return mQuadrilateral.getColor();
    }

    public void setColor(int color) {
        mQuadrilateral.setColor(color);
    }

    public void setRealUpperLeftIndex(int realULeftIndex) {
        mQuadrilateral.setRealUpperLeftIndex(realULeftIndex);
    }

    public int getRealUpperLeftIndex() {
        return mQuadrilateral.getRealUpperLeftIndex();
    }

    public boolean isDefaultQuad() {
        return mQuadrilateral.isDefaultQuad();
    }

    public void setIsDefaultQuad(boolean defaultQuad) {
        mQuadrilateral.setIsDefaultQuad(defaultQuad);
    }

    public QuadrilateralWrapper clone() {
        Quadrilateral quad = mQuadrilateral.clone();
        QuadrilateralWrapper cloned = new QuadrilateralWrapper();
        cloned.mQuadrilateral = quad;
        return cloned;

    }

    private static XPoint pointToXpoint(Point p) {
        return new XPoint(p.getX(), p.getY());
    }

    private static Point xPointToPoint(XPoint xp) {
        return new Point(xp.getX(), xp.getY());
    }

}
