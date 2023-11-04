using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDesTest : MonoBehaviour
{
    public string deathAnimationName = "Death"; // 再生するアニメーションの名前を設定
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            // 当たったオブジェクトのタグが "Death" の場合
            if (animator != null)
            {
                // アニメーションを再生
                animator.SetTrigger(deathAnimationName);
            }
        }
    }
}
