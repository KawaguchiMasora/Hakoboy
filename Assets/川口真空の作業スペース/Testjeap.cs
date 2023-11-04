using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testjeap : MonoBehaviour
{
    private Rigidbody2D rb; // Rigidbody2D を使用
    private int upForce;
    private float distance;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D を取得
        upForce = 300;
        distance = 1.0f;
    }

    void Update()
    {
        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.0f, 0.0f);
        RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.down, distance); // Physics2D.Raycast を使用
        Debug.DrawRay(rayPosition, Vector2.down * distance, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null) // Collider2D をチェック
                rb.AddForce(new Vector2(0, upForce)); // 2D ベクトルを使用
        }
    }
}
