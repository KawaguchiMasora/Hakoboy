using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
/// <summary>
/// �߂��O���b�h�ɍ��W�����킹��
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
            Debug.LogError("�^�C���}�b�v��ݒ肵�Ă�������");
            return;
        }
        var _trans = transform.position;
        _trans.z = 0;
        var pos = tilemap.GetCellCenterWorld(tilemap.WorldToCell(_trans));
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
        if (GUILayout.Button("�O���b�h�ɍ��킹��"))
        {
            element.SetPosionOFNearGrid();
        }
    }
}
#endif