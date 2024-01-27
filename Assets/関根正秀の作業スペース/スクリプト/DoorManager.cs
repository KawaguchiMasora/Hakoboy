using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    private Animator anim;
    public string scenename;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�v���C���[���������Ɉ�x�����h�A���J����
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("open");
            Invoke("nextscene", 2);
        }
    }

    private void nextscene()
    {
        SceneManager.LoadScene(scenename);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
