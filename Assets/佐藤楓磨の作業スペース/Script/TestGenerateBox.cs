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
    private int boxCountLimit = 5;
    private int currentBoxCount;
    private List<GameObject> instnacedBoxs = new List<GameObject>();
    private List<GameObject> allparent = new List<GameObject>();
    private float startPlayerSpeed;
    private HacoBoy_Move _move;
    private const float MOVE_TIME = 0.3f;
    private const float RAY_RADIUS = 0.5f;
    private readonly Vector3 INSTANCE_BOX_OFFSET = new Vector3(0.2f, -1f, 0);
    private const string GROUND_TAG_NAME = "Ground";
    void Start()
    {
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
       _move = GetComponent<HacoBoy_Move>();
        startPlayerSpeed = _move.movementSpeed;
    }
    private void OnEnable()
    {
        instnacedBoxs = new List<GameObject>();
    }
    // Update is called once per frame
    void Update()
    {
        if (InputManager.instnace.IsYButtonDown())
        {
            if (instnacedBoxs.Count == 0)
            {
                centerPos = transform.position + INSTANCE_BOX_OFFSET;
            }
            GetComponent<HacoBoy_Move>().movementSpeed = 0;
        }
        if (InputManager.instnace.IsYButtonUp())
        {
            GetComponent<HacoBoy_Move>().movementSpeed = startPlayerSpeed;
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
                var upRay = Physics2D.CircleCast((Vector2)centerPos + new Vector2(0, box.transform.localScale.y), RAY_RADIUS, Vector2.zero);
                if (upRay.collider != null)
                    return;
                instnaceBox = Instantiate(box, centerPos + new Vector3(0, box.transform.localScale.y, 0), Quaternion.identity);
                break;
            case angle.down:
                var downRay = Physics2D.CircleCast((Vector2)centerPos + new Vector2(0, -box.transform.localScale.y), RAY_RADIUS, Vector2.zero);
                if (downRay.collider != null)
                    return;
                instnaceBox = Instantiate(box, centerPos + new Vector3(0, -box.transform.localScale.y, 0), Quaternion.identity);
                break;
            case angle.right:
                var rightRay = Physics2D.CircleCast((Vector2)centerPos + new Vector2(box.transform.localScale.x, 0), RAY_RADIUS, Vector2.zero);
                if (rightRay.collider != null)
                    return;
                instnaceBox = Instantiate(box, centerPos + new Vector3(box.transform.localScale.x, 0, 0), Quaternion.identity);
                break;
            case angle.left:
                var leftRay = Physics2D.CircleCast((Vector2)centerPos + new Vector2(-box.transform.localScale.x,0), RAY_RADIUS, Vector2.zero);
                if (leftRay.collider != null)
                    return;
                instnaceBox = Instantiate(box, centerPos + new Vector3(-box.transform.localScale.x, 0, 0), Quaternion.identity);
                break;
        }

        centerPos = instnaceBox.transform.position;
        currentBoxCount++;
        instnacedBoxs.Add(instnaceBox);
        instnaceBox.transform.SetParent(transform);
    }
    private void ThrowBox()
    {
        if (instnacedBoxs.Count == 0) return;
        var parent = new GameObject("Parent");
        parent.tag = GROUND_TAG_NAME;
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
        parent.tag = GROUND_TAG_NAME;
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
        parent.tag = GROUND_TAG_NAME;
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
