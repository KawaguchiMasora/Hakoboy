using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTextleft1 : MonoBehaviour
{
    public float moveSpeed = 800f;

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
        return rectTransform.anchoredPosition.x <= -Screen.width / 1;
    }

    void PauseMovement()
    {
        // ���Ԃ��~
        Time.timeScale = 0f;
    }
}
