using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveAndLoadScene3 : MonoBehaviour
{
    public GameObject movingObject;
    public Text movingText;
    public float objectMoveSpeed = 120f;
    public float objectMoveDuration = 1.2f;
    public float textMoveSpeed = 1200f;
    public float textMoveDuration = 1.65f;
    public string targetSceneName;

    private bool objectMoving = true;
    private bool textMoving = false;
    private float objectElapsedTime = 0f;
    private float textElapsedTime = 0f;

    void Update()
    {
        if (objectMoving)
        {
            //Objectを右上に移動
            movingObject.transform.Translate(Vector3.up * objectMoveSpeed * Time.deltaTime);
            movingObject.transform.Translate(Vector3.right * objectMoveSpeed * Time.deltaTime);
            objectElapsedTime += Time.deltaTime;

            // Objectの移動時間が経過したらTextの移動を開始
            if (objectElapsedTime >= objectMoveDuration)
            {
                objectMoving = false;
                textMoving = true;
            }
        }
        else if (textMoving)
        {
            // Textを左に移動
            movingText.transform.Translate(Vector3.left * textMoveSpeed * Time.deltaTime);
            textElapsedTime += Time.deltaTime;

            // Textの移動時間が経過したらシーンをロード
            if (textElapsedTime >= textMoveDuration)
            {
                textMoving = false;
                LoadTargetScene();
            }
        }
    }

    void LoadTargetScene()
    {
        // 指定されたシーンをロード

    }
}
