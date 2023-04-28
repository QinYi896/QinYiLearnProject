using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rota2 : MonoBehaviour
{
    private float rotationSpeed = 50f;
    private float currentRotationSpeed;
    private float targetRotation;
    private bool isRotating = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartRotation();
        }
    }

    private void StartRotation()
    {
        //如果还没有旋转，则启动旋转
        if (!isRotating)
        {
            currentRotationSpeed = rotationSpeed;
            targetRotation = transform.rotation.eulerAngles.y + 90f;
            isRotating = true;
            StartCoroutine(RotateCoroutine());
        }
    }

    private IEnumerator RotateCoroutine()
    {
        float startingRotation = transform.rotation.eulerAngles.y;
        float progress = 0f;

        while (progress <= 1f)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Mathf.Lerp(startingRotation, targetRotation, progress), transform.rotation.eulerAngles.z);
            progress += Time.deltaTime * currentRotationSpeed / 360f;
            currentRotationSpeed = Mathf.Max(0f, currentRotationSpeed - Time.deltaTime * rotationSpeed * 2); // 减缓速度
            yield return null;
        }

        isRotating = false;
        currentRotationSpeed = -currentRotationSpeed; // 取反旋转速度 
        targetRotation = startingRotation; // 目标旋转角度为开始角度
        yield return new WaitForSeconds(0.2f); //稍微暂停一下

        currentRotationSpeed = -currentRotationSpeed;
        isRotating = true;
        StartCoroutine(RotateCoroutine());
    }
}
