using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �j�̓���
/// </summary>
public class Needle : SetNearGrid, IGimmikFunction
{
    //�������͂��Ȃ��̂ŏ��true
    public bool IsEnable()
    {
        return true;
    }
    public void MoveMent(GameObject obj)
    {
        if (obj.TryGetComponent<Move>(out var a))
        {
            //�v���C���[�ɑ΂��鏈��
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Player�^�O���t�����I�u�W�F�N�g���G�ꂽ��MoveMent�֐����s
        if (!collision.gameObject.CompareTag("Player")) return;
        MoveMent(collision.gameObject);
    }
}
/// <summary>
/// �M�~�b�N�̖����̃C���^�[�t�F�[�X
/// </summary>
public interface IGimmikFunction
{
    /// <summary>
    ///�L����������
    /// </summary>
    public bool IsEnable();
    /// <summary>
    ///�M�~�b�N�����������̓���
    /// </summary>
    public void MoveMent(GameObject obj);
}