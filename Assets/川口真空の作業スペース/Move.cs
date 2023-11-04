using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded = true;
    public Rigidbody2D rb;

    private bool isControlPressed = false;
    private bool isBPressed = false;

    public GameObject boxPrefab;
    public int maxBoxCount = 5; // 生成できる上限数

    private int generatedBoxCount = 0; // 生成されたボックスの数を追跡

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            rb.sharedMaterial.friction = 100.0f;

            // Rigidbody2Dがアタッチされていない場合、警告を表示
            Debug.LogWarning("Rigidbody2Dコンポーネントがアタッチされていません。");
        }
        // InputManagerのSetActionにデリゲートを渡す
        //まだ何も渡す設定していない

    }

    void Update()
    {
       
        //生成中は動けなくする
        isControlPressed = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
        isBPressed = Input.GetKey(KeyCode.L);

        //箱生成中じゃなければ動いてよし
        if (!isControlPressed && !isBPressed)
        {
            float moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * movementSpeed, rb.velocity.y);
        }

        //箱生成中もしくは空中じゃなければジャンプしてよし
        if (!isControlPressed && !isBPressed && Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if(isControlPressed && isBPressed)
        {
            BoxGeneration();
        }
    }

    void Jump()
    {
        if (rb != null)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void BoxGeneration()
    {
        //ボツ 

        //箱生成処理
        Debug.Log("箱生成中");
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("↑");         
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("→");
            // プレイヤーの位置を取得
            Vector3 playerPosition = transform.position;

            // x軸方向に10上にずらす
            playerPosition.x += 2;

            // 指定したPrefabを生成
            Instantiate(boxPrefab, playerPosition, Quaternion.identity);

            // 生成回数をカウントアップ
            generatedBoxCount++;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("←");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("↓");
        }
    }
}
