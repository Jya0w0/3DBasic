using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement _movement;
    [SerializeField] private CameraController _cameraController;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        // x, z ���� �̵�.
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        _movement.MoveTo(new Vector3(x, 0, z));

        // ����.
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _movement.JumpTo();
        }

        // ���콺 ��/��/��/�Ʒ�.
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        _cameraController.RotateTo(mouseX, mouseY);
    }
}
