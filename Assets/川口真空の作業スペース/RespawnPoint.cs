using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // �Փ˂����I�u�W�F�N�g��Player�^�O�����ꍇ�A���g���폜����
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // ���g�̃I�u�W�F�N�g���폜����
        }
    }
}
