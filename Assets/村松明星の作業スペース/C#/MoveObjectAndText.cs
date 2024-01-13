using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveObjectAndText : MonoBehaviour
{
    public GameObject movingObject;
    public Text textObject;
    public float objectMoveSpeed = 75f;
    public float textMoveSpeed = 100f;
    public float objectMovementDuration = 5f;

    private bool isObjectMoving = true;

    private void Update()
    {
        if (isObjectMoving)
        {
            MoveObject();
        }
        else
        {
            MoveText();
        }
    }

    void MoveObject()
    {
        //objectを右下に移動
        Vector3 currentPosition = movingObject.transform.position;
        currentPosition.x += objectMoveSpeed * Time.deltaTime;
        currentPosition.y -= objectMoveSpeed * Time.deltaTime;
        movingObject.transform.position = currentPosition;

        objectMovementDuration -= Time.deltaTime;

        //Objectの動きを止め、Textの動きを開始
        if(objectMovementDuration <= 0f)
        {
            isObjectMoving = false;
        }
    }

    void MoveText()
    {
        //Textを左に移動
        RectTransform rectTransform = textObject.GetComponent<RectTransform>();
        Vector3 currentPosition = rectTransform.anchoredPosition;
        currentPosition.x -= textMoveSpeed * Time.deltaTime;
        rectTransform.anchoredPosition = currentPosition;
    }
}
