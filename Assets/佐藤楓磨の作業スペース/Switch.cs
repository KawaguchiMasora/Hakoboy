using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : SetNearGrid, IGimmikFunction
{
    [SerializeField] private bool iscollision = true;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float distance;
    public bool IsEnable()
    {
        return iscollision;
    }
    public void MoveMent(GameObject obj)
    {
        //“Á‚É“®‚«‚ª‚È‚¢‚Ì‚Å–³‚µ
    }
    private void Update()
    {
        var ray = Physics2D.Raycast(transform.position,transform.up ,distance ,mask);
        Debug.DrawRay(transform.position, new Vector3(0,distance,0), Color.red);
        if(ray.collider == null)
        {
            iscollision = true;
            return;
        }
        iscollision = false;
    }
}
