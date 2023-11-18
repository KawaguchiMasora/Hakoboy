using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Door : SetNearGrid, IGimmikFunction
{
    private SpriteRenderer sp;
    private SpriteRenderer icon;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        icon = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        sp.enabled = this.IsEnable();
    }
    public bool IsEnable()
    {
        //フラグによって有効無効切り替え（予定）.
        return true;
    }
    public void MoveMent(GameObject target)
    {
        //移動処理
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        MoveMent(collision.gameObject);
    }
}
