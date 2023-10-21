using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
/// <summary>
/// ステージ情報を格納するクラス
/// </summary>
[CreateAssetMenu(fileName = "ScriptableObject",menuName ="StageData")]
public class StageData : ScriptableObject
{
    public string stageName;
    public int stageNameHeight = 20;
    public string stageInfo;
    public int stageInfoHeight = 20;
}
#if UNITY_EDITOR
[CustomEditor(typeof(StageData))]
public class StageDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var element = target as StageData;

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("ステージ名");
        element.stageNameHeight = Mathf.Clamp(EditorGUILayout.IntField("高さ", element.stageNameHeight),30,int.MaxValue);
        EditorGUILayout.EndHorizontal();

        element.stageName = EditorGUILayout.TextArea(element.stageName, GUILayout.Height(element.stageNameHeight));
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("ステージ情報");
        element.stageInfoHeight = Mathf.Clamp(EditorGUILayout.IntField("高さ", element.stageInfoHeight), 30, int.MaxValue);
        EditorGUILayout.EndHorizontal();

        element.stageInfo = EditorGUILayout.TextArea(element.stageInfo, GUILayout.Height(element.stageInfoHeight));
    }
}
#endif
