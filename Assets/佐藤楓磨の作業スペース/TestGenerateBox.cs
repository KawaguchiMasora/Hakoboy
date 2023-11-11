using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 箱生成のテスト
/// </summary>
public class TestGenerateBox : MonoBehaviour
{
    [SerializeField] private GameObject box;
    [SerializeField] private float throwPower;
    private Vector3 centerPos;
    private Vector3 spriteSize;
    private int boxCountLimit = 5;
    private int currentBoxCount;
    private List<GameObject> instnacedBoxs = new List<GameObject>();
    private List<GameObject> allparent = new List<GameObject>();
    private float startPlayerSpeed;
    private Move _move;
    private const float MOVE_TIME = 0.3f;
    void Start()
    {
        spriteSize = GetComponent<SpriteRenderer>().bounds.size;
        #region 各キーの設定
        InputManager.instnace.SetButtonAction(() => GenerateBox(angle.down), InputManager.KeyType.CreateBoxDown);
        InputManager.instnace.SetButtonAction(() => GenerateBox(angle.up), InputManager.KeyType.CreateBoxUp);
        InputManager.instnace.SetButtonAction(() => GenerateBox(angle.left), InputManager.KeyType.CreateBoxL);
        InputManager.instnace.SetButtonAction(() => GenerateBox(angle.right), InputManager.KeyType.CreateBoxR);
        InputManager.instnace.SetButtonAction(() => ThrowBox(), InputManager.KeyType.Y);
        InputManager.instnace.SetButtonAction(() => StartCoroutine(MoveCreateBoxEnd()), InputManager.KeyType.B);
        InputManager.instnace.SetButtonAction(() => DropBox(), InputManager.KeyType.DownArrow);
        InputManager.instnace.SetButtonAction(() => DeleteBox(), InputManager.KeyType.Delete);
        #endregion
        _move = GetComponent<Move>();
        startPlayerSpeed = _move.movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.instnace.IsYButtonDown())
        {
            if (instnacedBoxs.Count == 0)
            {
                centerPos = transform.position;
            }
            GetComponent<Move>().movementSpeed = 0;
        }
        if (InputManager.instnace.IsYButtonUp())
        {
            GetComponent<Move>().movementSpeed = startPlayerSpeed;
        }
    }
    private enum angle
    {
        up,
        down,
        right,
        left,
    }
    private void GenerateBox(angle angle)
    {
        if (currentBoxCount >= boxCountLimit) return;
        GameObject instnaceBox = null;
        switch (angle)
        {
            case angle.up:
                instnaceBox = Instantiate(box, centerPos + new Vector3(0, spriteSize.y, 0), Quaternion.identity);
                break;
            case angle.down:
                instnaceBox = Instantiate(box, centerPos + new Vector3(0, -spriteSize.y, 0), Quaternion.identity);
                break;
            case angle.right:
                instnaceBox = Instantiate(box, centerPos + new Vector3(spriteSize.x, 0, 0), Quaternion.identity);
                break;
            case angle.left:
                instnaceBox = Instantiate(box, centerPos + new Vector3(-spriteSize.x, 0, 0), Quaternion.identity);
                break;
        }
        centerPos = instnaceBox.transform.position;
        instnaceBox.transform.localScale = spriteSize;
        currentBoxCount++;
        instnacedBoxs.Add(instnaceBox);
        instnaceBox.transform.SetParent(transform);
    }
    private void ThrowBox()
    {
        if (instnacedBoxs.Count == 0) return;
        var parent = new GameObject("Parent");
        var rb = parent.AddComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        for (int i = 0; i < instnacedBoxs.Count; i++)
        {
            instnacedBoxs[i].transform.SetParent(parent.transform);
        }
        rb.AddForce(new Vector3(1, 1, 0) * throwPower, ForceMode2D.Impulse);
        instnacedBoxs = new List<GameObject>();
        allparent.Add(parent);
    }
    private void DropBox()
    {
        if (instnacedBoxs.Count == 0) return;
        var parent = new GameObject("Parent");
        var rb = parent.AddComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        for (int i = 0; i < instnacedBoxs.Count; i++)
        {
            instnacedBoxs[i].transform.SetParent(parent.transform);
        }
        instnacedBoxs = new List<GameObject>();
        allparent.Add(parent);
    }
    private void DeleteBox()
    {
        for (int i = 0; i < allparent.Count; i++)
        {
            Destroy(allparent[i]);
        }
        allparent = new List<GameObject>();
        currentBoxCount = 0;
    }
    private IEnumerator MoveCreateBoxEnd()
    {
        if (transform.childCount == 0) yield break;
        currentBoxCount = 0;
        var parent = new GameObject("Parent");
        for (int i = 0; i < instnacedBoxs.Count; i++)
        {
            instnacedBoxs[i].transform.SetParent(parent.transform);
        }
        instnacedBoxs = new List<GameObject>();
        _move.rb.isKinematic = true;
        var count = parent.transform.childCount;
        while (count > 0)
        {
            Destroy(parent.transform.GetChild(0).gameObject);
            yield return StartCoroutine(MoveBox(parent.transform.GetChild(0).transform.position, MOVE_TIME));
            count = parent.transform.childCount;
        }
        Destroy(parent);
        _move.rb.isKinematic = false;
    }
    private IEnumerator MoveBox(Vector3 pos, float during)
    {
        float step = 0;
        Vector3 oldPosition = Vector3.zero;
        while (step <= 1f)
        {
            if (oldPosition == Vector3.zero)
                oldPosition = transform.position;
            transform.position = Vector3.Lerp(oldPosition, pos, step);
            step += Time.deltaTime / during;
            yield return null;
        }
    }
}
