using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTextLeft : MonoBehaviour
{
    public float moveSpeed = 500f;

    void Update()
    {
        // �e�L�X�g�����Ɉړ�
        MoveTextLeft2();
        // ���̏����Ŏ��Ԃ��~
        if (ShouldPauseMovement())
        {
            PauseMovement();
        }
    }

    void MoveTextLeft2()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        // �e�L�X�g�̌��݂̈ʒu���擾
        Vector3 currentPosition = rectTransform.anchoredPosition;

        // �e�L�X�g�����Ɉړ�
        currentPosition.x -= moveSpeed * Time.deltaTime;

        // �V�����ʒu���Z�b�g
        rectTransform.anchoredPosition = currentPosition;
    }

    bool ShouldPauseMovement()
    {
        // ���̏����Ŏ��Ԃ��~���������ݒ�i��: ��ʍ��[�ɓ��B�����Ƃ��j
        RectTransform rectTransform = GetComponent<RectTransform>();
        return rectTransform.anchoredPosition.x <= -Screen.width / 0.62;
    }

    void PauseMovement()
    {
        // ���Ԃ��~
        Time.timeScale = 0f;
    }
}
