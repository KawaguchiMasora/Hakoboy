using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anime_Move : MonoBehaviour
{
    public Animator mAnimator;
    public SpriteRenderer sprite;
    public float moveSpeed;
    void Start()
    {
        
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
        if (vec == transform.position) mAnimator.SetBool("walk", false);
        else mAnimator.SetBool("walk", true);
    }
}
