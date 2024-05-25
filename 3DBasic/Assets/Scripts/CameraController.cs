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
        // ī�޶� ��/�� ȸ��.
        _eulerAngleY += mouseX * _rotateSpeedX;
        // ī�޶� ��/�Ʒ� ȸ��.
        _eulerAngleX -= mouseY * _rotateSpeedY;

        // x�� ȸ�� �� ���� ����.
        _eulerAngleX = ClampAngle(_eulerAngleX, _limitMinX, _limitMaxX);

        // ���� ������Ʈ�� Quaternion ȸ���� ����.
        transform.rotation = Quaternion.Euler(_eulerAngleX, _eulerAngleY, 0);
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        // ������ min <= angle <= max�� �����ϵ��� ���� ����.
        return Mathf.Clamp(angle, min, max);
    }
}
