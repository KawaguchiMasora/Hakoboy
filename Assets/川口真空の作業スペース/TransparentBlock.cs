using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentBlock : MonoBehaviour
{
    public Material transparentMaterial;
    private Material defaultMaterial;

    void Start()
    {
        // オブジェクトの初期マテリアルを保存
        defaultMaterial = GetComponent<Renderer>().material;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 playerPosition = collision.transform.position;
            Vector3 objectPosition = transform.position;

            // プレイヤーが下から当たったかどうかを判断
            if (playerPosition.y < objectPosition.y)
            {
                // 下から当たった場合、マテリアルを透明に変更
                GetComponent<Renderer>().material = transparentMaterial;
            }
            else
            {
                // 下以外から当たった場合、通り抜ける
                Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            }
        }
    }

    // 衝突から離れたときに元のマテリアルに戻す
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Renderer>().material = defaultMaterial;
        }
    }
}
