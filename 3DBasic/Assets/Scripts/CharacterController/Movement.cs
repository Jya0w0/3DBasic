using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField] private Transform _cameraTransform;

    private float _moveSpeed = 5.0f; // 이동 속도.
    private float _jump = 3.0f; // 뛰는 힘.
    private float _gravity = -9.81f; // 중력 계수.
    private Vector3 _moveDirection; // 이동 방향.

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
        // 카메라가 바라보는 방향.
        Vector3 cameraDirection = _cameraTransform.rotation * direction;
        // 점프 시, y축 값이 중력의 영향을 받지 않도록 하기 위해 _moveDirection 값 사용.
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
