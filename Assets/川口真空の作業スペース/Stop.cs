using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    public float stoppingHeight = 5.0f; // ��~���鍂����ݒ肵�܂�
    private Rigidbody rb; // �ړ��𐧌䂷�邽�߂� Rigidbody �R���|�[�l���g

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // �I�u�W�F�N�g�ɃA�^�b�`���ꂽ Rigidbody ���擾���܂�
    }

    void Update()
    {
        // �I�u�W�F�N�g�̍������w��̍����ȉ��ɂȂ����瑬�x���[���ɐݒ肵�܂�
        if (transform.position.y <= stoppingHeight)
        {
            rb.velocity = Vector3.zero; // ���x���[���ɐݒ�
            rb.angularVelocity = Vector3.zero; // �p���x���[���ɐݒ�i��]���~���邽�߁j

            // �����ړ����~���邾���łȂ��A�I�u�W�F�N�g���Œ肵�����ꍇ�A�ȉ��̃R�����g�A�E�g���ꂽ�s���g�p���܂�
            // rb.isKinematic = true; // �������Z�𖳌��ɂ���i�ړ����]�����S�ɒ�~�j

            // �K�v�ɉ����đ��̃A�N�V������ǉ����邱�Ƃ��ł��܂�
            // �Ⴆ�΁A�ړ���~��̏����≽�炩�̃C�x���g�̔��΂Ȃ�
        }
    }
}

