package com.microblink.wrapper.xamarin.scan.quadview;

import com.microblink.geometry.Point;
import com.microblink.geometry.Quadrilateral;

/**
 * Created by ivan on 3/16/16.
 */
public class QuadrilateralWrapper {

    private static final double EPS_DISTANCE = 10e-6;
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

    /**
     * Returns true if quadrilateral is empty, i.e. all 4 points are the same.
     * @return true if quadrilateral is empty, i.e. all 4 points are the same.
     */
    public boolean isEmpty() {
        Point upperLeft = mQuadrilateral.getUpperLeft();
        Point upperRight = mQuadrilateral.getUpperRight();
        Point lowerLeft = mQuadrilateral.getLowerLeft();
        Point lowerRight = mQuadrilateral.getLowerRight();
        if (Math.abs(upperLeft.getX() - upperRight.getX()) > EPS_DISTANCE ||
                Math.abs(upperLeft.getX() - lowerLeft.getX()) > EPS_DISTANCE ||
                Math.abs(upperLeft.getX() - lowerRight.getX()) > EPS_DISTANCE) {
            return false;
        }
        if (Math.abs(upperLeft.getY() - upperRight.getY()) > EPS_DISTANCE ||
                Math.abs(upperLeft.getY() - lowerLeft.getY()) > EPS_DISTANCE ||
                Math.abs(upperLeft.getY() - lowerRight.getY()) > EPS_DISTANCE) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return mQuadrilateral.toString();
    }

    public void mirror(final int canvasWidth, final int canvasHeight, int hostActivityOrientation) {
        mQuadrilateral.mirror(canvasWidth, canvasHeight, hostActivityOrientation);
    }

    public QuadrilateralWrapper getSortedQuad() {
        Quadrilateral quad = mQuadrilateral.getSortedQuad();
        QuadrilateralWrapper sorted = new QuadrilateralWrapper();
        sorted.mQuadrilateral = quad;
        return sorted;
    }

    public XPoint getUpperLeft() {
        return pointToXpoint(mQuadrilateral.getUpperLeft());
    }

    public XPoint getUpperRight() {
        return pointToXpoint(mQuadrilateral.getUpperRight());
    }

    public XPoint getLowerLeft() {
        return pointToXpoint(mQuadrilateral.getLowerLeft());
    }

    public XPoint getLowerRight() {
        return pointToXpoint(mQuadrilateral.getLowerRight());
    }

    public int getColor() {
        return mQuadrilateral.getColor();
    }

    public void setColor(int color) {
        mQuadrilateral.setColor(color);
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
