using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HacoBoy_Move : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 10f;
    public bool isGrounded = true;
    public bool jumpAfter = false;
    public Rigidbody2D rb;

    public Vector3 respawnPoint; // ���X�|�[���n�_
    public Vector3 newRespawnPoint;

    [SerializeField] private GameObject death_effect;
    [SerializeField] private BoxCollider2D boxCollider;

    public Animator mAnimator;
    public SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;

        
        if (rb == null)
        {
            // Rigidbody2D���A�^�b�`����Ă��Ȃ��ꍇ�A�x����\��
            Debug.LogWarning("Rigidbody2D�R���|�[�l���g���A�^�b�`����Ă��܂���B");
        }
        // InputManager��SetAction�Ƀf���Q�[�g��n��
        // �܂������n���ݒ肵�Ă��Ȃ�
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * movementSpeed, rb.velocity.y);
        Vector3 vec = transform.position;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) && isGrounded )
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
        }else isGrounded = false;
        //Debug.DrawRay(downray.origin, downray.direction * 10, UnityEngine.Color.red, 5);
        
        // ���������������͋󒆂���Ȃ���΃W�����v���Ă悵
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded 
            && (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle")
            || mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))) StartCoroutine(Jump());
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) boxCollider.enabled = false;
        else boxCollider.enabled = true;

        if(Input.GetKeyDown(KeyCode.LeftControl)) mAnimator.SetTrigger("isDeath");
    }
        

    IEnumerator Jump()
    {
        if (rb != null)
        {
            mAnimator.SetTrigger("isjump");
            mAnimator.SetTrigger("isair");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            yield return new WaitForSeconds(0.3f);
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
            Debug.Log("����");
            Respawn(); // �v���C���[�����X�|�[��������
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RespawnPos"))
        {
            // �V�������X�|�[���n�_��ݒ�
            newRespawnPoint = other.transform.position;
            Debug.Log("�V�������X�|�[���n�_��ݒ肵�܂���: " + newRespawnPoint);
        }
    }
    void Respawn()
    {
        // �Փ˂����{�b�N�X�R���C�_�[�ŐV�������X�|�[���n�_���ݒ肳��Ă���΁A������g�p���ăv���C���[�����X�|�[��������
        if (newRespawnPoint != Vector3.zero)
        {
            transform.position = newRespawnPoint;
        }
        else
        {
            // �V�������X�|�[���n�_���ݒ肳��Ă��Ȃ��ꍇ�́A�ʏ�̃��X�|�[���n�_�Ƀv���C���[���ړ�������
            transform.position = respawnPoint;
        }
    }
    public void Death_Anime()
    {
        Instantiate(death_effect, this.transform.position, Quaternion.identity);
    }
    void Boxproduce()
    {

    }
}
