using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//[RequireComponent(typeof(Rigidbody2D))]
public class HacoBoy_Move : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 10f;
    public bool isGrounded = true;
    public bool jumpAfter = false;
    public bool isdeath = false;
    public Rigidbody2D rb;

    public Vector3 respawnPoint; // リスポーン地点
    public Vector3 newRespawnPoint;

    [SerializeField] private GameObject death_effect;
    [SerializeField] private BoxCollider2D boxCollider;

    public Animator mAnimator;
    public SpriteRenderer sr;

    void Awake()
    {
        Debug.Log("Awake");
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        DontDestroyOnLoad(this.gameObject);
        
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
        if (!isdeath)
        {
            float moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * movementSpeed, rb.velocity.y);
            Vector3 vec = transform.position;

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) && isGrounded)
            {

                mAnimator.SetBool("iswalk", true);

                if (Input.GetKey(KeyCode.D)) sr.flipX = false;
                if (Input.GetKey(KeyCode.A)) sr.flipX = true;

            }
            else mAnimator.SetBool("iswalk", false);

            Ray2D downray = new Ray2D(gameObject.transform.position + Vector3.down * 2.3f, Vector3.down);
            RaycastHit2D hit = Physics2D.Raycast(downray.origin, downray.direction, 5);
            if (hit.collider)
            {
                if (Mathf.Round(hit.point.y) == Mathf.Round(gameObject.transform.position.y - 2.3f))
                {
                    if (!isGrounded && jumpAfter)
                    {
                        mAnimator.SetBool("islanding", true);
                        isGrounded = false;
                        jumpAfter = false;
                    }
                }
                else isGrounded = false;
            }
            else isGrounded = false;
            //Debug.DrawRay(downray.origin, downray.direction * 10, UnityEngine.Color.red, 5);

            // 箱生成中もしくは空中じゃなければジャンプしてよし
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded
                && (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle")
                || mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))) Jump();
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) boxCollider.enabled = false;
            else boxCollider.enabled = true;

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Death_Function();
            }
        }
    }
        

    void Jump()
    {
        if (rb != null)
        {
            mAnimator.SetTrigger("isjump");
            mAnimator.SetTrigger("isair");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            jumpAfter = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            mAnimator.SetBool("islanding", true);
        }

        if (collision.gameObject.CompareTag("Death"))
        {
            Debug.Log("デスファンクション");
            Death_Function();
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
    }
    void Death_Function()
    {
        Debug.Log("死亡");
        isdeath = true;
        mAnimator.SetTrigger("isDeath");
        rb.simulated = false;
    }
    void Respawn()
    {
        Debug.Log("リスポーン処理");
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
        rb.simulated = true;
        isdeath = false;
    }
    public void Death_Anime()
    {
        Debug.Log("エフェクト処理");
        Instantiate(death_effect, this.transform.position, Quaternion.identity);
    }
    void Boxproduce()
    {

    }
}
