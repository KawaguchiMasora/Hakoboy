using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突したオブジェクトがPlayerタグを持つ場合、自身を削除する
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // 自身のオブジェクトを削除する
        }
    }
}
