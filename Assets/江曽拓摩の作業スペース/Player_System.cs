using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_System : MonoBehaviour
{
    static public bool move_permit = true;//移動可能か否か

    [Header("--- GetComponent ---")]
    [SerializeField] public Rigidbody rb;

    [Header("--- 基本動作 ---")]
    public float jumpforce = 6f;
    public float jump_num = 100;
    public float jump_second = 0.1f;

    public bool isJumping = false;//ジャンプ出来るか否か
    public bool isJumping_running = false;//ジャンプ処理中か否か

    public bool box_standby = false;

    [Tooltip("移動速度")]
    public float walk_speed = 10;
    [Tooltip("空中速度")]
    public float air_speed = 30;

    void Update()
    {
        if (move_permit //移動許可が出されており
        && Input.GetKeyDown(KeyCode.Space) //buttonが押されていて
        && !isJumping_running)//ジャンプ処理が行われていない場合
        {
            if (isJumping && !isJumping_running)
            {
                Debug.Log("ジャンプ");
                StartCoroutine("JunpMove");
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping_running = false;
        }
        if (Input.GetKey(KeyCode.Q)) this.transform.position = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            move_permit = false;
            box_standby = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            move_permit = true;
            box_standby = false;
        }
    }
    void FixedUpdate()
    {
        if (move_permit)
        {
            if (!isJumping)
            {
                float x = Input.GetAxis("Horizontal");
                rb.AddForce(x * air_speed, 0, 0, ForceMode.Impulse);
                rb.velocity = new Vector2(Input.GetAxis("Horizontal"), rb.velocity.y);
            }
            else
            {
                float x = Input.GetAxis("Horizontal");
                rb.AddForce(x * walk_speed, 0, 0, ForceMode.Impulse);
                rb.velocity = new Vector2(Input.GetAxis("Horizontal"), rb.velocity.y);
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ground")) isJumping = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping_running = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground")) isJumping = false;
    }
    IEnumerator JunpMove()
    {
        rb.velocity = Vector3.zero;
        isJumping_running = true;
        float ju_fo = jumpforce;
        for (int i = 0; i <= jump_num && isJumping_running == true; i++)
        {
            if (Input.GetKey(KeyCode.Space) && i == 0)
            {
                rb.AddForce(Vector3.up * (jumpforce), ForceMode.Impulse);
                yield return new WaitForSeconds(jump_second);
            }
            if (Input.GetKey(KeyCode.Space) && i != 0)
            {
                ju_fo = ju_fo / 2f;
                rb.AddForce(Vector3.up * (ju_fo), ForceMode.Impulse);
                yield return new WaitForSeconds(jump_second);
            }
        }
    }
}
