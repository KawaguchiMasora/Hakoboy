using System;
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
    private InputAction bButtonAction;
    private InputAction yButtonAction;
    private InputAction downArrowAction;
    private InputAction dropBoxAction;

    internal void SetAction(Action p)
    {
        throw new NotImplementedException();
    }

    private InputAction createBoxRAction;
    private InputAction createBoxLAction;
    private InputAction createBoxUpAction;
    private InputAction createBoxDownAction;
    private InputAction retryAction;
    private InputAction deleteAction;
    private bool isConnectionGamePad = true;

    private System.Action<InputAction.CallbackContext> b_action, y_action,darrow_action,drop_action,
        crR_action,crL_action,crU_action,crD_action,retry_action,delete_action;
    void Awake()
    {
        input = GetComponent<PlayerInput>();
        var controllerNames = Input.GetJoystickNames(); //接続されている全てのゲームパッドの名前を取得
        if (controllerNames.Length == 0) isConnectionGamePad = false; //ゲームパッドが接続されていない場合処理を変える
        if (isConnectionGamePad)
        {
            #region 接続された場合のアクション
            bButtonAction = input.actions["B"];
            yButtonAction = input.actions["Y"];
            downArrowAction = input.actions["DownPadArrowR"];
            dropBoxAction = input.actions["PadDropBox"];
            createBoxRAction = input.actions["PadCreateBoxR"];
            createBoxLAction = input.actions["PadCreateBoxL"];
            createBoxUpAction = input.actions["PadCreateBoxUp"];
            createBoxDownAction = input.actions["PadCreateBoxDown"];
            retryAction = input.actions["PadRetry"];
            deleteAction = input.actions["PadDeleteBox"];
            #endregion
        }
        else
        {
            #region 接続されていない場合のアクション
            bButtonAction = input.actions["Space"];
            yButtonAction = input.actions["Shift"];
            downArrowAction = input.actions["DownArrow"];
            dropBoxAction = input.actions["DropBox"];
            createBoxRAction = input.actions["CreateBoxR"];
            createBoxLAction = input.actions["CreateBoxL"];
            createBoxUpAction = input.actions["CreateBoxUp"];
            createBoxDownAction = input.actions["CreateBoxDown"];
            retryAction = input.actions["Retry"];
            deleteAction = input.actions["DeleteBox"];
            #endregion
        }
    }

    void Update()
    {

    }
    public System.Action<InputAction.CallbackContext> SetButtonAction(System.Action action, KeyType type)
    {
        switch (type)
        {
            case KeyType.B:
                b_action += _ => action();
                bButtonAction.performed += b_action;
                break;
            case KeyType.Y:
                y_action += _ => action();
                yButtonAction.performed += y_action;
                break;
            case KeyType.DownArrow:
                darrow_action += _ => action();
                downArrowAction.performed += darrow_action;
                break;
            case KeyType.DropBox:
                drop_action += _ => action();
                dropBoxAction.performed += drop_action;
                break;
            case KeyType.CreateBoxR:
                crR_action += _ => action();
                createBoxRAction.performed += crR_action;
                break;
            case KeyType.CreateBoxL:
                crL_action += _ => action();
                createBoxLAction.performed += crL_action;
                break;
            case KeyType.CreateBoxUp:
                crU_action += _ => action();
                createBoxUpAction.performed += crU_action;
                break;
            case KeyType.CreateBoxDown:
                crD_action += _ => action();
                createBoxDownAction.performed += crD_action;
                break;
            case KeyType.Retry:
                retry_action += _ => action();
                retryAction.performed += retry_action;
                break;
            case KeyType.Delete:
                delete_action += _ => action();
                deleteAction.performed += delete_action;
                break;

        }
        return _ => action();
    }
    public void DeleteAction(System.Action<InputAction.CallbackContext> action, KeyType type)
    {
        switch (type)
        {
            case KeyType.B:
                bButtonAction.performed -= b_action;
                b_action -= action;
                break;
            case KeyType.Y:
                yButtonAction.performed -= y_action;
                y_action -= action;
                break;
            case KeyType.DownArrow:
                downArrowAction.performed -= darrow_action;
                darrow_action -= action;
                break;
            case KeyType.DropBox:
                dropBoxAction.performed -= drop_action;
                drop_action -= action;
                break;
            case KeyType.CreateBoxR:
                createBoxRAction.performed -= crR_action;
                crR_action -= action;
                break;
            case KeyType.CreateBoxL:
                createBoxLAction.performed -= crL_action;
                crL_action -= action;
                break;
            case KeyType.CreateBoxUp:
                createBoxUpAction.performed -= crU_action;
                crU_action -= action;
                break;
            case KeyType.CreateBoxDown:
                createBoxDownAction.performed -= crD_action;
                crD_action -= action;
                break;
            case KeyType.Retry:
                retryAction.performed -= retry_action;
                retry_action -= action;
                break;
            case KeyType.Delete:
                deleteAction.performed -= delete_action;
                delete_action -= action;
                break;
        }
    }
    public bool IsYButtonUp()
    {
        return yButtonAction.WasReleasedThisFrame();
    }
    public bool IsYButtonDown()
    {
        return yButtonAction.WasPressedThisFrame();
    }
    public enum KeyType
    {
        B,
        Y,
        DownArrow,
        DropBox,
        CreateBoxR,
        CreateBoxL,
        CreateBoxUp,
        CreateBoxDown,
        Retry,
        Delete,
    }
    private void OnDestroy()
    {
        bButtonAction.Disable();
        yButtonAction.Disable();
        downArrowAction.Disable();
        dropBoxAction.Disable();
        createBoxRAction.Disable();
        createBoxLAction.Disable();
        createBoxUpAction.Disable();
        createBoxDownAction.Disable();
        retryAction.Disable();
        deleteAction.Disable();
    }
}
