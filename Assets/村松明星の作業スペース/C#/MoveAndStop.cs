using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndStop : MonoBehaviour
{
    public float moveSpeed = 75f;
    public float movementDuration = 5f; // 動き続ける秒数

    private float elapsedTime = 0f;
    private bool isMoving = true;

    void Update()
    {
        if (isMoving)
        {
            MoveObject();

            elapsedTime += Time.deltaTime;

            if (elapsedTime >= movementDuration)
            {
                // 指定秒数経過後、動きを停止する
                isMoving = false;
            }
        }
    }

    void MoveObject()
    {
        // オブジェクトの現在の位置を取得
        Vector3 currentPosition = transform.position;

        // 右下に移動
        currentPosition.x += moveSpeed * Time.deltaTime;
        currentPosition.y -= moveSpeed * Time.deltaTime;

        // 新しい位置をセット
        transform.position = currentPosition;
    }
}
