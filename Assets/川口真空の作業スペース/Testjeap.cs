using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testjeap : MonoBehaviour
{
    public Rigidbody2D rb;
    public int upForce = 300;
    public float distance = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 rayPosition = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.down, distance);
        Debug.DrawRay(rayPosition, Vector2.down * distance, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null && hit.collider.CompareTag("Ground"))
            {
                rb.AddForce(new Vector2(0, upForce));
            }
        }
    }
}
