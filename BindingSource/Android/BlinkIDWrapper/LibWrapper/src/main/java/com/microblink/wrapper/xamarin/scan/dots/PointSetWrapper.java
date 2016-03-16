package com.microblink.wrapper.xamarin.scan.dots;

import android.graphics.Canvas;
import android.graphics.Paint;
import android.support.annotation.IntRange;
import android.support.annotation.Size;

import com.microblink.geometry.Point;
import com.microblink.geometry.PointSet;
import com.microblink.wrapper.xamarin.scan.quadview.XPoint;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by ivan on 3/16/16.
 */
public class PointSetWrapper {

    private PointSet mPointSet;

    public PointSetWrapper(List<XPoint> points) {
        List<Point> pointsList = new ArrayList<>();
        for (XPoint xp : points) {
            pointsList.add(new Point(xp.getX(), xp.getY()));
        }
        mPointSet = new PointSet(pointsList);
    }

    public PointSetWrapper(@Size(multiple = 2) float[] points, @IntRange(from=1) int width, @IntRange(from=1) int height, int hostActivityOrientation, boolean mirrorXY) {
        mPointSet = new PointSet(points, width, height, hostActivityOrientation, mirrorXY);
    }

    public void mirror(final int canvasWidth, final int canvasHeight, final int hostActivityOrientation) {
        mPointSet.mirror(canvasWidth, canvasHeight, hostActivityOrientation);
    }

    public void draw(Canvas canvas, Paint paint, int pointRadius) {
        mPointSet.draw(canvas, paint, pointRadius);
    }
}
