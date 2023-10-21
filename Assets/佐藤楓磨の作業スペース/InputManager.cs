using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// ����֘A��S������X�N���v�g
/// </summary>
[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    private static InputManager _ins;
    public static InputManager instnace
    {
        get
        {
            if (_ins == null)
                _ins = FindObjectOfType<InputManager>();
            return _ins;
        }
    }
    private PlayerInput input;
    private InputAction testAction;
    private bool isConnectionGamePad = true;
    void Start()
    {
        input = GetComponent<PlayerInput>();
        var controllerNames = Input.GetJoystickNames(); //�ڑ�����Ă���S�ẴQ�[���p�b�h�̖��O���擾
        if (controllerNames.Length == 0) isConnectionGamePad = false; //�Q�[���p�b�h���ڑ�����Ă��Ȃ��ꍇ������ς���
        if (isConnectionGamePad)
        {
            #region �ڑ����ꂽ�ꍇ�̃A�N�V����
            testAction = input.actions["A"];
            #endregion
        }
        else
        {
            #region �ڑ�����Ă��Ȃ��ꍇ�̃A�N�V����
            testAction = input.actions["Space"];
            #endregion
        }
        SetAction(() => PrintTest());
    }

    void Update()
    {
        
    }
    private void PrintTest()
    {
        print("Test");
    }
    public void SetAction(System.Action action)
    {
        System.Action<InputAction.CallbackContext> actionA = _ => action();
        testAction.performed += actionA;
    }
}
