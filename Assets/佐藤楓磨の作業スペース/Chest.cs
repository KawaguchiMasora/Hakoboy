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
        //���łɎ擾���Ă���ꍇ������
        return true;
    }
    public void MoveMent(GameObject target)
    {
        //�V���b�v�ɃA�C�e���ǉ�
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        if (!this.IsEnable()) return;
        MoveMent(collision.gameObject);
    }
}
