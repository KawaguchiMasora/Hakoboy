using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndStop : MonoBehaviour
{
    public float moveSpeed = 75f;
    public float movementDuration = 5f; // ����������b��

    private float elapsedTime = 0f;
    private bool isMoving = true;

    void Update()
    {
        if (isMoving)
        {
            MoveObject();

            elapsedTime += Time.deltaTime;

            if (elapsedTime >= movementDuration)
            {
                // �w��b���o�ߌ�A�������~����
                isMoving = false;
            }
        }
    }

    void MoveObject()
    {
        // �I�u�W�F�N�g�̌��݂̈ʒu���擾
        Vector3 currentPosition = transform.position;

        // �E���Ɉړ�
        currentPosition.x += moveSpeed * Time.deltaTime;
        currentPosition.y -= moveSpeed * Time.deltaTime;

        // �V�����ʒu���Z�b�g
        transform.position = currentPosition;
    }
}
