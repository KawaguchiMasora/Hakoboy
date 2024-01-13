using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    public GameObject targetObject;
    public string targetTag = "Player";
    [SerializeField] Rigidbody2D rb;

    bool Goalarea = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Goalarea = true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("ÉSÅ[ÉãÇµÇ‹ÇµÇΩ");
            Move otherScript = targetObject.GetComponent<Move>();
            otherScript.enabled = false;
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Goalarea = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Goalarea = false;
        }
    }
}
