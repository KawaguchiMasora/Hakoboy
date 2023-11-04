using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{



    public GameObject objectPrefab; // 生成するPrefabをInspectorから設定
    public Transform player; // PlayerオブジェクトをInspectorから設定

    public string deathAnimationName = "Death";
    public Animator animatorDeath;


    void Start()
    {
        animatorDeath = GetComponent<Animator>();
    }


    void Update()
    {
        // スペースキーが押されたらオブジェクト生成
        if (Input.GetKeyDown(KeyCode.O))
        {
            GenerateObject();
        }
    }

    void GenerateObject()
    {
        // 指定したPrefabを生成
        GameObject newObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);

        // 生成したオブジェクトのTransformをプレイヤーのTransformに設定
        newObject.transform.SetParent(player);
        newObject.transform.localPosition = Vector3.zero; // もし必要なら相対位置を調整


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            if (animatorDeath != null)
            {

                animatorDeath.Play(deathAnimationName);

                Debug.Log("Death");
            }

            // 当たったオブジェクト（Deathオブジェクト）を削除
           // Destroy(collision.gameObject);


                animatorDeath.Play(deathAnimationName);

            }
           
           // Destroy(gameObject);
        }
 }