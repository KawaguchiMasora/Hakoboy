using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageArea : MonoBehaviour
{
    //public GameObject Player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Player�����������ۂɎ������X�^�[�g
        if (collision.gameObject.tag == "Player")
        {
            Scene activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.name);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
