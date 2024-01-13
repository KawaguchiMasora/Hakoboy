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

    public Vector3 respawnPoint; // ���X�|�[���n�_
    public Vector3 newRespawnPoint;


    [SerializeField] private BoxCollider2D boxCollider;

    public Animator mAnimator;

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

        // ���������������͋󒆂���Ȃ���΃W�����v���Ă悵
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
        if (other.gameObject.CompareTag("Goal")&&Input.GetKeyDown(KeyCode.UpArrow))
        {
            //���O�ŏ�{�^����������S�[��
            Debug.Log("�S�[�����܂���");
            Move otherScript = targetObject.GetComponent<Move>();
            otherScript.enabled = false;
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

    void Boxproduce()
    {

    }
}