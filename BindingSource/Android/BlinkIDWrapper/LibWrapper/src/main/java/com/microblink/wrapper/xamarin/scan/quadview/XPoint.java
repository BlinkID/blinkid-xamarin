package com.microblink.wrapper.xamarin.scan.quadview;

import android.graphics.Canvas;
import android.graphics.Paint;
import android.os.Parcel;
import android.os.Parcelable;

import com.microblink.util.Log;

public class XPoint implements Parcelable {
    private float mX;
    private float mY;
    
    private float mNorm = -1.f;
    
    /**
     * Constructor that creates default point at position (0,0).
     */
    public XPoint() {
        mX = 0.f;
        mY = 0.f;
    }
    
    /**
     * Constructor that creates point at position (x,y).
     * @param x x-coordinate of the point
     * @param y y-coordinate of the poing
     */
    public XPoint(float x, float y) {
        mX = x;
        mY = y;
    }

    @Override
    public String toString() {
        return "Point{" +
                "mX=" + mX +
                ", mY=" + mY +
                '}';
    }

    /**
     * Returns true if point has coordinates (0,0).
     * @return true if point has coordinates (0,0).
     */
    public boolean isZero() {
        return mX == 0.f && mY == 0.f;
    }

    /**
     * + operator on the point. Returned point is a new point.
     * For example: c = a + b &lt;==&gt; c = a.operatorPlus(b);
     * @param other Point to be added to current point
     * @return new point that is the result of addition
     */
    public XPoint operatorPlus(XPoint other) {
        float x = this.mX + other.mX;
        float y = this.mY + other.mY;
        return new XPoint(x, y);
    }
    
    /**
     * += operator on the point.
     * For example: b+=a &lt;==&gt; b.operatorPlusEquals(a);
     * @param other Point to be added to current point
     */
    public void operatorPlusEquals(XPoint other) {
        mX+=other.mX;
        mY+=other.mY;
    }
    
    /**
     * - operator on the point. Returned point is a new point.
     * For example: c = a - b &lt;==&gt; c = a.operatorMinus(b);
     * @param other Point to be substracted from current point
     * @return new point that is the result of substraction
     */
    public XPoint operatorMinus(XPoint other) {
        float x = this.mX - other.mX;
        float y = this.mY - other.mY;
        return new XPoint(x, y);
    }

    public XPoint operatorMinusEquals(XPoint other) {
        mX -= other.mX;
        mY -= other.mY;
        return this;
    }
    
    /**
     * Multiplication of the point with scalar. Returned point is a new point.
     * For example: pointC = pointA * scalarB &lt;==&gt; c = a.operatorMultiply(b)
     * @param factor Scalar with which point should be multiplied
     * @return new point that is the result of multiplication
     */
    public XPoint operatorMultiply(float factor) {
        return new XPoint(mX*factor, mY*factor);
    }

    public XPoint operatorMultiplyEquals(float factor) {
        mX *= factor;
        mY *= factor;
        return this;
    }
    
    /**
     * Calculate and return negative of current point. Negative point is point mirrored
     * to current point over (0,0) pivot.
     * @return Negative point.
     */
    public XPoint negativeClone() {
        return new XPoint(-this.mX, -this.mY);
    }

    public XPoint negative() {
        mX = -mX;
        mY = -mY;
        return this;
    }
    
    /**
     * Calculate and return norm of the point. Norm is the distance of the point
     * and point (0,0).
     * @return Norm of the point.
     */
    public float norm() {
        if(mNorm<0) {
            mNorm = (float)Math.sqrt(mX*mX + mY*mY); 
        }
        return mNorm;
    }
    
    /**
     * Calculate and return point that has same direction as this point, but norm 1.
     * @return Unit point.
     */
    public XPoint normalize() {
        float norm = norm();
        return new XPoint(mX/norm, mY/norm);
    }
    
    /**
     * Calculate and return point that has same direction as this point, but norm as given.
     * @param length Desired norm of the point.
     * @return Point with norm "length".
     */
    public XPoint normalize(float length) {
        float norm = norm();
        return new XPoint(mX * length / norm, mY * length / norm);
    }
    
