using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField] private Transform _cameraTransform;

    private float _moveSpeed = 5.0f; // �̵� �ӵ�.
    private float _jump = 3.0f; // �ٴ� ��.
    private float _gravity = -9.81f; // �߷� ���.
    private Vector3 _moveDirection; // �̵� ����.

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_characterController.isGrounded == false)
        {
            _moveDirection.y += _gravity * Time.deltaTime;
        }
        _characterController.Move(_moveSpeed * _moveDirection * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        // ī�޶� �ٶ󺸴� ����.
        Vector3 cameraDirection = _cameraTransform.rotation * direction;
        // ���� ��, y�� ���� �߷��� ������ ���� �ʵ��� �ϱ� ���� _moveDirection �� ���.
        _moveDirection = new Vector3(cameraDirection.x, _moveDirection.y, cameraDirection.z);
    }

    public void JumpTo()
    {
        if( _characterController.isGrounded == true)
        {
            _moveDirection.y = _jump;
        }
    }
}
