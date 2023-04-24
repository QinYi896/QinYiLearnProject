using NaughtyBezierCurves;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textMove : MonoBehaviour
{
  public  BezierCurve3D curve ;

    // Evaluate a position and rotation along the curve at a given time
    float time = 0f; // In range [0, 1]
    Vector3 position ;
    Quaternion rotation ;

    // Get the length of the curve
    // This operation is not very heavy, but I advise you to cache the length if you are going to use it
    // many times and when you know that the curve won't change at runtime.
    float length ;

    // Other methods
    Vector3 tangent ;
    Vector3 binormal;
    Vector3 normal;

    // Add a key point at the end of the curve
    BezierPoint3D keyPoint ; // via fast method
    bool isRemoved;
    public void Start()
    {
      
    }

    private void Update()
    {
        if(time<=1)
        {
            time += 0.001f;
            position = curve.GetPoint(time);
            rotation = curve.GetRotation(time, Vector3.up);
            transform.position = position;
            transform.rotation = rotation;
        }
      
        ////获取曲线的长度
        ////这个操作不是很繁重，但是如果你要使用它，我建议你缓存长度
        ////当你知道曲线在运行时不会改变。
        //curve.GetApproximateLength();

        //// Other methods
        //tangent = curve.GetTangent(time);
        //binormal = curve.GetBinormal(time, Vector3.up);
        //normal = curve.GetNormal(time, Vector3.up);

        //// Add a key point at the end of the curve
        //keyPoint = curve.AddKeyPoint(); // via fast method
        //keyPoint = curve.AddKeyPointAt(curve.KeyPointsCount); // via specific index

        //// Remove a key point
        //isRemoved = curve.RemoveKeyPointAt(0); // Remove the first key point
        //for (int i = 0; i < curve.KeyPointsCount; i++)
        //{
        //    Debug.Log(curve.KeyPoints[i].Position);
        //    Debug.Log(curve.KeyPoints[i].LeftHandleLocalPosition);
        //    Debug.Log(curve.KeyPoints[i].RightHandleLocalPosition);
        //}
    }
// Foreach all key points

}