    /**
     * Calculate and return point clamped to given norm (length). If norm of the point is larger
     * than desired length, returns the point that has the same direction as this point, but norm "length".
     * If norm of the point is smaller or equal to desired length, returns the clone of this point.
     * @param length Desired norm to which point should be clamped.
     * @return Clamped point.
     */
    public XPoint clamp(float length) {
        float norm = norm();
        if (norm > length) {
            return normalize(length);
        } else {
            return new XPoint(mX, mY);
        }
    }

    /**
     * Calculate and return point clamped to given norm (lengths). If norm of the point is larger
     * than maxLength, returns the point that has the same direction as this point, but norm "maxLength".
     * If norm of the point is smaller than minLength, returns the point that has the same direction
     * as this point, but norm "minLength".
     * If norm of the point is smaller than maxLength and larger than minLength, returns the clone of this point.
     * @param minLength Minimum desired norm of the point.
     * @param maxLength Maximum desired norm of the point.
     * @return Clamped point.
     */
    public XPoint clamp(float minLength, float maxLength) {
        float norm = norm();
        if (norm > maxLength) {
            return normalize(maxLength);
        } else if (norm < minLength) {
            return normalize(minLength);
        } else {
            return new XPoint(mX, mY);
        }
    }
    
    /**
     * Return point mirrored around X axis.
     * @param maxXDimension Maximum dimension of X axis.
     * @return Mirrored point
     */
    public XPoint mirrorX(float maxXDimension) {
        return new XPoint(maxXDimension-mX, mY);
    }
    
    /**
     * Return point mirrored around Y axis.
     * @param maxYDimension Maximum dimension of Y axis.
     * @return Mirrored point
     */
    public XPoint mirrorY(float maxYDimension) {
        return new XPoint(mX, maxYDimension-mY);
    }
    
    /**
     * Return point mirrored around both X and Y axis
     * @param maxXDimension Maximum dimension of X axis.
     * @param maxYDimension Maximum dimension of Y axis.
     * @return Mirrored point.
     */
    public XPoint mirrorXY(float maxXDimension, float maxYDimension) {
        return new XPoint(maxXDimension-mX, maxYDimension-mY);
    }
    
    @Override
    public XPoint clone() {
        return new XPoint(mX, mY);
    }
    
    @Override
    public boolean equals(Object o) {
        if(o==null)
            return false;
        if(o instanceof XPoint) {
            XPoint p = (XPoint) o;
            return mX==p.mX && mY==p.mY;
        } else
            return false;
    }
    
    /**
     * Calculates and returns the distance to given point.
     * @param other Point to which distance is calculated.
     * @return distance to given point
     */
    public float distance(XPoint other) {
        float xdiff = mX - other.mX;
        float ydiff = mY - other.mY;
        return (float)Math.sqrt(xdiff*xdiff + ydiff*ydiff);
    }
    
    /**
     * Logs the point coordinates to LOG_DEBUG log.
     */
    public void log() {
        Log.d(this, String.format("(%f,%f)", mX, mY));
    }
    
    /**
     * Draws the point to given canvas with given paint. Point is drawn as circle of given radius.
     * @param canvas Canvas to which point should be drawn.
     * @param paint Paint used to draw point.
     * @param pointRadius Radius of the circle that represents the point.
     */
    public void draw(Canvas canvas, Paint paint, int pointRadius) {
        canvas.drawCircle(mX, mY, pointRadius, paint);
    }

    /**
     * @return the x coordinate of the point
     */
    public float getX() {
        return mX;
    }

    /**
     * @return the y coordinate of the point
     */
    public float getY() {
        return mY;
    }

    public void setX(float x) {
        mX = x;
    }

    public void setY(float y) {
        mY = y;
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeFloat(this.mX);
        dest.writeFloat(this.mY);
        dest.writeFloat(this.mNorm);
    }

    protected XPoint(Parcel in) {
        this.mX = in.readFloat();
        this.mY = in.readFloat();
        this.mNorm = in.readFloat();
    }

    public static final Creator<XPoint> CREATOR = new Creator<XPoint>() {
        public XPoint createFromParcel(Parcel source) {
            return new XPoint(source);
        }

        public XPoint[] newArray(int size) {
            return new XPoint[size];
        }
    };
}
