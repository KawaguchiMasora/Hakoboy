using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

<<<<<<< HEAD
=======

>>>>>>> f059bb2f20e6c47ea2db7efaff757a7b44fbed11
    public GameObject objectPrefab; // 生成するPrefabをInspectorから設定
    public Transform player; // PlayerオブジェクトをInspectorから設定

    public string deathAnimationName = "Death";
    public Animator animatorDeath;
<<<<<<< HEAD
=======

>>>>>>> f059bb2f20e6c47ea2db7efaff757a7b44fbed11

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

<<<<<<< HEAD
    }



       
  

=======
       
    }
>>>>>>> f059bb2f20e6c47ea2db7efaff757a7b44fbed11
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            if (animatorDeath != null)
            {

                animatorDeath.Play(deathAnimationName);
<<<<<<< HEAD
                Debug.Log("Death");
            }

            // 当たったオブジェクト（Deathオブジェクト）を削除
           // Destroy(collision.gameObject);


                animatorDeath.Play(deathAnimationName);
=======
>>>>>>> f059bb2f20e6c47ea2db7efaff757a7b44fbed11
            }
           
           // Destroy(gameObject);
        }
    }

<<<<<<< HEAD
=======
}
>>>>>>> f059bb2f20e6c47ea2db7efaff757a7b44fbed11
