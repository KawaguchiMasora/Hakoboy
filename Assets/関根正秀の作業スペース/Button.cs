using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject gimmickWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("èÊÇ¡ÇƒÇÈÅI");
        gimmickWall.transform.position = new Vector3(gimmickWall.transform.position.x, 7, gimmickWall.transform.position.z);
        if (gameObject.tag == "Player")
        {
            Debug.Log("èÊÇ¡ÇƒÇÈÅI");
            gimmickWall.transform.position = new Vector3(gimmickWall.transform.position.x, 7, gimmickWall.transform.position.z);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
