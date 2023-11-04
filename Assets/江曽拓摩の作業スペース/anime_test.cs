using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anime_test : MonoBehaviour
{
    public Animator animator;

    [SerializeField] public Rigidbody2D rb;

    public float jumpforce = 6f;
    public float jump_num = 100;
    public float jump_second = 0.1f;

    public bool isJumping = false;//ジャンプ出来るか否か
    public bool isJumping_running = false;//ジャンプ処理中か否か
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("jump", 0);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.position += new Vector3(-0.1f, 0, 0);
            animator.SetFloat("walk", 1);

        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.position += new Vector3(0.1f, 0, 0);
            animator.SetFloat("walk", 1);
        }
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A)) animator.SetFloat("walk", 0);
        if (Input.GetKeyUp(KeyCode.D)) animator.SetFloat("walk", 0);
        if (Input.GetKeyDown(KeyCode.Space) //buttonが押されていて
            && !isJumping_running)//ジャンプ処理が行われていない場合
        {
            if (isJumping && !isJumping_running)
            {
                //StartCoroutine("JunpMove");
                animator.SetFloat("jump", 1);
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping_running = false;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
            //animator.SetFloat("jump", );
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping_running = false;
            animator.SetFloat("jump", 3);
        }
    }
    void Anime_Zero()
    {
        animator.SetFloat("jump", 0);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetFloat("jump", 2);
            isJumping = false;
        }
    }
    IEnumerator JunpMove()
    {
        animator.SetFloat("jump", 2);
        rb.velocity = Vector3.zero;
        isJumping_running = true;
        float ju_fo = jumpforce;
        for (int i = 0; i <= jump_num && isJumping_running == true; i++)
        {
            if (Input.GetKey(KeyCode.Space) && i == 0)
            {
                rb.AddForce(Vector2.up * (jumpforce), ForceMode2D.Impulse);
                yield return new WaitForSeconds(jump_second);
            }
            if (Input.GetKey(KeyCode.Space) && i != 0)
            {
                ju_fo = ju_fo / 2f;
                rb.AddForce(Vector2.up * (ju_fo), ForceMode2D.Impulse);
                yield return new WaitForSeconds(jump_second);
            }
        }
    }
}
