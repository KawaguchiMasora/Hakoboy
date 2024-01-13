using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private Animator anim;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("open", true);
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                anim.SetBool("open", false);
                timer = 0;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
