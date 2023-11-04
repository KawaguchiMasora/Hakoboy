using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
/// <summary>
/// 近いグリッドに座標を合わせる
/// </summary>
public class SetNearGrid : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private Vector2 offset;
    public void SetPosionOFNearGrid()
    {
        if (tilemap == null)
        {
            Debug.LogError("タイルマップを設定してください");
            return;
        }
        var _trans = transform.position;
        _trans.z = 0;
        transform.position = _trans;

        List<Vector3> distances = new List<Vector3>();
        for (int x = 0; x < tilemap.size.x; x++)
        {
            for (int y = 0; y < tilemap.size.y; y++)
            {
                try
                {
                    Vector3 complementPos = new Vector3(tilemap.cellSize.x / 2, tilemap.cellSize.y / 2, 0);
                    distances.Add(tilemap.CellToWorld(new Vector3Int(x, y)) + complementPos);
                }
                catch { }
            }
        }
        Vector3 pos = distances.OrderBy(i => (transform.position - i).sqrMagnitude).First();
        pos += new Vector3(offset.x, offset.y, 0);
        transform.position = pos;

    }
}
#if UNITY_EDITOR
[CustomEditor(typeof(SetNearGrid), true)]
public class SetNearEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var element = target as SetNearGrid;
        DrawDefaultInspector();
        if (GUILayout.Button("グリッドに合わせる"))
        {
            element.SetPosionOFNearGrid();
        }
    }
}
#endif