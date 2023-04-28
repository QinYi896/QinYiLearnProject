using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 controlPoint1;
    public Vector3 controlPoint2;
    public Vector3 endPoint;

    float time = 0;
    private void Update()
    {
       if(time<=1)
        {
            time += 0.001f;
            Vector3 point = CalculateBezierPoint(time, startPoint, controlPoint1, controlPoint2, endPoint);
            transform.position = point;
        }
    }
    // 在当前位置处绘制曲线
    void OnDrawGizmos()
    {
        // 调整绘制的颜色为蓝色
        Gizmos.color = Color.blue;

        // 在场景视图中绘制曲线
        for (float t = 0; t <= 1; t += 0.02f)
        {
            Vector3 point = CalculateBezierPoint(t, startPoint, controlPoint1, controlPoint2, endPoint);
            Gizmos.DrawSphere(point, 0.1f);
        }
    }

    // 计算贝塞尔曲线上的点
    Vector3 CalculateBezierPoint(float t, Vector3 startPoint, Vector3 controlPoint1, Vector3 controlPoint2, Vector3 endPoint)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 point = uuu * startPoint;
        point += 3 * uu * t * controlPoint1;
        point += 3 * u * tt * controlPoint2;
        point += ttt * endPoint;

        return point;
    }
}
