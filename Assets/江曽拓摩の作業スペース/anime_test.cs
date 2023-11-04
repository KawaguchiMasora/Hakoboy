using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anime_test : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
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
    }
}
