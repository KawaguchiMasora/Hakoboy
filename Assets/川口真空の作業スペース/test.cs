using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{



    public GameObject objectPrefab; // ��������Prefab��Inspector����ݒ�
    public Transform player; // Player�I�u�W�F�N�g��Inspector����ݒ�

    public string deathAnimationName = "Death";
    public Animator animatorDeath;


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

            // ���������I�u�W�F�N�g�iDeath�I�u�W�F�N�g�j���폜
           // Destroy(collision.gameObject);


                animatorDeath.Play(deathAnimationName);

            }
           
           // Destroy(gameObject);
        }
 }