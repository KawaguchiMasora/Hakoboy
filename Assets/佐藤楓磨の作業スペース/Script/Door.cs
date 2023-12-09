using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Door : SetNearGrid, IGimmikFunction, IEventChecker
{
    [SerializeField] private StageData data;
    [SerializeField] private List<ActionElement> actionList;
    private SpriteRenderer sp;
    private SpriteRenderer icon;
    private System.Action<UnityEngine.InputSystem.InputAction.CallbackContext> openAction;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        icon = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        sp.enabled = this.IsEnable();
    }
    public bool IsEnable()
    {
        //フラグによって有効無効切り替え（予定）.
        return true;
    }
    public void MoveMent(GameObject target)
    {
        print("in");
        //移動処理
    }
    public bool IsComplete()
    {
        return data.isClear;
    }
    public IEnumerator EventFunction()
    {
        //仮の内容
        for (int i = 0; i < actionList.Count; i++)
        {
            actionList[i].obj.gameObject.SetActive(actionList[i].isEnable);
        }
        yield return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        openAction += InputManager.instnace.SetButtonAction(() => MoveMent(collision.gameObject), InputManager.KeyType.Y);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        InputManager.instnace.DeleteAction(openAction, InputManager.KeyType.Y);
        openAction -= openAction;
    }
}
[System.Serializable]
public class ActionElement
{
    public SetNearGrid obj;
    public bool isEnable;
}
/// <summary>
/// イベント発生トリガーのオブジェクトのインターフェイス
/// </summary>
public interface IEventChecker
{
    /// <summary>
    /// イベントを発生出来るかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsComplete();

    /// <summary>
    /// イベントの内容
    /// </summary>
    /// <returns></returns>
    public IEnumerator EventFunction();
}
