using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded = true;
    private Rigidbody2D rb;

    // デリゲートの宣言
    public delegate void MyDelegate();


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            // Rigidbody2Dがアタッチされていない場合、警告を表示
            Debug.LogWarning("Rigidbody2Dコンポーネントがアタッチされていません。");
        }


        // InputManagerのSetActionにデリゲートを渡す
        InputManager.instnace.SetAction(() => Jump());

    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();//Addフォース
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
