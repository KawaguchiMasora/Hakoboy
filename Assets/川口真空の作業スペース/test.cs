using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject objectPrefab; // ��������Prefab��Inspector����ݒ�
    public Transform player; // Player�I�u�W�F�N�g��Inspector����ݒ�

    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.O))
        {
            GenerateObject();
        }
    }

    void GenerateObject()
    {
        // �w�肵��Prefab�𐶐�
        GameObject newObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);

        // ���������I�u�W�F�N�g��Player�I�u�W�F�N�g�̎q�I�u�W�F�N�g�ɐݒ�
        newObject.transform.SetParent(player);
    }
    

}
