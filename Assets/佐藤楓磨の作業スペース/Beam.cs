using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class Beam : SetNearGrid, IGimmikFunction
{
    [SerializeField]
    private float beamRadius;
    [SerializeField]
    private Switch switchObj;
    [SerializeField]
    private LineRenderer lineRenderer;
    private LineRenderer _renderer;
    private Vector3[] pos = new Vector3[2];
    [ContextMenu("SetUp")]
    private void SetUp()
    {
        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer‚ÌPrefab‚ğİ’è‚µ‚Ä‚­‚¾‚³‚¢");
            return;
        }
        _renderer = Instantiate(lineRenderer, transform.position, Quaternion.identity);
        _renderer.transform.transform.SetParent(transform);
        pos[0] = new Vector3(0, 0, 0.1f);
    }
    public bool IsEnable()
    {
        if (switchObj == null) return true;
        return switchObj.IsEnable();
    }
    public void MoveMent(GameObject obj)
    {
        if (obj.TryGetComponent<Move>(out var a))
        {
            //ƒvƒŒƒCƒ„[‚Ö‚Ìˆ—
        }
    }
    private void Update()
    {

        if (!IsEnable())
        {
            if(transform.childCount != 0)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }
            return;
        }
        if (_renderer == null) SetUp();
        var ray = Physics2D.CircleCast(transform.position, beamRadius, transform.up * 10000);
        Debug.DrawRay(transform.position, transform.up, Color.yellow);
        if (ray.collider == null)
        {
            pos[1] = new Vector3(0, 10000, 0);
            _renderer.SetPositions(pos);
            return;
        }
        pos[1] = new Vector3(0, ray.point.y - transform.position.y, 0);
        _renderer.SetPositions(pos);
        if (!ray.collider.gameObject.CompareTag("Player")) return;
        MoveMent(ray.collider.gameObject);
    }
}
