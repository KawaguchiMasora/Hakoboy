using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    public float stoppingHeight = 5.0f; // 停止する高さを設定します
    private Rigidbody rb; // 移動を制御するための Rigidbody コンポーネント

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // オブジェクトにアタッチされた Rigidbody を取得します
    }

    void Update()
    {
        // オブジェクトの高さが指定の高さ以下になったら速度をゼロに設定します
        if (transform.position.y <= stoppingHeight)
        {
            rb.velocity = Vector3.zero; // 速度をゼロに設定
            rb.angularVelocity = Vector3.zero; // 角速度もゼロに設定（回転を停止するため）

            // もし移動を停止するだけでなく、オブジェクトを固定したい場合、以下のコメントアウトされた行を使用します
            // rb.isKinematic = true; // 物理演算を無効にする（移動や回転を完全に停止）

            // 必要に応じて他のアクションを追加することができます
            // 例えば、移動停止後の処理や何らかのイベントの発火など
        }
    }
}

