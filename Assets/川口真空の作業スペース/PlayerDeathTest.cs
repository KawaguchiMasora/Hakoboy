using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDesTest : MonoBehaviour
{
    public string deathAnimationName = "Death"; // �Đ�����A�j���[�V�����̖��O��ݒ�
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            // ���������I�u�W�F�N�g�̃^�O�� "Death" �̏ꍇ
            if (animator != null)
            {
                // �A�j���[�V�������Đ�
                animator.SetTrigger(deathAnimationName);
            }
        }
    }
}
