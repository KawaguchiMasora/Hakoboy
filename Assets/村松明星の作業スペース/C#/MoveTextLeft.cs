using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTextLeft : MonoBehaviour
{
    public float moveSpeed = 500f;

    void Update()
    {
        // テキストを左に移動
        MoveTextLeft2();
        // 一定の条件で時間を停止
        if (ShouldPauseMovement())
        {
            PauseMovement();
        }
    }

    void MoveTextLeft2()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        // テキストの現在の位置を取得
        Vector3 currentPosition = rectTransform.anchoredPosition;

        // テキストを左に移動
        currentPosition.x -= moveSpeed * Time.deltaTime;

        // 新しい位置をセット
        rectTransform.anchoredPosition = currentPosition;
    }

    bool ShouldPauseMovement()
    {
        // 一定の条件で時間を停止する条件を設定（例: 画面左端に到達したとき）
        RectTransform rectTransform = GetComponent<RectTransform>();
        return rectTransform.anchoredPosition.x <= -Screen.width / 0.62;
    }

    void PauseMovement()
    {
        // 時間を停止
        Time.timeScale = 0f;
    }
}
