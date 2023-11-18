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
        //�t���O�ɂ���ėL�������؂�ւ��i�\��j.
        return true;
    }
    public void MoveMent(GameObject target)
    {
        //�ړ�����
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        MoveMent(collision.gameObject);
    }
}
