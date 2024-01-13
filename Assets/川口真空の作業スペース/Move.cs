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
    public GameObject targetObject;

    public Vector3 respawnPoint; // リスポーン地点
    public Vector3 newRespawnPoint;


    [SerializeField] private BoxCollider2D boxCollider;

    public Animator mAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;

        if (rb == null)
        {
            // Rigidbody2Dがアタッチされていない場合、警告を表示
            Debug.LogWarning("Rigidbody2Dコンポーネントがアタッチされていません。");
        }
        // InputManagerのSetActionにデリゲートを渡す
        // まだ何も渡す設定していない
    }

    void Update()
    {
            float moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * movementSpeed, rb.velocity.y);
            Vector3 vec = transform.position;

        // 箱生成中もしくは空中じゃなければジャンプしてよし
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
           // mAnimator.SetBool("jump", true);
        }
        else
        {
            //mAnimator.SetBool("jump", false);
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            boxCollider.enabled = false;
        }
        else
        {
            boxCollider.enabled = true;
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

        if (collision.gameObject.CompareTag("Death"))
        {
            Debug.Log("死んだ");
            Respawn(); // プレイヤーをリスポーンさせる
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RespawnPos"))
        {
            // 新しいリスポーン地点を設定
            newRespawnPoint = other.transform.position;
            Debug.Log("新しいリスポーン地点を設定しました: " + newRespawnPoint);
        }
        if (other.gameObject.CompareTag("Goal")&&Input.GetKeyDown(KeyCode.UpArrow))
        {
            //扉前で上ボタン押したらゴール
            Debug.Log("ゴールしました");
            Move otherScript = targetObject.GetComponent<Move>();
            otherScript.enabled = false;
        }
    }
    void Respawn()
    {
        // 衝突したボックスコライダーで新しいリスポーン地点が設定されていれば、それを使用してプレイヤーをリスポーンさせる
        if (newRespawnPoint != Vector3.zero)
        {
            transform.position = newRespawnPoint;
        }
        else
        {
            // 新しいリスポーン地点が設定されていない場合は、通常のリスポーン地点にプレイヤーを移動させる
            transform.position = respawnPoint;
        }
    }

    void Boxproduce()
    {

    }
}