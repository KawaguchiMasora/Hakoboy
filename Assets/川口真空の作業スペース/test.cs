using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

<<<<<<< HEAD
=======

>>>>>>> f059bb2f20e6c47ea2db7efaff757a7b44fbed11
    public GameObject objectPrefab; // ��������Prefab��Inspector����ݒ�
    public Transform player; // Player�I�u�W�F�N�g��Inspector����ݒ�

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
        // �X�y�[�X�L�[�������ꂽ��I�u�W�F�N�g����
        if (Input.GetKeyDown(KeyCode.O))
        {
            GenerateObject();
        }
    }

    void GenerateObject()
    {
        // �w�肵��Prefab�𐶐�
        GameObject newObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);

        // ���������I�u�W�F�N�g��Transform���v���C���[��Transform�ɐݒ�
        newObject.transform.SetParent(player);
        newObject.transform.localPosition = Vector3.zero; // �����K�v�Ȃ瑊�Έʒu�𒲐�

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

            // ���������I�u�W�F�N�g�iDeath�I�u�W�F�N�g�j���폜
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
