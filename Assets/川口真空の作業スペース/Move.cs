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
        //  float horizontalInput = Input.GetAxis("Horizontal");
        //  float verticalInput = Input.GetAxis("Vertical");

        // Vector2 movementForce = new Vector2(horizontalInput, verticalInput) * movementSpeed;
        // rb.AddForce(movementForce);

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

    
    
}