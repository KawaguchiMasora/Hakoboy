using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplanationArea : MonoBehaviour
{
    public GameObject Explanation;

    // Start is called before the first frame update
    void Start()
    {
        Explanation.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Explanation.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
