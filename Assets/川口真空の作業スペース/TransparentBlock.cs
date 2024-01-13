using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentBlock : MonoBehaviour
{
    public Material transparentMaterial;
    private Material defaultMaterial;

    void Start()
    {
        // �I�u�W�F�N�g�̏����}�e���A����ۑ�
        defaultMaterial = GetComponent<Renderer>().material;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 playerPosition = collision.transform.position;
            Vector3 objectPosition = transform.position;

            // �v���C���[�������瓖���������ǂ����𔻒f
            if (playerPosition.y < objectPosition.y)
            {
                // �����瓖�������ꍇ�A�}�e���A���𓧖��ɕύX
                GetComponent<Renderer>().material = transparentMaterial;
            }
            else
            {
                // ���ȊO���瓖�������ꍇ�A�ʂ蔲����
                Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            }
        }
    }

    // �Փ˂��痣�ꂽ�Ƃ��Ɍ��̃}�e���A���ɖ߂�
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Renderer>().material = defaultMaterial;
        }
    }
}
