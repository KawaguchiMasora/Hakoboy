using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    [SerializeField] private BoxCollider2D goalCollider;
    [SerializeField] Rigidbody2D rb;
    public string targetTag = "Player";
    public GameObject targetObject;
    bool goalArea = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag) && other.IsTouching(goalCollider))
        {
            goalArea = true;
            Debug.Log("ボックスコライダーの中に入りました");
        }
    }

    void Update()
    {
        if (goalArea && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("ゴールしました");
            rb.velocity = Vector2.zero;

            Move otherScript = targetObject.GetComponent<Move>();
            otherScript.enabled = false;
        }
    }
}
