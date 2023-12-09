using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookOut : MonoBehaviour
{
    public GameObject LookCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CameraManager CM = LookCamera.GetComponent<CameraManager>();
            CM.Look = false;
        }
    }
}
