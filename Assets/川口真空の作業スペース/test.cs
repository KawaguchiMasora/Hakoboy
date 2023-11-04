using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject objectPrefab; // 生成するPrefabをInspectorから設定
    public Transform player; // PlayerオブジェクトをInspectorから設定

    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.O))
        {
            GenerateObject();
        }
    }

    void GenerateObject()
    {
        // 指定したPrefabを生成
        GameObject newObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);

        // 生成したオブジェクトをPlayerオブジェクトの子オブジェクトに設定
        newObject.transform.SetParent(player);
    }
    

}
