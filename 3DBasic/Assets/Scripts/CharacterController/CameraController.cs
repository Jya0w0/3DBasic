using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float _rotateSpeedX = 3;
    private float _rotateSpeedY = 5;
    private float _limitMinX = -80;
    private float _limitMaxX = 50;
    private float _eulerAngleX;
    private float _eulerAngleY;

    public void RotateTo(float mouseX, float mouseY)
    {
        // 카메라 좌/우 회전.
        _eulerAngleY += mouseX * _rotateSpeedX;
        // 카메라 위/아래 회전.
        _eulerAngleX -= mouseY * _rotateSpeedY;

        // x축 회전 값 제한 각도.
        _eulerAngleX = ClampAngle(_eulerAngleX, _limitMinX, _limitMaxX);

        // 실제 오브젝트의 Quaternion 회전에 적용.
        transform.rotation = Quaternion.Euler(_eulerAngleX, _eulerAngleY, 0);
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        // 각도가 min <= angle <= max을 유지하도록 범위 제한.
        return Mathf.Clamp(angle, min, max);
    }
}
