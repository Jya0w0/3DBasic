using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_NM : MonoBehaviour
{
    private Movement_NM movement;

    private void Awake()
    {
        movement = GetComponent<Movement_NM>();
    }

    private void Update()
    {
        // ���콺 ���� ��ư�� ������ ��
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            // Camera.main : �±װ� "Camera"�� ������Ʈ = "Main Camera"
            // ī�޶�κ��� ���콺 ��ǥ(Input.mousePosition) ��ġ�� �����ϴ� ���� ����.
            // ray.origin : ������ ���� ��ġ.
            // ray.direction : ������ ���� ����.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Physics.Raycast() : ������ �߻��ؼ� �ε����� ������Ʈ�� ����.(������ �ε����� ������Ʈ�� ������ true ��ȯ)
            // ray.origin ��ġ�κ��� ray.direction �������� ������ ����(Mathf.Infinity)�� ���� �߻�.
            // ������ �ε����� ������Ʈ�� ������ hit�� ����.
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // hit.transform.position : �ε��� ������Ʈ�� ��ġ.
                // hit.point : ������ ������Ʈ�� �ε��� ���� ��ġ.

                // hit.point�� ��ǥ��ġ�� �̵�.
                movement.MoveTo(hit.point);
            }
        }
    }
}
