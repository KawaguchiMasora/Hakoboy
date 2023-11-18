using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : SetNearGrid,IGimmikFunction
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public bool IsEnable()
    {
        //すでに取得している場合無効化
        return true;
    }
    public void MoveMent(GameObject target)
    {
        //ショップにアイテム追加
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        if (!this.IsEnable()) return;
        MoveMent(collision.gameObject);
    }
}
