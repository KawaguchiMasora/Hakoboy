using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anime_Move : MonoBehaviour
{
    public Animator mAnimator;
    public SpriteRenderer sprite;
    public Rigidbody2D rbody2D;

    public float moveSpeed;
    public float jumpForce;
    public bool isGround;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            this.rbody2D.AddForce(transform.up * jumpForce);
            mAnimator.SetBool("jump", true);
        }
    }
    void FixedUpdate()
    {
        Vector3 vec = transform.position;
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * moveSpeed;
            sprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * moveSpeed;
            sprite.flipX = true;
        }
        if (vec == transform.position && isGround == true) mAnimator.SetBool("walk", false);
        else mAnimator.SetBool("walk", true);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGround = true;
            mAnimator.SetBool("jump", false);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground")) isGround = false;
    }
}
