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
    // �ڵ�ǰλ�ô���������
    void OnDrawGizmos()
    {
        // �������Ƶ���ɫΪ��ɫ
        Gizmos.color = Color.blue;

        // �ڳ�����ͼ�л�������
        for (float t = 0; t <= 1; t += 0.02f)
        {
            Vector3 point = CalculateBezierPoint(t, startPoint, controlPoint1, controlPoint2, endPoint);
            Gizmos.DrawSphere(point, 0.1f);
        }
    }

    // ���㱴���������ϵĵ�
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
