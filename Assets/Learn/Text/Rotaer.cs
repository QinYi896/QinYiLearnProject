using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotaer : MonoBehaviour
{
    public float rotateSpeed = 5.0f;
    public float rotateDeceleration = 5.0f;

    private bool isRotating = false;
    private Quaternion startRotation;
    private Quaternion endRotation;
    private float totalTime;
    private float currentTime;

   public Vector3 tarRota;
    private Quaternion tarQua;
    private void OnEnable()
    {
        tarQua = Quaternion.Euler(tarRota);
        StartRotate(tarQua, 4);
    }
    // ��ʼ��ת
    public void StartRotate(Quaternion targetRotation, float timeToRotate)
    {
        isRotating = true;
        startRotation = transform.rotation;
        endRotation = targetRotation;
        totalTime = timeToRotate;
        currentTime = 0.0f;
    }

    private void Update()
    {
        if (isRotating)
        {
            // ���㵱ǰ��ת�Ƕ�
            float currentAngle = Mathf.Lerp(0.0f, 1.0f, currentTime / totalTime);
            currentAngle = Mathf.SmoothStep(0.0f, 1.0f, currentAngle);

            // ������ת�ٶȺͷ���
            float currentSpeed = Mathf.Lerp(rotateSpeed, 0.0f, currentAngle) * Time.deltaTime;
            Quaternion currentRotation = Quaternion.Lerp(startRotation, endRotation, currentAngle);

            // Ӧ����ת
            transform.rotation = currentRotation;

            // ����ʱ��
            currentTime += Time.deltaTime;

            // �����ת����
            if (currentTime >= totalTime)
            {
                Debug.Log("currentSpeed:"+currentSpeed);
                isRotating = false;
                StartCoroutine(ApplyInertia(currentSpeed, currentRotation));
            }
        }
    }

    // ���㷴����ת����
    private IEnumerator ApplyInertia(float currentSpeed, Quaternion currentRotation)
    {
        while (currentSpeed > 0.0f)
        {
            currentSpeed -= rotateDeceleration * Time.deltaTime;
            Quaternion inertiaRotation = Quaternion.AngleAxis(currentSpeed, -transform.forward);
            transform.rotation = inertiaRotation * currentRotation;
            yield return null;
        }
    }
}
