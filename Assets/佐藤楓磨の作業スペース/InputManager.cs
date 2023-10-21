using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// 操作関連を担当するスクリプト
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
        var controllerNames = Input.GetJoystickNames(); //接続されている全てのゲームパッドの名前を取得
        if (controllerNames.Length == 0) isConnectionGamePad = false; //ゲームパッドが接続されていない場合処理を変える
        if (isConnectionGamePad)
        {
            #region 接続された場合のアクション
            testAction = input.actions["A"];
            #endregion
        }
        else
        {
            #region 接続されていない場合のアクション
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
