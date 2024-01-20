using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーが来た時に一度だけドアを開ける
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("open");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
