using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopperHole : SetNearGrid
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Move>(out var a))
        {
            a.GetComponent<Collider2D>().enabled = false;
        }
    }
}
