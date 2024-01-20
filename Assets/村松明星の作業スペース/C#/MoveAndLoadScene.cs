using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveAndLoadScene : MonoBehaviour
{
    public GameObject movingObject;
    public Text movingText;
    public float objectMoveSpeed = 78f;
    public float objectMoveDuration = 2f;
    public float textMoveSpeed = 650f;
    public float textMoveDuration = 3f;
    public string targetSceneName;

    private bool objectMoving = true;
    private bool textMoving = false;
    private float objectElapsedTime = 0f;
    private float textElapsedTime = 0f;

    void Update()
    {
        if (objectMoving)
        {
            // Object���E���Ɉړ�
            movingObject.transform.Translate(Vector3.down * objectMoveSpeed * Time.deltaTime);
            movingObject.transform.Translate(Vector3.right * objectMoveSpeed * Time.deltaTime);
            objectElapsedTime += Time.deltaTime;

            // Object�̈ړ����Ԃ��o�߂�����Text�̈ړ����J�n
            if (objectElapsedTime >= objectMoveDuration)
            {
                objectMoving = false;
                textMoving = true;
            }
        }
        else if (textMoving)
        {
            // Text�����Ɉړ�
            movingText.transform.Translate(Vector3.left * textMoveSpeed * Time.deltaTime);
            textElapsedTime += Time.deltaTime;

            // Text�̈ړ����Ԃ��o�߂�����V�[�������[�h
            if (textElapsedTime >= textMoveDuration)
            {
                textMoving = false;
                LoadTargetScene();
            }
        }
    }

    void LoadTargetScene()
    {
        // �w�肳�ꂽ�V�[�������[�h
        
    }
}
